using MediatR;
using Brightskies.Restaurant.Application.Users.Comands.Dtos;

namespace Brightskies.Restaurant.Application.Users.Comands.Login
{
    public class LoginCommand : IRequest<LoginOutput>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}