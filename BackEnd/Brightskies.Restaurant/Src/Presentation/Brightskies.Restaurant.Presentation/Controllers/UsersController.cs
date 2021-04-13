using Brightskies.Restaurant.Application.Users.Comands.Create;
using Brightskies.Restaurant.Application.Users.Comands.Login;
using Brightskies.Restaurant.Application.Users.Queries.GetAll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Brightskies.Restaurant.Presentation.Controllers
{
    //[Authorize]
    public class UsersController : BaseController
    {
        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            try
            {
                var output = await Mediator.Send(command);

                return Ok(output);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            try
            {
                var output = await Mediator.Send(command);

                return Ok(output);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPost("GetAllUsers")]
        public async Task<IActionResult> GetAll([FromBody] GetAllUsersQuery query)
        {
            try
            {
                var output = await Mediator.Send(query);

                return Ok(output);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}