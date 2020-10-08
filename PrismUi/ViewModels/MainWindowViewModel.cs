using ModuleTest.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PrismUI.Core.Commands;
using PrismUI.Core.Services;

namespace PrismUi.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IOpenFileDialogService _openFileDialogService;
        private string _title = "CEBP";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private IApplicationCommands _applicationCommands;

        public IApplicationCommands ApplicationCommands
        {
            get { return _applicationCommands; }
            set { SetProperty(ref _applicationCommands, value); }
        }

        private string _openFileDialogPath;

        public string OpenFileDialogPath
        {
            get => _openFileDialogPath;
            set => SetProperty(ref _openFileDialogPath, value);
        }

        public DelegateCommand<string> NavigateCommand { get; set; }

        public DelegateCommand OpenFileDialogCommand { get; set; }

        public MainWindowViewModel(IApplicationCommands applicationCommands, IRegionManager regionManager, IOpenFileDialogService openFileDialogService)
        {
            _regionManager = regionManager;
            _openFileDialogService = openFileDialogService;
            _regionManager.RegisterViewWithRegion("NavContentRegion", typeof(TestView));
            ApplicationCommands = applicationCommands;
            NavigateCommand = new DelegateCommand<string>(Navigate);
            OpenFileDialogCommand = new DelegateCommand(OpenFileDialog);
        }

        private void OpenFileDialog()
        {
            _openFileDialogService.ShowDialog();
            OpenFileDialogPath = _openFileDialogService.OpenFileDialog.FileName;
        }

        private void Navigate(string uri)
        {
            var p = new NavigationParameters();
            p.Add("NavUri", uri);
            _regionManager.RequestNavigate("NavContentRegion", uri, p);
        }
    }
}
