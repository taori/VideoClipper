using VideoClipper.ApplicationModel.Interfaces;
using VideoClipper.ApplicationModel.Models;

namespace VideoClipper.ApplicationModel.Dependencies;

internal class ViewModelSource : IViewModelSource
{
	public IEnumerable<Type> GetModels()
	{
		var baseType = typeof(MainViewModel);
		var baseParts = baseType.FullName!.Split(".")[..^1];
		var sharedNamespace = string.Join(".", baseParts);
		var viewTypes = baseType.Assembly.GetTypes()
			.Where(d => d.FullName!.StartsWith(sharedNamespace))
			.Select(d => (type: d, parts :d.FullName!.Split(".")))
			.Where(d => d.parts.Length == baseParts.Length + 1 && d.parts[^1].EndsWith("Model", StringComparison.OrdinalIgnoreCase));
		
		return viewTypes.Select(d => d.type);
	}
}