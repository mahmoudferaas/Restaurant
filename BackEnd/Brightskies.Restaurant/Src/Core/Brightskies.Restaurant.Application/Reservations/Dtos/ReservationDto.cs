using System;
using System.Collections.Generic;

namespace Brightskies.Restaurant.Application.Reservations.Dtos
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public int NumberOfGuests { get; set; }
        public DateTime ReservationDate { get; set; }
        public string SpecialRequest { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
        public List<ItemDto> Items { get; set; }
    }
}