using System.ComponentModel.DataAnnotations;

namespace maui_efcore_pipeline_build.EFCore.Models
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }

        public DateTimeOffset DateTime { get; set; } = DateTimeOffset.UtcNow;
    }
}
