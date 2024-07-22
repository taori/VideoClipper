using Microsoft.Extensions.DependencyInjection;

namespace VideoClipper.Domain;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddDomain(this IServiceCollection source)
	{
		return source;
	} 
}