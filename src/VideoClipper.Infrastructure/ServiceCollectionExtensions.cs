using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VideoClipper.Domain.Entities;
using VideoClipper.Domain.Interfaces;
using VideoClipper.Infrastructure.Repositories;

namespace VideoClipper.Infrastructure;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection source)
	{
		source.AddDbContextPool<ApplicationDbContext>((sp, builder) =>
			{
				var configuration = sp.GetRequiredService<ApplicationConfiguration>();
				builder.UseSqlite(configuration.RootConnectionString);
			}
		);
		source.AddScoped<IProjectRepository, ProjectRepository>();
		return source;
	} 
}