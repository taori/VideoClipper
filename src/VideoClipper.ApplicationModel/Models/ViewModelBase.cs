using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace VideoClipper.ApplicationModel.Models;

public class ViewModelBase : ObservableObject
{
	public void RaisePropertyChanging(PropertyChangingEventArgs args)
	{
		OnPropertyChanging(args);
	}

	public void RaisePropertyChanged(PropertyChangedEventArgs args)
	{
		OnPropertyChanged(args);
	}
}