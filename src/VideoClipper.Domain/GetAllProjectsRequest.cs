
using Mediator;
using VideoClipper.Domain.Entities;
using VideoClipper.Domain.Features.Shared.Filters;
using VideoClipper.Domain.Interfaces;

namespace VideoClipper.Domain;

public record GetAllProjectsRequest : IRequest<Project[]> { }

public class GetAllProjectsHandler(IProjectRepository projectRepository) : IRequestHandler<GetAllProjectsRequest, Project[]>
{
	public async ValueTask<Project[]> Handle(GetAllProjectsRequest request, CancellationToken cancellationToken)
	{
		return await projectRepository.GetArrayAsync(NoFilter<Project>.Instance, cancellationToken).ConfigureAwait(false);
	}
}