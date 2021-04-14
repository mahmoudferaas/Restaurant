using Brightskies.Restaurant.Application.Reservations.Commands.Create;
using Brightskies.Restaurant.Application.Reservations.Queries.GetAll;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Brightskies.Restaurant.Presentation.Controllers
{
    public class ReservationsController : BaseController
    {
        [HttpPost("CreateReservation")]
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

        [HttpGet("GetAllReservations")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var output = await Mediator.Send(new GetAllReservationQuery());

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