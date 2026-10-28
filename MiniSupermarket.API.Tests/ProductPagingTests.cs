using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using MiniSupermarket.API.Data;
using MiniSupermarket.API.Models;
using Xunit;

namespace MiniSupermarket.API.Tests;

public sealed class ProductPagingTests : IDisposable
{
    private readonly SupermarketApiFactory _factory = new();
    private readonly HttpClient _client;

    public ProductPagingTests()
    {
        _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            BaseAddress = new Uri("https://localhost")
        });
    }

    [Fact]
    public async Task PagesHaveStableOrderingMetadataAndCategoryNames()
    {
        var pages = new List<ProductItemDto>();
        var categories = await _client.GetFromJsonAsync<List<Category>>("/api/categories");
        Assert.NotNull(categories);

        for (var page = 1; page <= 3; page++)
        {
            var result = await Products($"pageNumber={page}&pageSize=5");
            Assert.Equal(page, result.CurrentPage);
            Assert.Equal(5, result.PageSize);
            Assert.Equal(15, result.TotalItems);
            Assert.Equal(3, result.TotalPages);
            Assert.Equal(5, result.Items.Count);
            Assert.All(result.Items, product =>
                Assert.Equal(categories.Single(c => c.CategoryId == product.CategoryId).CategoryName,
                    product.CategoryName));
            pages.AddRange(result.Items);
        }

        Assert.Equal(Enumerable.Range(1, 15), pages.Select(p => p.ProductId));
    }

    [Fact]
    public async Task SearchAndCategoryFilterAreAppliedBeforeCountingAndPaging()
    {
        var result = await Products("keyword=%20COCA%20&categoryId=2&pageSize=1");
        var product = Assert.Single(result.Items);
        Assert.Contains("Coca", product.ProductName);
        Assert.Equal(2, product.CategoryId);
        Assert.Equal(1, result.TotalItems);
        Assert.Equal(1, result.TotalPages);
        Assert.Empty((await Products("keyword=Coca&categoryId=1")).Items);
    }

    [Fact]
    public async Task BarcodeSearchFindsTheMatchingProduct()
    {
        var result = await Products("keyword=8934567890003");
        Assert.Equal(3, Assert.Single(result.Items).ProductId);
        Assert.Equal(1, result.TotalItems);
    }

    [Theory]
    [InlineData(-4, 0)]
    [InlineData(0, -1)]
    [InlineData(0, 51)]
    public async Task InvalidPagingInputsUseSafeDefaults(int pageNumber, int pageSize)
    {
        var result = await Products($"pageNumber={pageNumber}&pageSize={pageSize}");
        Assert.Equal(1, result.CurrentPage);
        Assert.Equal(5, result.PageSize);
        Assert.Equal(5, result.Items.Count);
    }

    [Theory]
    [InlineData("keyword=does-not-exist", 1, 0, 0)]
    [InlineData("pageNumber=4", 4, 15, 3)]
    [InlineData("pageNumber=2147483647&pageSize=50", int.MaxValue, 15, 1)]
    public async Task EmptyOrOutOfRangePagesRetainAccurateMetadata(
        string query, int currentPage, int totalItems, int totalPages)
    {
        var result = await Products(query);
        Assert.Equal(currentPage, result.CurrentPage);
        Assert.Equal(totalItems, result.TotalItems);
        Assert.Equal(totalPages, result.TotalPages);
        Assert.Empty(result.Items);
    }

    [Fact]
    public async Task CustomerPagesSortByRewardPointsThenIdAndSupportSearch()
    {
        using (var scope = _factory.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<SupermarketDbContext>();
            context.Customers.AddRange(
                new Customer { CustomerId = 100, CustomerName = "Paging Tie A", PhoneNumber = "100", Address = "Test", RewardPoints = 1000 },
                new Customer { CustomerId = 101, CustomerName = "Paging Tie B", PhoneNumber = "101", Address = "Test", RewardPoints = 1000 });
            await context.SaveChangesAsync();
        }

        var result = await _client.GetFromJsonAsync<PagedResult<Customer>>("/api/customers/paged?pageSize=50");
        Assert.NotNull(result);
        Assert.Equal(15, result.TotalItems);
        Assert.Equal(new[] { 100, 101 }, result.Items.Take(2).Select(c => c.CustomerId));
        Assert.Equal(result.Items.OrderByDescending(c => c.RewardPoints).ThenBy(c => c.CustomerId)
            .Select(c => c.CustomerId), result.Items.Select(c => c.CustomerId));

        var filtered = await _client.GetFromJsonAsync<PagedResult<Customer>>("/api/customers/paged?keyword=%20PAGING%20&pageSize=1&pageNumber=2");
        Assert.NotNull(filtered);
        Assert.Equal(2, filtered.TotalItems);
        Assert.Equal(2, filtered.TotalPages);
        Assert.Equal(101, Assert.Single(filtered.Items).CustomerId);
    }

    [Fact]
    public async Task PluralCrudUpdatesPagingAndPreservesBarcodeAndLegacyRoutes()
    {
        var product = new Product
        {
            Barcode = "lesson6-test", ProductName = "Lesson 6 test product",
            Price = 12500, StockQuantity = 12, CategoryId = 2
        };
        using var create = await _client.PostAsJsonAsync("/api/products", product);
        Assert.Equal(HttpStatusCode.Created, create.StatusCode);
        var created = await create.Content.ReadFromJsonAsync<Product>();
        Assert.NotNull(created);
        Assert.NotNull(create.Headers.Location);
        Assert.Equal(HttpStatusCode.OK, (await _client.GetAsync(create.Headers.Location)).StatusCode);
        Assert.Equal(created.ProductId,
            Assert.Single((await Products("keyword=lesson6-test")).Items).ProductId);

        created.ProductName = "Lesson 6 updated";
        created.Price = 15000;
        created.StockQuantity = 9;
        using var update = await _client.PutAsJsonAsync($"/api/products/{created.ProductId}", created);
        Assert.Equal(HttpStatusCode.NoContent, update.StatusCode);
        var fromLegacy = await _client.GetFromJsonAsync<Product>($"/api/Product/{created.ProductId}");
        Assert.NotNull(fromLegacy);
        Assert.Equal("Lesson 6 updated", fromLegacy.ProductName);
        Assert.Equal(15000, fromLegacy.Price);
        Assert.Equal(9, fromLegacy.StockQuantity);
        var byBarcode = await _client.GetFromJsonAsync<Product>("/api/products/barcode/lesson6-test");
        Assert.Equal(created.ProductId, byBarcode?.ProductId);

        using var delete = await _client.DeleteAsync($"/api/products/{created.ProductId}");
        Assert.Equal(HttpStatusCode.OK, delete.StatusCode);
        Assert.Equal(HttpStatusCode.NotFound,
            (await _client.GetAsync($"/api/products/{created.ProductId}")).StatusCode);
        Assert.Empty((await Products("keyword=lesson6-test")).Items);
        Assert.Equal(15, (await Products("")).TotalItems);
    }

    [Theory]
    [InlineData(-1, 2, 1, "unique-invalid", HttpStatusCode.BadRequest)]
    [InlineData(1, -1, 1, "unique-invalid", HttpStatusCode.BadRequest)]
    [InlineData(1, 2, 99999, "unique-invalid", HttpStatusCode.BadRequest)]
    [InlineData(1, 2, 1, "8934567890001", HttpStatusCode.Conflict)]
    public async Task InvalidProductWritesAreRejectedWithoutChangingTotals(
        decimal price, int stock, int categoryId, string barcode, HttpStatusCode expected)
    {
        using var response = await _client.PostAsJsonAsync("/api/products", new Product
        {
            ProductName = "Invalid product", Barcode = barcode,
            Price = price, StockQuantity = stock, CategoryId = categoryId
        });
        Assert.Equal(expected, response.StatusCode);
        Assert.Equal(15, (await Products("")).TotalItems);
    }

    private async Task<PagedResult<ProductItemDto>> Products(string query)
    {
        using var response = await _client.GetAsync("/api/products/paged?" + query);
        response.EnsureSuccessStatusCode();
        return (await response.Content.ReadFromJsonAsync<PagedResult<ProductItemDto>>())!;
    }

    public void Dispose()
    {
        _client.Dispose();
        _factory.Dispose();
    }
}
