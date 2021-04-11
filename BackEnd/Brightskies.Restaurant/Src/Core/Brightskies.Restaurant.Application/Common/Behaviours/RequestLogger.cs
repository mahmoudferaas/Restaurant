using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Brightskies.Restaurant.Application.Common.Behaviours
{
	public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
	{
		private readonly ILogger _logger;
		public RequestLogger(ILogger<TRequest> logger)
		{
			_logger = logger;
		}

		public Task Process(TRequest request, CancellationToken cancellationToken)
		{
			var name = typeof(TRequest).Name;
			_logger.LogInformation("Restaurant Request: { Name}{ @Request}", name, request);
			return Task.CompletedTask;
		}
	}
}