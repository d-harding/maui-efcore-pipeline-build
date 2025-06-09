using maui_efcore_pipeline_build.EFCore.Contexts;

namespace maui_efcore_pipeline_build
{
    public partial class App : Application
    {
        public App(IMauiDbContext mauiDbContext)
        {
            if (!mauiDbContext.Migrate())
            {
                //TODO: Error
            }

            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}