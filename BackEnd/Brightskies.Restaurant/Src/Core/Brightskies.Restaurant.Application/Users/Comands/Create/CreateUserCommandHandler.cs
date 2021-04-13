using AutoMapper;
using Brightskies.Restaurant.Application.Common.Dtos;
using Brightskies.Restaurant.Application.Common.Helpers;
using Brightskies.Restaurant.Application.Common.Interfaces;
using Brightskies.Restaurant.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Brightskies.Restaurant.Application.Users.Comands.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Output>
    {
        private readonly IRestaurantDbContext _context;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IRestaurantDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Output> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<User>(request);

                if (!string.IsNullOrEmpty(request.Password))
                    entity.Password = SecurityHelper.Encrypt(request.Password);

                _context.Users.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return new Output { Status = true };
            }
            catch (System.Exception ex)
            {
                return new Output { Status = false, ErrorMessage = ex.Message };
                throw;
            }
        }
    }
}