using Brightskies.Restaurant.Domain.Common;
using System.Collections.Generic;

namespace Brightskies.Restaurant.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Password { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}