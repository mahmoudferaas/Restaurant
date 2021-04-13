using AutoMapper;
using Brightskies.Restaurant.Application.Common;
using Brightskies.Restaurant.Application.Common.Exceptions;
using Brightskies.Restaurant.Application.Common.Helpers;
using Brightskies.Restaurant.Application.Common.Interfaces;
using Brightskies.Restaurant.Application.Users.Comands.Dtos;
using Brightskies.Restaurant.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Brightskies.Restaurant.Application.Users.Comands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginOutput>
    {
        private readonly IRestaurantDbContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public LoginCommandHandler(IRestaurantDbContext context, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public async Task<LoginOutput> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
                    return await Task.FromResult<LoginOutput>(null);

                request.Password = SecurityHelper.Encrypt(request.Password);

                // check if user exists
                var userDB = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email && x.Password == request.Password);

                if (userDB == null)
                    throw new NotFoundException(nameof(User));

                var userDto = _mapper.Map<LoginOutput>(userDB);

                userDto.Token = await GetToken(userDB);

                // authentication successful
                return userDto;
            }
            catch (Exception ex)
            {
                //return new LoginOutput { ErrorMessage = ex.Message};

                throw;
            }
        }

        public async Task<string> GetToken(User userDB)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userDB.Id.ToString())
                }),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}