using FluentValidation;

namespace Brightskies.Restaurant.Application.Users.Comands.Login
{
    public class LoginCommandValidators : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidators()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(5);
        }
    }
}