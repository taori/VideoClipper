using VideoClipper.Domain.Shared;

namespace VideoClipper.Domain.Features.Shared.Results;

public class SaveChangesFailed<T> : DomainResult<T>
{
	public SaveChangesFailed(T value) : base(value)
	{
	}

	public SaveChangesFailed(int number) : base($"SaveChanges count is {number}")
	{
	}
}