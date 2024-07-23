using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using VideoClipper.ApplicationModel.Messages;

namespace VideoClipper.ApplicationModel.Models;

public abstract partial class TabViewModelBase : ViewModelBase
{
	[ObservableProperty]
	[NotifyPropertyChangedFor(nameof(TabCloseCss))]
	private bool _selected;

	[ObservableProperty]
	private string _title;

	public string TabCloseCss =>
		Selected
			? ".Black { fill: #FF0000; }"
			: ".Black { fill: #FFFF00; }";

	[RelayCommand]
	private async Task CloseTab()
	{
		if (await OnTabCloseRequested())
			WeakReferenceMessenger.Default.Send(new TabCloseMessage(this));
	}

	/// <summary>
	/// Returns true if the tab can be closed
	/// </summary>
	/// <returns></returns>
	protected virtual Task<bool> OnTabCloseRequested() => Task.FromResult(true);
}