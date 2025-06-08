using maui_efcore_pipeline_build.EFCore.Contexts;
using maui_efcore_pipeline_build.EFCore.Providers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace maui_efcore_pipeline_build
{
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

            #region EFCore DB

            builder.Services.AddDbContext<MauiDbContext>((serviceProvider, options) =>
            {
                string folder = FileSystem.AppDataDirectory;
                Directory.CreateDirectory(folder);

                var filePathProvider = serviceProvider.GetRequiredService<IFilePathProvider>();
                var dbPath = Path.Combine(folder, filePathProvider.GetFilePath());

                options.UseSqlite($"Data Source={dbPath}");
            });

            builder.Services.AddSingleton<IFilePathProvider, FilePathProvider>();
            builder.Services.AddSingleton<IMauiDbContext, MauiDbContext>();

            #endregion

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
