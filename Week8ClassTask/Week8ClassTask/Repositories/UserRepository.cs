using Microsoft.EntityFrameworkCore;
using Week8ClassTask.Data;
using Week8ClassTask.Models;

namespace Week8ClassTask.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context) => _context = context;

        public async Task<User> GetByIdAsync(int id) =>
            await _context.Users.Include(u => u.Orders).FirstOrDefaultAsync(u => u.Id == id);

        public async Task<List<User>> GetAllAsync() =>
            await _context.Users.Include(u => u.Orders).ToListAsync();

        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

    }
}
