using maui_efcore_pipeline_build.EFCore.Providers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace maui_efcore_pipeline_build.EFCore.Contexts
{
    /// <summary>
    /// Migrations:
    /// cd .\EntityFramework
    /// dotnet ef migrations add InitialMigration
    /// dotnet ef database update
    /// dotnet ef migrations remove
    /// </summary>
    public class MauiDbContextFactory : IDesignTimeDbContextFactory<MauiDbContext>
    {
        private readonly IFilePathProvider dbPathProvider;

        public MauiDbContextFactory() : this(new FilePathProvider()) { }

        private MauiDbContextFactory(IFilePathProvider filePathProvider)
        {
            this.dbPathProvider = filePathProvider;
        }

        public MauiDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MauiDbContext>();
            optionsBuilder
                .UseSqlite($"Data Source={dbPathProvider.GetFilePath()}");

            return new MauiDbContext(optionsBuilder.Options);
        }
    }
}
