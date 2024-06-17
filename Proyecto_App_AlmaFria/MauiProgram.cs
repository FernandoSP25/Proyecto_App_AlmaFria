using Microsoft.Extensions.Logging;
using Proyecto_App_AlmaFria.MVVM.ViewModels;
using Proyecto_App_AlmaFria.Services;
using Proyecto_App_AlmaFria.Views;
using SkiaSharp.Views.Maui.Controls.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http; 

namespace Proyecto_App_AlmaFria
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.UseSkiaSharp()

				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
					fonts.AddFont("arial_narrow_7.ttf", "Arial7");
					fonts.AddFont("OpenSerif-Book.ttf", "OpenSerif");
					fonts.AddFont("Nexa-ExtraLight.ttf", "NexaLight");
					fonts.AddFont("Nexa-Heavy.ttf", "NexaHeavy");
				});

			// Registro del servicio AuthService con HttpClient
			//builder.Services.AddHttpClient<AuthService>(client =>
			//{
			//	client.BaseAddress = new Uri("https://localhost:7274/");
			//});

			// Registrar ViewModel y Pages
			builder.Services.AddTransient<LoginViewModel>();
			builder.Services.AddTransient<LoginPage>();

#if DEBUG
			builder.Logging.AddDebug();
#endif
			return builder.Build();
		}
	}
}
