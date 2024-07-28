using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VideoClipper.Domain;
using VideoClipper.Infrastructure;
using VideoClipper.Infrastructure.Repositories;
using VideoClipper.UnitTests.Toolkit;
using Xunit.Abstractions;

namespace VideoClipper.UnitTests.Infrastructure.Shared;

public abstract class InfrastructureTestBase : TestBase
{
	protected InfrastructureTestBase(ITestOutputHelper outputHelper, GlobalSetupFixture data) : base(outputHelper, data)
	{
	}

	protected ServiceCollection CreateServiceCollection()
	{
		var collection = new ServiceCollection();
		collection.AddDbContextPool<ApplicationDbContext>(builder =>
		{
			builder.UseInMemoryDatabase(Guid.NewGuid().ToString());
		});
		collection.AddDomain();
		collection.AddInfrastructure();
		
		return collection;
	} 
}