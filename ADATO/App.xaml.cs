using ADATO.MVVM.Views;

namespace ADATO;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new MainView());
	}
}
