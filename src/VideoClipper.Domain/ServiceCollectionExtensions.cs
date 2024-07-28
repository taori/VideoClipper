using Microsoft.Extensions.DependencyInjection;
using VideoClipper.Domain.Features;
using VideoClipper.Domain.Features.ProjectFeatures;

namespace VideoClipper.Domain;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddDomain(this IServiceCollection source)
	{
		source.AddScoped<ProjectFeatures>();
		return source;
	} 
}