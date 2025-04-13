using Microsoft.EntityFrameworkCore;
using Week8ClassTask.Data;
using Week8ClassTask.Models;
using Week8ClassTask.Repositories;

namespace OrderRepoTest
{

    public class OrderRepositoryTests
    {
        private AppDbContext _context;
        private OrderRepository _repository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "OrderDb")
                .Options;

            _context = new AppDbContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _repository = new OrderRepository(_context);
        }

        [Test]
        public async Task AddOrder_Should_CreateOrder()
        {
            var user = new User { FirstName = "A", LastName = "B", Email = "ab@example.com" };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var order = new Order { UserId = user.Id, Product = "Book", Quantity = 1, Price = 10 };
            await _repository.AddAsync(order);

            var result = await _repository.GetByIdAsync(order.OrderId);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Product, Is.EqualTo("Book"));
        }

        [Test]
        public async Task GetOrderById_Should_ReturnOrder()
        {
            var user = new User { FirstName = "U", LastName = "V", Email = "uv@example.com" };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var order = new Order { UserId = user.Id, Product = "Pen", Quantity = 2, Price = 5 };
            await _repository.AddAsync(order);

            var result = await _repository.GetByIdAsync(order.OrderId);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Product, Is.EqualTo("Pen"));
        }

        [Test]
        public async Task UpdateOrder_Should_ModifyOrder()
        {
            var user = new User { FirstName = "C", LastName = "D", Email = "cd@example.com" };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var order = new Order { UserId = user.Id, Product = "Notebook", Quantity = 1, Price = 20 };
            await _repository.AddAsync(order);

            order.Product = "Notebook - Updated";
            await _repository.UpdateAsync(order);

            var result = await _repository.GetByIdAsync(order.OrderId);
            Assert.That(result.Product, Is.EqualTo("Notebook - Updated"));
        }

        [Test]
        public async Task DeleteOrder_Should_RemoveOrder()
        {
            var user = new User { FirstName = "E", LastName = "F", Email = "ef@example.com" };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var order = new Order { UserId = user.Id, Product = "Mouse", Quantity = 1, Price = 15 };
            await _repository.AddAsync(order);

            await _repository.DeleteAsync(order.OrderId);
            var result = await _repository.GetByIdAsync(order.OrderId);

            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task GetOrderById_InvalidId_ShouldReturnNull()
        {
            var result = await _repository.GetByIdAsync(999);
            Assert.That(result, Is.Null);
        }
        [TearDown]
        public void TearDown()
        {
            _context?.Dispose();
        }

    }
}

