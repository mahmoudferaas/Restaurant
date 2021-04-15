namespace Brightskies.Restaurant.Application.Reservations.Dtos
{
    public class MenuSelectionDto
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int ReservationId { get; set; }
        public ItemDto Item { get; set; }
    }
}