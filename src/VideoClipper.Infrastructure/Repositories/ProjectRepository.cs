using VideoClipper.Domain.Entities;
using VideoClipper.Domain.Interfaces;

namespace VideoClipper.Infrastructure.Repositories;

internal class ProjectRepository : CrudRepositoryBase<Project>, IProjectRepository
{
	public ProjectRepository(ApplicationDbContext dbContext) : base(dbContext)
	{
	}
}