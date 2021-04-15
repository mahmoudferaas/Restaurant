using Brightskies.Restaurant.Application.Common.Dtos;
using Brightskies.Restaurant.Application.Reservations.Dtos;
using MediatR;
using System;
using System.Collections.Generic;

namespace Brightskies.Restaurant.Application.Reservations.Commands.Create
{
    public class CreateReservationCommand : IRequest<Output>
    {
        public int NumberOfGuests { get; set; }
        public DateTime ReservationDate { get; set; }
        public string SpecialRequest { get; set; }
        public int UserId { get; set; }
        public List<MenuSelectionDto> MenuSelections { get; set; }
    }
}