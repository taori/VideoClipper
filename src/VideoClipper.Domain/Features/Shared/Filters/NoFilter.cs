using System.Linq.Expressions;
using VideoClipper.Domain.Interfaces;

namespace VideoClipper.Domain.Features.Shared.Filters;

public class NoFilter<T> : IQueryFilter<T>
{
	private NoFilter(){}
	
	public static readonly NoFilter<T> Instance = new();
	
	public Expression<Func<T, bool>> GetExpression()
	{
		return arg => true;
	}
}