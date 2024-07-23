namespace VideoClipper.ApplicationModel.Interfaces;

public interface IViewModelSource
{
	public IEnumerable<Type> GetModels();
}