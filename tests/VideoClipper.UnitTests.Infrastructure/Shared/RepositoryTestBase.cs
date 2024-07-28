using Microsoft.Extensions.DependencyInjection;
using VideoClipper.UnitTests.Toolkit;
using Xunit.Abstractions;

namespace VideoClipper.UnitTests.Infrastructure.Shared;

public abstract class RepositoryTestBase : InfrastructureTestBase
{
	protected RepositoryTestBase(ITestOutputHelper outputHelper, GlobalSetupFixture data) : base(outputHelper, data)
	{
	}

	protected virtual TestSample<T> CreateRepository<T>() where T : class
	{
		var collection = CreateServiceCollection();
		collection.AddScoped<T>();

		var sp = collection.BuildServiceProvider();
		return new TestSample<T>(collection, sp.GetRequiredService<T>());
	}

	public record class TestSample<TRepo>(
		ServiceCollection ServiceCollection,
		TRepo Repository
	);
}