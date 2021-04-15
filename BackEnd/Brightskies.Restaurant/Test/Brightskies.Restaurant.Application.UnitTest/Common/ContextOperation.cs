using Brightskies.Restaurant.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Brightskies.Restaurant.Application.UnitTest.Common
{
    public class ContextOperation
    {
        public static async Task<T> CreateEntity<T>(IRestaurantDbContext context, T entity) where T : class
        {
            // insert initial entity
            entity = context.Add(entity).Entity;
            await context.SaveChangesAsync(CancellationToken.None);
            return entity;
        }
    }
}