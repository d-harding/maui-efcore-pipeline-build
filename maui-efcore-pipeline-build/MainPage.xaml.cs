using maui_efcore_pipeline_build.EFCore.Contexts;
using maui_efcore_pipeline_build.EFCore.Models.Audit;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace maui_efcore_pipeline_build
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private readonly IMauiDbContext _mauiDbContext;

        public ICommand AddErrorLogCommand { get; }

        public MainPage(IMauiDbContext mauiDbContext)
        {
            _mauiDbContext = mauiDbContext;

            AddErrorLogCommand = new Command(() => AddErrorLog());

            InitializeComponent();
            BindingContext = this;
        }

        override protected void OnAppearing()
        {
            base.OnAppearing();
            LoadErrorLogs();
        }

        private void AddErrorLog()
        {
            var errorLog = new ErrorLog
            {
                Message = $"Error log at {DateTime.Now}",
                StackTrace = $"{DateTime.Now} - Stack Trace details..."
            };

            _mauiDbContext.ErrorLogs.Add(errorLog);
            _mauiDbContext.SaveChanges();

            ErrorLogs.Add(errorLog);

            LoadErrorLogs();
        }

        private void LoadErrorLogs()
        {
            var logs = _mauiDbContext.ErrorLogs.ToList();

            ErrorLogs.Clear();
            foreach (var log in logs)
            {
                ErrorLogs.Add(log);
            }
        }

        private ObservableCollection<ErrorLog> _errorLogs = new ObservableCollection<ErrorLog>();
        public ObservableCollection<ErrorLog> ErrorLogs
        {
            get => _errorLogs;
            set
            {
                _errorLogs = value;
                OnPropertyChanged(nameof(ErrorLogs));
            }
        }

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }

}
