using AutoMapper;
using Brightskies.Restaurant.Application.Common.Interfaces;
using Brightskies.Restaurant.Application.Reservations.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Brightskies.Restaurant.Application.Reservations.Queries.GetById
{
    public class GetReservationByIdQuery : IRequest<ReservationDto>
    {
        public int Id { get; set; }
    }

    public class GetReservationByIdQueryHandler : IRequestHandler<GetReservationByIdQuery, ReservationDto>
    {
        private readonly IRestaurantDbContext _context;
        private readonly IMapper _mapper;

        public GetReservationByIdQueryHandler(IRestaurantDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ReservationDto> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var reservations = await _context.Reservations
                    .Include(a => a.User)
                    .Include(a => a.MenuSelections)
                    .ThenInclude(a => a.Item).FirstOrDefaultAsync(a => a.Id == request.Id);

                var result = _mapper.Map<ReservationDto>(reservations);

                return result;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
    }
}