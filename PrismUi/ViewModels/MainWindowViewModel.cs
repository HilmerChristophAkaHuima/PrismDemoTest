using ModuleTest.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PrismUI.Core.Commands;

namespace PrismUi.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
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

        public DelegateCommand<string> NavigateCommand { get; set; }

        public MainWindowViewModel(IApplicationCommands applicationCommands, IRegionManager regionManager)
        {
            _regionManager = regionManager;
            _regionManager.RegisterViewWithRegion("NavContentRegion", typeof(TestView));
            ApplicationCommands = applicationCommands;
            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        private void Navigate(string uri)
        {
            var p = new NavigationParameters();
            p.Add("NavUri", uri);
            _regionManager.RequestNavigate("NavContentRegion", uri, p);
        }
    }
}
