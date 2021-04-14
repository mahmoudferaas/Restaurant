using Brightskies.Restaurant.Application.Items.Commands.Create;
using Brightskies.Restaurant.Application.Items.Queries.GetAll;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Brightskies.Restaurant.Presentation.Controllers
{
    public class ItemsController : BaseController
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateItemCommand command)
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

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var output = await Mediator.Send(new GetAllItemsQuery());

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