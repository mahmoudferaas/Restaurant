using Brightskies.Restaurant.Domain.Common;

namespace Brightskies.Restaurant.Domain.Entities
{
    public class MenuSelection : Entity
    {
        public int ItemId { get; set; }
        public int ReservationId { get; set; }
        public virtual Item Item { get; set; }
        public virtual Reservation Reservation { get; set; }
    }
}