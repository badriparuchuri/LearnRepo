using Calculator.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator;

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
			});

		builder.Services.AddSingleton<HistoryPage>();
        builder.Services.AddSingleton<HistoryViewModel>();
        builder.Services.AddSingleton<DatabaseService>();


        return builder.Build();
	}
}
