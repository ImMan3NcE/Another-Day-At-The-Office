namespace ADATO.MVVM.Views;

public partial class Proverb : ContentPage
{
    List<string> proverbdays = new List<string>();




    public Proverb()
    {
        InitializeComponent();
    }

    #region Wyswietlanie danych

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        EndSpeechBack();
    }
    protected override async void OnAppearing()
    {
        int numOfTodayDay1 = datePickerNameDay.Date.DayOfYear;


        base.OnAppearing();
        await LoadMauiAsset();



        proverbs.Text = proverbdays[numOfTodayDay1-1];
        proverbs1.Text = proverbdays[881 - numOfTodayDay1];



    }
    private void datePickerNameDay_DateSelected(object sender, DateChangedEventArgs e)
    {
        LoadMauiAsset();
        int numOfTodayDay = datePickerNameDay.Date.DayOfYear;



        proverbs.Text = proverbdays[numOfTodayDay-1];
        proverbs1.Text = proverbdays[881 - numOfTodayDay];
    }


    async Task LoadMauiAsset()
    {
        proverbdays.Clear();

        int year = datePickerNameDay.Date.Year;


        if (DateTime.IsLeapYear(year))
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("ProverbsW29.txt");
            using var reader = new StreamReader(stream);

            while (reader.Peek() != -1)
            {
                proverbdays.Add(reader.ReadLine());

            }

        }
        else
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("ProverbsWO29.txt");
            using var reader = new StreamReader(stream);

            while (reader.Peek() != -1)
            {
                proverbdays.Add(reader.ReadLine());

            }

        }


    }
    #endregion

    #region Obsluga przycisków
    private void Button_Clicked(object sender, EventArgs e)
    {
        EndSpeechBack();
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

    #region Text na mowe

    CancellationTokenSource cts;
    private async void StartSpeech(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(proverbs.Text))
        {
            cts = new CancellationTokenSource();

            PlayText.IsVisible = false;
            EndText.IsVisible = true;

            await TextToSpeech.Default.SpeakAsync(proverbs.Text.ToString(), cancelToken: cts.Token);
            if (cts?.IsCancellationRequested ?? true)
            {
                PlayText.IsVisible = true;
                EndText.IsVisible = false;
                return;
            }    
            else if(!string.IsNullOrEmpty(proverbs1.Text))
                await TextToSpeech.Default.SpeakAsync(proverbs1.Text.ToString(), cancelToken: cts.Token);

            PlayText.IsVisible = true;
            EndText.IsVisible = false;
        }
    }

    private void EndSpeech(object sender, EventArgs e)
    {
        EndSpeechBack();
    }
    public void EndSpeechBack()
    {
        if (cts?.IsCancellationRequested ?? true)
            return;

        cts.Cancel();
    }


    #endregion

}