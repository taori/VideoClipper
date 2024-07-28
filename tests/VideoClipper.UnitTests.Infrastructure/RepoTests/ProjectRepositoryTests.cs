using Shouldly;
using VideoClipper.Domain.Entities;
using VideoClipper.Domain.Primitives;
using VideoClipper.Infrastructure.Repositories;
using VideoClipper.UnitTests.Infrastructure.Shared;
using VideoClipper.UnitTests.Toolkit;
using Xunit.Abstractions;

namespace VideoClipper.UnitTests.Infrastructure.RepoTests;

public class ProjectRepositoryTests : RepositoryTestBase
{
	public ProjectRepositoryTests(ITestOutputHelper outputHelper, GlobalSetupFixture data) : base(outputHelper, data)
	{
	}

	[Fact]
	public async Task VerifyCreationSimple()
	{
		var repo = CreateRepository<ProjectRepository>();
		repo.Repository.Insert(new Project()
			{
				Name = "Some name",
				ProjectKind = ProjectKind.Folder
			}
		);
		var changes = await repo.Repository.SaveChangesAsync(CancellationToken.None);
		
		changes.ShouldBe(1);
	}
}