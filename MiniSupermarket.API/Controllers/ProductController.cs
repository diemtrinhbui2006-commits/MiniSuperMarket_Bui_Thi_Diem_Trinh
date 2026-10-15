using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Data;
using MiniSupermarket.API.Models;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly SupermarketDbContext _context;

        public ProductController(SupermarketDbContext context)
        {
            _context = context;
        }

        // =========================================================
        // GET: api/Product
        // Lấy danh sách tất cả sản phẩm
        // =========================================================
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .OrderBy(p => p.ProductName)
                .ToListAsync();

            return Ok(products);
        }

        // =========================================================
        // GET: api/Product/5
        // Lấy sản phẩm theo ID
        // =========================================================
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.ProductId == id);

            if (product == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy sản phẩm."
                });
            }

            return Ok(product);
        }

        // =========================================================
        // GET: api/Product/search?keyword=milk
        // Tìm kiếm theo mã vạch hoặc tên sản phẩm
        // =========================================================
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Product>>> SearchProducts(
            [FromQuery] string? keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return await GetProducts();
            }

            keyword = keyword.Trim();

            var products = await _context.Products
                .Include(p => p.Category)
                .Where(p =>
                    p.ProductName.Contains(keyword) ||
                    p.Barcode.Contains(keyword))
                .OrderBy(p => p.ProductName)
                .ToListAsync();

            return Ok(products);
        }

        // =========================================================
        // POST: api/Product
        // Thêm sản phẩm
        // =========================================================
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            // Kiểm tra tên
            if (string.IsNullOrWhiteSpace(product.ProductName))
            {
                return BadRequest(new
                {
                    message = "Tên sản phẩm không được để trống."
                });
            }

            // Kiểm tra mã vạch
            if (string.IsNullOrWhiteSpace(product.Barcode))
            {
                return BadRequest(new
                {
                    message = "Mã vạch sản phẩm không được để trống."
                });
            }

            // Kiểm tra giá
            if (product.Price < 0)
            {
                return BadRequest(new
                {
                    message = "Giá sản phẩm không được nhỏ hơn 0."
                });
            }

            // Kiểm tra tồn kho
            if (product.StockQuantity < 0)
            {
                return BadRequest(new
                {
                    message = "Số lượng tồn kho không được nhỏ hơn 0."
                });
            }

            // Kiểm tra Category có tồn tại không
            var categoryExists = await _context.Categories
                .AnyAsync(c => c.CategoryId == product.CategoryId);

            if (!categoryExists)
            {
                return BadRequest(new
                {
                    message = "Danh mục sản phẩm không tồn tại."
                });
            }

            // Kiểm tra Barcode đã tồn tại chưa
            var barcodeExists = await _context.Products
                .AnyAsync(p => p.Barcode == product.Barcode);

            if (barcodeExists)
            {
                return Conflict(new
                {
                    message = "Mã vạch sản phẩm đã tồn tại."
                });
            }

            // Chuẩn hóa dữ liệu
            product.ProductName = product.ProductName.Trim();
            product.Barcode = product.Barcode.Trim();

            // Không nhận navigation property từ client
            product.Category = null;

            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            // Load Category để trả về đầy đủ dữ liệu
            await _context.Entry(product)
                .Reference(p => p.Category)
                .LoadAsync();

            return CreatedAtAction(
                nameof(GetProduct),
                new { id = product.ProductId },
                product);
        }

        // =========================================================
        // PUT: api/Product/5
        // Cập nhật sản phẩm
        // =========================================================
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduct(
            int id,
            Product product)
        {
            // ID trên URL phải giống ID trong body
            if (id != product.ProductId)
            {
                return BadRequest(new
                {
                    message = "ProductId không khớp."
                });
            }

            // Kiểm tra tên
            if (string.IsNullOrWhiteSpace(product.ProductName))
            {
                return BadRequest(new
                {
                    message = "Tên sản phẩm không được để trống."
                });
            }

            // Kiểm tra mã vạch
            if (string.IsNullOrWhiteSpace(product.Barcode))
            {
                return BadRequest(new
                {
                    message = "Mã vạch sản phẩm không được để trống."
                });
            }

            // Kiểm tra giá
            if (product.Price < 0)
            {
                return BadRequest(new
                {
                    message = "Giá sản phẩm không được nhỏ hơn 0."
                });
            }

            // Kiểm tra tồn kho
            if (product.StockQuantity < 0)
            {
                return BadRequest(new
                {
                    message = "Số lượng tồn kho không được nhỏ hơn 0."
                });
            }

            // Tìm sản phẩm hiện tại
            var existingProduct = await _context.Products
                .FirstOrDefaultAsync(p => p.ProductId == id);

            if (existingProduct == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy sản phẩm."
                });
            }

            // Kiểm tra Category
            var categoryExists = await _context.Categories
                .AnyAsync(c => c.CategoryId == product.CategoryId);

            if (!categoryExists)
            {
                return BadRequest(new
                {
                    message = "Danh mục sản phẩm không tồn tại."
                });
            }

            // Kiểm tra Barcode trùng
            var barcodeExists = await _context.Products
                .AnyAsync(p =>
                    p.Barcode == product.Barcode &&
                    p.ProductId != id);

            if (barcodeExists)
            {
                return Conflict(new
                {
                    message = "Mã vạch sản phẩm đã tồn tại."
                });
            }

            // Cập nhật dữ liệu
            existingProduct.Barcode = product.Barcode.Trim();
            existingProduct.ProductName = product.ProductName.Trim();
            existingProduct.Price = product.Price;
            existingProduct.StockQuantity = product.StockQuantity;
            existingProduct.CategoryId = product.CategoryId;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // =========================================================
        // DELETE: api/Product/5
        // Xóa sản phẩm
        // =========================================================
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.ProductId == id);

            if (product == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy sản phẩm."
                });
            }

            _context.Products.Remove(product);

            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Xóa sản phẩm thành công."
            });
        }
    }
}