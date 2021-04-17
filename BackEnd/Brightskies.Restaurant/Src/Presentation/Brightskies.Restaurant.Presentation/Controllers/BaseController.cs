using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Brightskies.Restaurant.Presentation.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	public class BaseController : ControllerBase
	{
		private readonly IMediator _mediator;
		protected IMediator Mediator => _mediator ?? HttpContext.RequestServices.GetService<IMediator>();
	}
}