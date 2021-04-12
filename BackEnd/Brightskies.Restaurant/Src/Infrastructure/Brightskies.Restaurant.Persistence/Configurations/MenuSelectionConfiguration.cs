using Brightskies.Restaurant.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Brightskies.Restaurant.Persistence.Configurations
{
    public class MenuSelectionConfiguration : IEntityTypeConfiguration<MenuSelection>
    {
        public void Configure(EntityTypeBuilder<MenuSelection> builder)
        {
            builder.HasOne(d => d.Item)
                .WithMany(p => p.MenuSelections)
                .HasForeignKey(d => d.ItemId);

            builder.HasOne(d => d.Reservation)
                .WithMany(p => p.MenuSelections)
                .HasForeignKey(d => d.ReservationId);
        }
    }
}