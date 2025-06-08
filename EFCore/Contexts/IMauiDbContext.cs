using maui_efcore_pipeline_build.EFCore.Models.Audit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace maui_efcore_pipeline_build.EFCore.Contexts
{
    public interface IMauiDbContext
    {
        public DatabaseFacade Database { get; }

        int SaveChanges();

        #region Entities

        DbSet<ErrorLog> ErrorLogs { get; set; }

        #endregion
    }
}
