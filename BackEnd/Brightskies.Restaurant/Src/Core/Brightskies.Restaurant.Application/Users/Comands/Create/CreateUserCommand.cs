using Brightskies.Restaurant.Application.Common.Dtos;
using MediatR;

namespace Brightskies.Restaurant.Application.Users.Comands.Create
{
    public class CreateUserCommand : IRequest<Output>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Password { get; set; }
    }
}