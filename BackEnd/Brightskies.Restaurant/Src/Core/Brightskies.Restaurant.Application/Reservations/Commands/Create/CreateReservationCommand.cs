using Brightskies.Restaurant.Application.Common.Dtos;
using MediatR;
using System;

namespace Brightskies.Restaurant.Application.Reservations.Commands.Create
{
    public class CreateReservationCommand : IRequest<Output>
    {
        public int NumberOfGuests { get; set; }
        public DateTime ReservationDate { get; set; }
        public string SpecialRequest { get; set; }
        public int UserId { get; set; }
    }
}