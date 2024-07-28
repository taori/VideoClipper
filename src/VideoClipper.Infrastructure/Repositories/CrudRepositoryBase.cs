using Microsoft.EntityFrameworkCore;
using VideoClipper.Domain.Interfaces;

namespace VideoClipper.Infrastructure.Repositories;

public abstract class CrudRepositoryBase<T> : ICrudRepository<T> where T : class
{
	private readonly DbContext _dbContext;

	protected CrudRepositoryBase(DbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public void Insert(T entity)
	{
		_dbContext.Set<T>().Add(entity);
	}

	public void Update(T entity)
	{
		_dbContext.Set<T>().Update(entity);
	}

	public void Delete(T entity)
	{
		_dbContext.Set<T>().Remove(entity);
	}

	public IAsyncEnumerable<T> GetAsyncEnumerableAsync(IQueryFilter<T> queryFilter)
	{
		return _dbContext.Set<T>().Where(queryFilter.GetExpression()).AsAsyncEnumerable();
	}

	public Task<T[]> GetArrayAsync(IQueryFilter<T> queryFilter, CancellationToken cancellationToken)
	{
		return _dbContext.Set<T>().Where(queryFilter.GetExpression()).ToArrayAsync(cancellationToken);
	}

	public Task<T?> GetSingleAsync(IQueryFilter<T> queryFilter, CancellationToken cancellationToken)
	{
		return _dbContext.Set<T>().FirstOrDefaultAsync(queryFilter.GetExpression(), cancellationToken);
	}

	public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
	{
		return _dbContext.SaveChangesAsync(cancellationToken);
	}
}