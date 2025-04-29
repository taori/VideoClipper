using Microsoft.Extensions.DependencyInjection;
using VideoClipper.UnitTests.Toolkit;
using Xunit.Abstractions;

namespace VideoClipper.UnitTests.Infrastructure.Shared;

public abstract class FeatureTestBase : InfrastructureTestBase
{
	public FeatureTestBase(ITestOutputHelper outputHelper, GlobalSetupFixture data) : base(outputHelper, data)
	{
	}

	public TestScenario<T> GetFeatureScenario<T>() where T : notnull
	{
		var serviceCollection = CreateServiceCollection();
		var sp = serviceCollection.BuildServiceProvider();
		return new TestScenario<T>(serviceCollection, sp, sp.GetRequiredService<T>());
	}

	public record class TestScenario<TFeature>(
		ServiceCollection ServiceCollection,
		IServiceProvider ServiceProvider,
		TFeature Feature
	);
}