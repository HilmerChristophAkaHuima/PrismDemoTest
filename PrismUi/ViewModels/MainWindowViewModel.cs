using Prism.Mvvm;

namespace PrismUi.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "CEBP";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }
    }
}
