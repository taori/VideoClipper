using System.Diagnostics.CodeAnalysis;

namespace VideoClipper.ApplicationModel.Interfaces;

public interface IViewMapper
{
	public bool TryGetViewType(Type modelType, [NotNullWhen(true)] out Type? viewType);
}