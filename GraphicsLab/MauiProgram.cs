using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using GraphicsLab.MVVM.View;
using Microsoft.Extensions.Logging;
using Mopups.Hosting;
using Mopups.Interfaces;
using Mopups.Services;
using SkiaSharp.Views.Maui.Controls.Hosting;
using UraniumUI;
using Xceed.Maui.Toolkit;

namespace GraphicsLab
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseUraniumUIMaterial()
                .UseSkiaSharp()
                .UseXceedMauiToolkit()
                .ConfigureMopups()
                .ConfigureAnimations()
                .UseMauiCommunityToolkit()
                .UseMauiCommunityToolkitCore()
                .UseUraniumUIBlurs()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("SpaceGrotesk-Bold.ttf", "SpaceGroteskBold");
                    fonts.AddFont("SpaceGrotesk-Light.ttf", "SpaceGroteskLight");
                    fonts.AddFont("SpaceGrotesk-Medium.ttf", "SpaceGroteskMedium");
                    fonts.AddFont("SpaceGrotesk-Regular.ttf", "SpaceGroteskRegular");
                    fonts.AddFont("SpaceGrotesk-SemiBold.ttf", "SpaceGroteskSemiBold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<IPopupNavigation>(MopupService.Instance);
            builder.Services.AddTransient<MainPage>();
            return builder.Build();
        }
    }
}
