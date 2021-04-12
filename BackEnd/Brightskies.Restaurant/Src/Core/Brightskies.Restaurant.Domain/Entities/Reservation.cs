using Brightskies.Restaurant.Domain.Common;
using System;
using System.Collections.Generic;

namespace Brightskies.Restaurant.Domain.Entities
{
    public class Reservation : Entity
    {
        public int NumberOfGuests { get; set; }
        public DateTime ReservationDate { get; set; }
        public string SpecialRequest { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<MenuSelection> MenuSelections { get; set; }

    }
}