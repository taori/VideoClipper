using System.Diagnostics.CodeAnalysis;

namespace VideoClipper.Domain.Shared;

public class DomainResult<T>
{
	public DomainResult(T value)
	{
		Value = value;
		Success = true;
	}

	public DomainResult(string error)
	{
		Error = error;
		Success = false;
	}
	
	[MemberNotNullWhen(false, nameof(Success))]
	public string? Error { get; set; }

	public bool Success { get; set; }

	public static implicit operator DomainResult<T>(T value) => new(value);

	[MemberNotNullWhen(true, nameof(Success))]
	public T? Value { get; set; }
}