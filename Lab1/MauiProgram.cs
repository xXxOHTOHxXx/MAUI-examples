using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using SQLite;
using Lab3;
using Lab3.Services;
using Lab1.Services;
using System.Net.Http;
namespace Lab1;

public static class MauiProgram
{
    public static IServiceCollection services = new ServiceCollection();
    public static IDbService? dbService = new SQLiteService();
	public static IRateService? rateService = new RateService();
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
        services.AddTransient<IDbService, SQLiteService>();
		services.AddTransient<IRateService, RateService>();
//        builder.Services.AddHttpClient<IRateService>(opt =>
//opt.BaseAddress = “https://www.nbrb.by/api/exrates/rates”)
        builder.Services.AddTransient<lab3page>();
#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
