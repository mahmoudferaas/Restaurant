using AutoMapper;
using Brightskies.Restaurant.Application.Common.Interfaces;
using Brightskies.Restaurant.Application.Reservations.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Brightskies.Restaurant.Application.Reservations.Queries.GetAll
{
    public class GetAllReservationQuery : IRequest<List<ReservationDto>>
    {
    }

    public class GetAllReservationQueryHandler : IRequestHandler<GetAllReservationQuery, List<ReservationDto>>
    {
        private readonly IRestaurantDbContext _context;
        private readonly IMapper _mapper;

        public GetAllReservationQueryHandler(IRestaurantDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ReservationDto>> Handle(GetAllReservationQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var reservations = await _context.Reservations.Include(a => a.User).Include(a => a.MenuSelections).ToListAsync();

                return _mapper.Map<List<ReservationDto>>(reservations);
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
    }
}