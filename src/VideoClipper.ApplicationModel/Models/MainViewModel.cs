using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using VideoClipper.ApplicationModel.Messages;

namespace VideoClipper.ApplicationModel.Models;

public partial class MainViewModel : ViewModelBase, IRecipient<TabCloseMessage>
{
	[ObservableProperty]
	private int _selectedTabIndex;

	[ObservableProperty]
	private ObservableCollection<TabViewModelBase> _tabs = new();

	public MainViewModel()
	{
		// Svg
		// GeneratedAssets.Svg_close_24
		WeakReferenceMessenger.Default.Register(this);
		Tabs =
		[
			new ProjectViewModel()
			{
				Title = "ProjectViewModel a"
			},
			new ProjectViewModel()
			{
				Title = "ProjectViewModel b"
			},
			new ProjectCreationViewModel()
			{
				Title = "ProjectCreationViewModel c"
			},
			new SettingsViewModel()
			{
				Title = "Settings"
			},
		];
	}

	public void Receive(TabCloseMessage message)
	{
		_tabs.Remove(message.Tab);
	}

	protected override void OnPropertyChanged(PropertyChangedEventArgs e)
	{
		if (e.PropertyName == nameof(MainViewModel.SelectedTabIndex))
		{
			for (var i = 0; i < _tabs.Count; i++)
			{
				_tabs[i].Selected = SelectedTabIndex == i;
			}
		}

		base.OnPropertyChanged(e);
	}

	[RelayCommand]
	private void CloseCurrentTab(TabViewModelBase tab)
	{
		if (_tabs.Count > _selectedTabIndex)
			_tabs[_selectedTabIndex].CloseTabCommand?.Execute(null);
	}

	[RelayCommand]
	private void NextTab()
	{
		if (SelectedTabIndex == Tabs.Count - 1)
			SelectedTabIndex = 0;
		else
			SelectedTabIndex++;
	}

	[RelayCommand]
	private void PreviousTab()
	{
		if (SelectedTabIndex == 0)
			SelectedTabIndex = Tabs.Count - 1;
		else
			SelectedTabIndex--;
	}
}