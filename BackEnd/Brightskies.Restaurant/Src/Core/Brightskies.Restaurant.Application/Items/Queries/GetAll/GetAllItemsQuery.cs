using AutoMapper;
using Brightskies.Restaurant.Application.Common.Interfaces;
using Brightskies.Restaurant.Application.Reservations.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Brightskies.Restaurant.Application.Items.Queries.GetAll
{
    public class GetAllItemsQuery : IRequest<List<ItemDto>>
    {
    }

    public class GetAllItemsQueryHandler : IRequestHandler<GetAllItemsQuery, List<ItemDto>>
    {
        private readonly IRestaurantDbContext _context;
        private readonly IMapper _mapper;

        public GetAllItemsQueryHandler(IRestaurantDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ItemDto>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var reservations = await _context.Items.ToListAsync();

                return _mapper.Map<List<ItemDto>>(reservations);
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
    }
}
