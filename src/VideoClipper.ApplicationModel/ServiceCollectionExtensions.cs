using Microsoft.Extensions.DependencyInjection;
using VideoClipper.ApplicationModel.Dependencies;
using VideoClipper.ApplicationModel.Interfaces;
using VideoClipper.ApplicationModel.Models;
using VideoClipper.ApplicationModel.Services;

namespace VideoClipper.ApplicationModel;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddApplicationModel(this IServiceCollection source)
	{
		source.AddSingleton<IViewMapper, ConventionalViewMapper>();
		source.AddSingleton<IViewModelSource, ViewModelSource>();
		AddModels(source);
		
		return source;
	}

	private static void AddModels(IServiceCollection source)
	{
		source.AddSingleton<MainViewModel>();
		source.AddSingleton<ProjectCreationViewModel>();
		source.AddSingleton<SettingsViewModel>();
		
		source.AddScoped<ProjectViewModel>();
	}
}