using VideoClipper.Domain.Entities;
using VideoClipper.Domain.Features.ProjectFeatures.Filters;
using VideoClipper.Domain.Features.ProjectFeatures.Results;
using VideoClipper.Domain.Features.Shared.Filters;
using VideoClipper.Domain.Features.Shared.Results;
using VideoClipper.Domain.Interfaces;
using VideoClipper.Domain.Primitives;
using VideoClipper.Domain.Shared;

namespace VideoClipper.Domain.Features.ProjectFeatures;

public class ProjectFeatures(IProjectRepository projectRepository)
{
	public async Task<DomainResult<Project>> CreateProjectAsync(ProjectKind kind, string name, CancellationToken cancellationToken)
	{
		if (await projectRepository.GetSingleAsync(new ProjectByName(name), cancellationToken) is {} exists)
			return new DuplicateProjectName(name);
			
		var project = new Project()
		{
			Name = name,
			ProjectKind = kind,
		};
		projectRepository.Insert(project);
		var changes = await projectRepository.SaveChangesAsync(cancellationToken);
		if (changes > 0)
			return project;

		return new SaveChangesFailed<Project>(changes);
	}

	public Task<Project[]> GetAllProjectsAsync(CancellationToken cancellationToken)
	{
		return projectRepository.GetArrayAsync(NoFilter<Project>.Instance, cancellationToken);
	}
}