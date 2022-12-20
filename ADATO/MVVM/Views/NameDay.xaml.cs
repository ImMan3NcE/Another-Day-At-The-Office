

namespace ADATO.MVVM.Views;

public partial class NameDay : ContentPage
{
    List<string> namedays = new List<string>();
    public NameDay()
	{
		InitializeComponent();
       
	}

    #region Wyswietlanie danych

    

    protected override async void OnAppearing()
    {
        int numOfTodayDay1 = datePickerNameDay.Date.DayOfYear;

        base.OnAppearing();
        await LoadMauiAsset();
        names.Text = namedays[numOfTodayDay1 - 1];


    }
    private void datePickerNameDay_DateSelected(object sender, DateChangedEventArgs e)
    {
        LoadMauiAsset();

        int numOfTodayDay = datePickerNameDay.Date.DayOfYear;

        names.Text = namedays[numOfTodayDay - 1];
    }


    async Task LoadMauiAsset()
    {
        namedays.Clear();

        
        int year = datePickerNameDay.Date.Year;


        if (DateTime.IsLeapYear(year))
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("NameDays.txt");
            using var reader = new StreamReader(stream);

            while (reader.Peek() != -1)
            {
                namedays.Add(reader.ReadLine());

            }

        }
        else
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("NameDaysWO29Feb.txt");
            using var reader = new StreamReader(stream);

            while (reader.Peek() != -1)
            {
                namedays.Add(reader.ReadLine());

            }

        }


    }
    #endregion


    #region Obsluga przycisków

    
    private void Button_Clicked(object sender, EventArgs e)
    {
        //App.Current.MainPage = new MainView();
        Navigation.PopAsync();
    }

    private void Button_Next(object sender, EventArgs e)
    {
        datePickerNameDay.Date = datePickerNameDay.Date.AddDays(1);
    }
    private void Button_Previous(object sender, EventArgs e)
    {
        datePickerNameDay.Date = datePickerNameDay.Date.AddDays(-1);
    }
    #endregion

    //Udostêpnianie widoku
    #region Udostepnianie



    private void Button_Share(object sender, EventArgs e)
    {
        PreviousDay.IsVisible = false;
        NextDay.IsVisible = false;
        TitleText.Text = "Another Day at The Office";
        
        ScreenShare();
        TitleText.Text = "";
        TitleText.TextColor = TitleText.TextColor;
        PreviousDay.IsVisible = true;
        NextDay.IsVisible = true;
    }
   

    public async void ScreenShare()
    {
        
        //VisibleValue();
        var result = await GridScreenShare.CaptureAsync();

        using MemoryStream memoryStream = new MemoryStream();

        await result.CopyToAsync(memoryStream);


        string fullPath = Path.Combine(FileSystem.Current.AppDataDirectory, "screen.png");

        File.WriteAllBytes(fullPath, memoryStream.ToArray());



        await Share.Default.RequestAsync(new ShareFileRequest
        {
            File = new ShareFile(fullPath),


        });

        //VisibleValue();
    }
    #endregion
}