//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Week8ClassTask.Data;

//namespace Week8ClassTaskTest
//{
//    public static class TestDbContextFactory
//    {
//        public static AppDbContext Create()
//        {
//            // Create a fresh service provider for each test
//            var serviceProvider = new ServiceCollection()
//                .AddEntityFrameworkSqlServer()
//                .BuildServiceProvider();

//            // Create options for the context with SQL Server LocalDB
//            var options = new DbContextOptionsBuilder<AppDbContext>()
//                .UseSqlServer(
//                    "Server=(localdb)\\mssqllocaldb;Database=Week8ClassTaskTest;Trusted_Connection=True;MultipleActiveResultSets=true")
//                .UseInternalServiceProvider(serviceProvider)
//                .Options;

//            // Create the context
//            var dbContext = new AppDbContext(options);

//            // Ensure database is created (and recreated for each test)
//            dbContext.Database.EnsureDeleted();
//            dbContext.Database.EnsureCreated();

//            return dbContext;
//        }
//    }
//}
