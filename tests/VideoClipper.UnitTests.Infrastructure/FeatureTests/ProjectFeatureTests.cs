using System.Runtime.CompilerServices;
using Mediator;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using VideoClipper.Domain;
using VideoClipper.Domain.Features;
using VideoClipper.Domain.Features.ProjectFeatures;
using VideoClipper.Domain.Features.ProjectFeatures.Results;
using VideoClipper.Domain.Primitives;
using VideoClipper.UnitTests.Infrastructure.Shared;
using VideoClipper.UnitTests.Toolkit;
using Xunit.Abstractions;

namespace VideoClipper.UnitTests.Infrastructure.FeatureTests;

public class ProjectFeatureTests : FeatureTestBase
{
	public ProjectFeatureTests(ITestOutputHelper outputHelper, GlobalSetupFixture data) : base(outputHelper, data)
	{
	}

	[Theory]
	[InlineData("project1", "project1", typeof(DuplicateProjectName))]
	[InlineData("project1", "project2", null)]
	public async Task DuplicationDetection(string firstName, string secondName, Type? secondType)
	{
		var scenario = GetFeatureScenario<ProjectFeatures>();
		var feature = scenario.Feature;
		var actions = new[]
		{
			await feature.CreateProjectAsync(ProjectKind.Folder, firstName, CancellationToken.None), 
			await feature.CreateProjectAsync(ProjectKind.Folder, secondName, CancellationToken.None),
		};
		
		actions.Length.ShouldBe(2);
		actions[0].Success.ShouldBeTrue();
		if (secondType is not null)
		{
			actions[1].Success.ShouldBeFalse();
			actions[1].GetType().ShouldBe(secondType);
		}
		else
		{
			actions[1].Success.ShouldBeTrue();
		}
	}

	[Theory]
	[InlineData("asdf1","asdf2")]
	[InlineData("asdf1","asdf2","asdf3")]
	public async Task GetAllProjects(params string[] names)
	{
		var scenario = GetFeatureScenario<ProjectFeatures>();
		var feature = scenario.Feature;
		var tasks = names
			.Select(name => feature.CreateProjectAsync(ProjectKind.Folder, name, CancellationToken.None))
			.ToArray();
		await Task.WhenAll(tasks);

		var loadedProjects = await feature.GetAllProjectsAsync(CancellationToken.None);
		loadedProjects.Length.ShouldBe(names.Length);
		var sender = scenario.ServiceProvider.GetRequiredService<ISender>();
		var response = await sender.Send(new GetAllProjectsRequest());
		response.Length.ShouldBe(names.Length);
	}
}
