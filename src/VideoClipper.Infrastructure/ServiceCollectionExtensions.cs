using Microsoft.Extensions.DependencyInjection;

namespace VideoClipper.Infrastructure;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection source)
	{
		return source;
	} 
}