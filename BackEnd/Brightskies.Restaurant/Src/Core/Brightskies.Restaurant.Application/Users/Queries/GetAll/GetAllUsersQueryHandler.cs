using AutoMapper;
using Brightskies.Restaurant.Application.Common.Interfaces;
using Brightskies.Restaurant.Application.Users.Comands.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Brightskies.Restaurant.Application.Users.Queries.GetAll
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserOutput>>
    {
        private readonly IRestaurantDbContext _context;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IRestaurantDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<UserOutput>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var users = await _context.Users
                    .Include(a => a.Reservations).ToListAsync();

                return _mapper.Map<List<UserOutput>>(users);
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
    }
}