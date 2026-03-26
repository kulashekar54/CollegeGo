using CollegeGo.ViewModel;

namespace CollegeGo;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		BindingContext = new MessageViewModel();
	}

}
