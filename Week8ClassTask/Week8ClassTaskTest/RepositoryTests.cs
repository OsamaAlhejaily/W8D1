using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using Week8ClassTask.Data;
using Week8ClassTask.Repositories;

namespace Week8ClassTaskTest
{
    [TestFixture]
    public class RepositoryTests
    {
        private AppDbContext _context;
        private UserRepository _userRepo;
        private OrderRepository _orderRepo;


        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            _context = new AppDbContext(options);
            _userRepo = new UserRepository(_context);
            _orderRepo = new OrderRepository(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context?.Dispose();
        }

    }
}
