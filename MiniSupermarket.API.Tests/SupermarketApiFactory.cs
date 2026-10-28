using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using MiniSupermarket.API.Data;

namespace MiniSupermarket.API.Tests;

// Keep relational constraints and LINQ translation without requiring a local SQL Server.
// Each factory has an isolated database seeded from the application's actual EF model.
public sealed class SupermarketApiFactory : WebApplicationFactory<SupermarketDbContext>
{
    private readonly SqliteConnection _connection = new("Data Source=:memory:");

    public SupermarketApiFactory() => _connection.Open();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Development");
        builder.ConfigureTestServices(services =>
        {
            services.RemoveAll<DbContextOptions<SupermarketDbContext>>();
            services.AddDbContext<SupermarketDbContext>(options => options.UseSqlite(_connection));
        });
    }

    protected override IHost CreateHost(IHostBuilder builder)
    {
        var host = base.CreateHost(builder);
        using var scope = host.Services.CreateScope();
        scope.ServiceProvider.GetRequiredService<SupermarketDbContext>().Database.EnsureCreated();
        return host;
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        if (disposing) _connection.Dispose();
    }
}
