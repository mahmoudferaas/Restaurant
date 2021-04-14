using AutoMapper;
using Brightskies.Restaurant.Application.Common.Dtos;
using Brightskies.Restaurant.Application.Common.Interfaces;
using Brightskies.Restaurant.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Brightskies.Restaurant.Application.Items.Commands.Create
{
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, Output>
    {
        private readonly IRestaurantDbContext _context;
        private readonly IMapper _mapper;

        public CreateItemCommandHandler(IRestaurantDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Output> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<Item>(request);

                _context.Items.Add(entity);

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