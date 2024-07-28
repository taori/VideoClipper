using System.Linq.Expressions;
using VideoClipper.Domain.Interfaces;

namespace VideoClipper.Domain.Features.ProjectFeatures.Filters;

public class ProjectByName(string value) : IQueryFilter<Entities.Project>
{
	public Expression<Func<Entities.Project, bool>> GetExpression()
	{
		return project => project.Name == value;
	}
}