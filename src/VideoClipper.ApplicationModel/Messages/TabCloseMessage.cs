using CommunityToolkit.Mvvm.Messaging.Messages;
using TabViewModelBase = VideoClipper.ApplicationModel.Models.TabViewModelBase;

namespace VideoClipper.ApplicationModel.Messages;

public class TabCloseMessage(
	TabViewModelBase tab
) : RequestMessage<TabViewModelBase>
{
	public TabViewModelBase Tab { get; } = tab;
}