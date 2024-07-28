namespace VideoClipper.Domain.Interfaces;

public interface ICrudRepository<TEntity> where TEntity : class
{
	void Insert(TEntity entity);
	void Update(TEntity entity);
	void Delete(TEntity entity);
	IAsyncEnumerable<TEntity> GetAsyncEnumerableAsync(IQueryFilter<TEntity> queryFilter);
	Task<TEntity[]> GetArrayAsync(IQueryFilter<TEntity> queryFilter, CancellationToken cancellationToken);
	Task<TEntity?> GetSingleAsync(IQueryFilter<TEntity> queryFilter, CancellationToken cancellationToken);
	Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}