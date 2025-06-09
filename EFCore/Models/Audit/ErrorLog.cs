namespace maui_efcore_pipeline_build.EFCore.Models.Audit
{
    public class ErrorLog : EntityBase
    {
        //public string? Source { get; set; }
        //public string Device { get; set; }
        public string Message { get; set; }
        public string? StackTrace { get; set; }
        //public string? HelpLink { get; set; }
        //public DateTimeOffset? Synced { get; set; }
    }
}
