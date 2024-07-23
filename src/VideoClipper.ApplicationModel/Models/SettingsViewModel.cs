namespace VideoClipper.ApplicationModel.Models;

public partial class SettingsViewModel : TabViewModelBase
{
	protected override Task<bool> OnTabCloseRequested()
	{
		return Task.FromResult(false);
	}
}