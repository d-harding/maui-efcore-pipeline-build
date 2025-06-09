using maui_efcore_pipeline_build.EFCore.Models.Audit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace maui_efcore_pipeline_build.EFCore.Contexts
{
    public class MauiDbContext : DbContext, IMauiDbContext
    {
        public MauiDbContext(DbContextOptions<MauiDbContext> options) : base(options)
        {
            SQLitePCL.Batteries_V2.Init();
        }

        public bool Migrate()
        {
            try
            {
                this.Database.Migrate();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DatabaseFacade Database => new DatabaseFacade(this);

        public int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DbSet<ErrorLog> ErrorLogs { get; set; }
    }
}