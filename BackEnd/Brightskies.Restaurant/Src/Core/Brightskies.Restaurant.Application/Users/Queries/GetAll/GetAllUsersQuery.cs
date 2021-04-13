using MediatR;
using System.Collections.Generic;
using Brightskies.Restaurant.Application.Users.Comands.Dtos;

namespace Brightskies.Restaurant.Application.Users.Queries.GetAll
{
    public class GetAllUsersQuery : IRequest<List<UserOutput>>
    {

    }
}