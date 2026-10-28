using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Data;
using MiniSupermarket.API.Models;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly SupermarketDbContext _context;

        public CustomersController(SupermarketDbContext context)
        {
            _context = context;
        }

        // Bài tập 6.1: phân trang khách hàng theo điểm thưởng giảm dần.
        [HttpGet("paged")]
        public async Task<IActionResult> GetPagedCustomers(
            [FromQuery] string? keyword = null,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 5,
            CancellationToken cancellationToken = default)
        {
            pageNumber = Math.Max(1, pageNumber);
            if (pageSize < 1 || pageSize > 50) pageSize = 5;

            var query = _context.Customers.AsNoTracking().AsQueryable();
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                var search = keyword.Trim().ToLower();
                query = query.Where(c => c.CustomerName.ToLower().Contains(search)
                    || c.PhoneNumber.Contains(search));
            }

            var totalItems = await query.CountAsync(cancellationToken);
            var result = new PagedResult<Customer>
            {
                CurrentPage = pageNumber,
                PageSize = pageSize,
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling((double)totalItems / pageSize)
            };

            var offset = ((long)pageNumber - 1) * pageSize;
            if (offset < totalItems)
            {
                result.Items = await query
                    .OrderByDescending(c => c.RewardPoints)
                    .ThenBy(c => c.CustomerId)
                    .Skip((int)offset)
                    .Take(pageSize)
                    .ToListAsync(cancellationToken);
            }

            return Ok(result);
        }

        // GET: api/customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        // GET: api/customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy khách hàng!"
                });
            }

            return customer;
        }

        // GET: api/customers/search?keyword=nguyen
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Customer>>> SearchCustomers(
            [FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return await _context.Customers.ToListAsync();
            }

            keyword = keyword.Trim();

            var customers = await _context.Customers
                .Where(c =>
                    c.CustomerName.Contains(keyword) ||
                    c.PhoneNumber.Contains(keyword) ||
                    (c.Address != null && c.Address.Contains(keyword)))
                .ToListAsync();

            return customers;
        }

        // POST: api/customers
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            if (customer == null)
            {
                return BadRequest(new
                {
                    message = "Dữ liệu khách hàng không hợp lệ!"
                });
            }

            // Mặc định
            customer.RewardPoints = customer.RewardPoints < 0
                ? 0
                : customer.RewardPoints;

            if (string.IsNullOrWhiteSpace(customer.MembershipRank))
            {
                customer.MembershipRank = "Chuẩn";
            }

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetCustomer),
                new { id = customer.CustomerId },
                customer);
        }

        // PUT: api/customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(
            int id,
            Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return BadRequest(new
                {
                    message = "ID khách hàng không khớp!"
                });
            }

            var existingCustomer = await _context.Customers.FindAsync(id);

            if (existingCustomer == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy khách hàng!"
                });
            }

            existingCustomer.CustomerName = customer.CustomerName;
            existingCustomer.PhoneNumber = customer.PhoneNumber;
            existingCustomer.Address = customer.Address;
            existingCustomer.RewardPoints = customer.RewardPoints;
            existingCustomer.MembershipRank = customer.MembershipRank;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy khách hàng!"
                });
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}