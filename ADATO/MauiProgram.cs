namespace ADATO;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Bangers-Regular.ttf", "TitleBanger");
                fonts.AddFont("Caveat-VariableFont_wght.ttf", "TextCaveat");
            });

		return builder.Build();
	}
}
