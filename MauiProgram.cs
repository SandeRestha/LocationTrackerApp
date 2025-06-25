using Microsoft.Maui;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Maps;

namespace HeatMapApp
{
    public static class MauiProgram
    {
        // This method configures and returns the main MAUI application instance.
        public static MauiApp CreateMauiApp()
        {
            // Create a new MAUI App builder instance.
            var builder = MauiApp.CreateBuilder();

            // Set the root application class.
            builder
                .UseMauiApp<App>()

                // Enable support for .NET MAUI Maps (required for heatmap feature).
                .UseMauiMaps()

                // Configure application fonts (used throughout UI, if needed).
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");     // Regular font
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");   // Semibold font
                });

            // Build and return the configured MAUI app.
            return builder.Build();
        }
    }
}
