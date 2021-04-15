﻿using FluentValidation;
using System.Linq;
using Brightskies.Restaurant.Application.Common.Interfaces;

namespace Brightskies.Restaurant.Application.Users.Comands.Create
{
    public class CreateUserCommandValidators : AbstractValidator<CreateUserCommand>
    {
        private readonly IRestaurantDbContext _context;

        public CreateUserCommandValidators(IRestaurantDbContext context)
        {
            _context = context;
            RuleFor(x => x.Email).Must(UniqueEmail).WithMessage("This Email already exists.");
            
        }

        public CreateUserCommandValidators()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(5);
        }


        private bool UniqueEmail(string email)
        {
            var user = _context.Users.Where(x => x.Email == email).FirstOrDefault();

            return user == null;
        }
    }
}