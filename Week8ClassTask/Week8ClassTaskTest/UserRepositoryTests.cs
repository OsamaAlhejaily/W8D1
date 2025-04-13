using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Week8ClassTask.Data;
using Week8ClassTask.Models;
using Week8ClassTask.Repositories;

namespace Tests
{
    public class UserRepositoryTests
    {
        private AppDbContext _context;
        private UserRepository _repository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "UserDb")
                .Options;

            _context = new AppDbContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _repository = new UserRepository(_context);
        }

        [Test]
        public async Task AddUser_Should_CreateUser()
        {
            var user = new User { FirstName = "Osama", LastName = "Alhejaily", Email = "Osama@example.com" };
            await _repository.AddAsync(user);

            var result = await _repository.GetByIdAsync(user.Id);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.FirstName, Is.EqualTo("Osama"));
        }

        [Test]
        public async Task GetUserById_Should_ReturnUser()
        {
            var user = new User { FirstName = "Ahmed", LastName = "Aljuhani", Email = "ahmed@example.com" };
            await _repository.AddAsync(user);

            var result = await _repository.GetByIdAsync(user.Id);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.LastName, Is.EqualTo("Aljuhani"));
        }

        [Test]
        public async Task UpdateUser_Should_ModifyUser()
        {
            var user = new User { FirstName = "Yousef", LastName = "Alhejaily", Email = "yousef@example.com" };
            await _repository.AddAsync(user);

            user.FirstName = "Turki";
            await _repository.UpdateAsync(user);

            var result = await _repository.GetByIdAsync(user.Id);
            Assert.That(result.FirstName, Is.EqualTo("Turki"));
        }

        [Test]
        public async Task DeleteUser_Should_RemoveUser()
        {
            var user = new User { FirstName = "Abdallah", LastName = "Alharbi", Email = "Abdallah@example.com" };
            await _repository.AddAsync(user);

            await _repository.DeleteAsync(user.Id);
            var result = await _repository.GetByIdAsync(user.Id);

            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task GetUserById_InvalidId_ShouldReturnNull()
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
