using Brightskies.Restaurant.Application.Reservations.Commands.Create;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Brightskies.Restaurant.Presentation.Controllers
{
    public class ReservationsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateReservationCommand command)
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
    }
}