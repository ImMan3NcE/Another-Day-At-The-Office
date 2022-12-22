using ADATO.MVVM.ViewModels;


namespace ADATO.MVVM.Views;

public partial class MainView : ContentPage
{
	public MainView()
	{
		InitializeComponent();
		BindingContext = new MainViewModel();
        IfHolidays();
        //CheckVersion();
        
    }

    //public async void CheckVersion()
    //{
    //    string version = AppInfo.Current.VersionString;
        
    //    await DisplayAlert($"{version}", "You have been alerted", "OK");
    //}

    public void IfHolidays()
    {
        DateTime chrismtas = new DateTime(DateTime.Today.Year, 12, 24);
        DateTime newYearEveParty = new DateTime(DateTime.Today.Year, 12, 31);
        DateTime newYear = new DateTime(DateTime.Today.Year, 01, 01);

        if (DateTime.Today== chrismtas)
        {
            lblBaner.Text = "Weso³ych œwi¹t!";
        }
        else if (DateTime.Today == newYearEveParty)
        {
            lblBaner.Text = "Udanego Sylwestra!";
        }
        else if(DateTime.Today == newYear)
        {
            lblBaner.Text = "Szczêœliwego Nowego Roku!";
        }
        else
        {
            lblBaner.Text = "Another Day at The Office";
        }
    }

	private void Button_NameDay(object sender, EventArgs e)
	{
        //App.Current.MainPage = new NameDay();
        Navigation.PushAsync(new NameDay());
    }
    private void Button_QuoteOfTheDay(object sender, EventArgs e)
    {
        //App.Current.MainPage = new QuoteOfTheDay();
        Navigation.PushAsync(new QuoteOfTheDay());
    }

    private void Button_Holidays(object sender, EventArgs e)
    {
        //App.Current.MainPage = new Holidays();
        Navigation.PushAsync(new Holidays());

    }

    private void Button_Proverb(object sender, EventArgs e)
    {
        //App.Current.MainPage = new Proverb();
        Navigation.PushAsync(new Proverb());

    }

    private void Button_FortuneCookie(object sender, EventArgs e)
    {
        //App.Current.MainPage = new FortuneCookie();
        Navigation.PushAsync(new FortuneCookie());

    }
}