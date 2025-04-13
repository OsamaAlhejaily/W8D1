using Microsoft.EntityFrameworkCore;
using Week8ClassTask.Data;
using Week8ClassTask.Models;

namespace Week8ClassTask.Repositories
{
    using Microsoft.EntityFrameworkCore;
   

    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;
        public OrderRepository(AppDbContext context) => _context = context;

        public async Task<Order> GetByIdAsync(int id) =>
            await _context.Orders.Include(o => o.User).FirstOrDefaultAsync(o => o.OrderId == id);

        public async Task<List<Order>> GetAllAsync() =>
            await _context.Orders.Include(o => o.User).ToListAsync();

        public async Task AddAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }
    }


}
