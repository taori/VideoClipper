using System.Linq.Expressions;
using VideoClipper.Domain.Entities;
using VideoClipper.Domain.Interfaces;

namespace VideoClipper.Domain.Features.ProjectFeatures.Filters;

public class ProjectById(ProjectId value) : IQueryFilter<Project>
{
	public Expression<Func<Project, bool>> GetExpression()
	{
		return project => project.Id == value;
	}
}