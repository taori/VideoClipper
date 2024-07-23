using System.Diagnostics.CodeAnalysis;
using VideoClipper.ApplicationModel.Interfaces;

namespace VideoClipper.ApplicationModel.Services;

public class ConventionalViewMapper : IViewMapper
{
	private readonly Dictionary<string,Type> _viewDictionary;
	private readonly Dictionary<Type,string> _modelDictionary;

	public ConventionalViewMapper(IEnumerable<IViewSource> viewSources, IEnumerable<IViewModelSource> viewModelSources)
	{
		var modelTypes = viewModelSources
			.SelectMany(d => d.GetModels())
			.ToArray();
		
		var viewTypes = viewSources
			.SelectMany(d => d.GetViews())
			.ToArray();

		_viewDictionary = viewTypes
			.ToDictionary(d => GetTrimmedName(d, "View"), d => d);
		_modelDictionary = modelTypes
			.ToDictionary(d => d, d => GetTrimmedName(d, "ViewModel"));
	}

	private static string GetTrimmedName(Type type, string endToken)
	{
		var end = type.FullName!.Split(".")[^1];
		if (endToken.Length > end.Length)
			throw new Exception($"{end} is not a valid view name");

		var indexMatch = end.LastIndexOf(endToken, StringComparison.InvariantCulture);
		if(indexMatch == end.Length - endToken.Length)
			return end[..indexMatch].ToLowerInvariant();
		
		return end.ToLowerInvariant();
	}
	
	public bool TryGetViewType(Type modelType, [NotNullWhen(true)] out Type? viewType)
	{
		viewType = default;
		return _modelDictionary.TryGetValue(modelType, out var alias) 
		       && _viewDictionary.TryGetValue(alias, out viewType);
	}
}