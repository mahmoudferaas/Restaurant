using Brightskies.Restaurant.Application.Common.Dtos;
using MediatR;

namespace Brightskies.Restaurant.Application.Items.Commands.Create
{
    public class CreateItemCommand : IRequest<Output>
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }
}