using Brightskies.Restaurant.Persistence;
using Microsoft.EntityFrameworkCore;
using System;

namespace Brightskies.Restaurant.Application.UnitTest.Common
{
    public class ContextFactory
    {
        public static RestaurantDbContext Create()
        {
            var options = new DbContextOptionsBuilder<RestaurantDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            var context = new RestaurantDbContext(options);

            context.Database.EnsureCreated();

            context.SaveChanges();

            return context;
        }

        public static void Destroy(RestaurantDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}