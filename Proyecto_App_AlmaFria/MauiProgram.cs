using Microsoft.Extensions.Logging;
using Proyecto_App_AlmaFria.Services;
using SkiaSharp.Views.Maui.Controls.Hosting;


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


#if DEBUG
			builder.Logging.AddDebug();

#endif
			return builder.Build();
		}
	}
}
