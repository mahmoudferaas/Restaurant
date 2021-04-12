using Brightskies.Restaurant.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading;
using System.Threading.Tasks;

namespace Brightskies.Restaurant.Application.Common.Interfaces
{
    public interface IRestaurantDbContext
    {
        DbSet<Reservation> Reservations { get; set; }
        DbSet<MenuSelection> MenuSelections { get; set; }
        DbSet<Item> Items { get; set; }
        DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        EntityEntry<T> Add<T>(T entity) where T : class;
    }
}