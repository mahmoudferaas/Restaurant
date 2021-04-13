using Brightskies.Restaurant.Application.Reservations.Dtos;
using System.Collections.Generic;

namespace Brightskies.Restaurant.Application.Users.Comands.Dtos
{
    public class UserOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public List<ReservationDto> Reservations { get; set; }
    }
}