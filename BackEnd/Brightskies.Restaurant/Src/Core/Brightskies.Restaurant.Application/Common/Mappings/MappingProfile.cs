using AutoMapper;
using Brightskies.Restaurant.Application.Reservations.Commands.Create;
using Brightskies.Restaurant.Application.Reservations.Dtos;
using Brightskies.Restaurant.Domain.Entities;

namespace Brightskies.Restaurant.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateReservationCommand, Reservation>().ReverseMap();
            CreateMap<ReservationDto, Reservation>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<ItemDto, Item>().ReverseMap();
        }
    }
}