using Microsoft.Extensions.DependencyInjection;
using VideoClipper.Domain.Features.ProjectFeatures;

namespace VideoClipper.Domain;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddDomain(this IServiceCollection source)
	{
		source.AddMediator();
		source.AddScoped<ProjectFeatures>();
		return source;
	} 
}