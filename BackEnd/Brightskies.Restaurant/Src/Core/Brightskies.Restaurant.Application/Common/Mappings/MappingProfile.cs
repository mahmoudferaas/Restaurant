using AutoMapper;
using Brightskies.Restaurant.Application.Items.Commands.Create;
using Brightskies.Restaurant.Application.Reservations.Commands.Create;
using Brightskies.Restaurant.Application.Reservations.Dtos;
using Brightskies.Restaurant.Application.Users.Comands.Create;
using Brightskies.Restaurant.Application.Users.Comands.Dtos;
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
            CreateMap<CreateUserCommand, User>().ReverseMap();
            CreateMap<LoginOutput, User>().ReverseMap();
            CreateMap<UserOutput, User>().ReverseMap();
            CreateMap<CreateItemCommand, Item>().ReverseMap();
        }
    }
}