namespace maui_efcore_pipeline_build.EFCore.Providers
{
    public class FilePathProvider : IFilePathProvider
    {
        public string GetFilePath()
        {
            return "Maui.db";
        }
    }
}
