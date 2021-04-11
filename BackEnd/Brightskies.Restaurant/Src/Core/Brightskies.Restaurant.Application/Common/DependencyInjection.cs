using AutoMapper;
using Brightskies.Restaurant.Application.Common.Behaviours;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Brightskies.Restaurant.Application.Common
{
	public static class DependencyInjection
	{

		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			services.AddAutoMapper(Assembly.GetExecutingAssembly());

			services.AddMediatR(Assembly.GetExecutingAssembly());

			services.AddLocalization();

			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));

			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

			return services;
		}
	}
}