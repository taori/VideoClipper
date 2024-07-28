using System.Linq.Expressions;

namespace VideoClipper.Domain.Interfaces;

public interface IQueryFilter<T>
{
	Expression<Func<T, bool>> GetExpression();
}