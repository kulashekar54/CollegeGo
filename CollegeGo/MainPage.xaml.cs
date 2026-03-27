using CollegeGo.ViewModel;

namespace CollegeGo;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		BindingContext = new MessageViewModel();
	}

	private void OnItemAppearing(object sender, ItemVisibilityEventArgs e)
	{
		var vm = BindingContext as MessageViewModel;

		if (vm == null || vm.IsBusy)
			return;

		if (e.Item == vm.Items.LastOrDefault())
		{
			vm.LoadMoreCommand.Execute(null);
		}
	}

}
