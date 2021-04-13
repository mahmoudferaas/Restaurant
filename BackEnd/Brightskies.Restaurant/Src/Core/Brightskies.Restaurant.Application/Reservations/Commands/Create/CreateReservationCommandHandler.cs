using AutoMapper;
using Brightskies.Restaurant.Application.Common.Dtos;
using Brightskies.Restaurant.Application.Common.Interfaces;
using Brightskies.Restaurant.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Brightskies.Restaurant.Application.Reservations.Commands.Create
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, Output>
    {
        private readonly IRestaurantDbContext _context;
        private readonly IMapper _mapper;

        public CreateReservationCommandHandler(IRestaurantDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Output> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<Reservation>(request);

                _context.Reservations.Add(entity);

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