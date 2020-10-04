using System;
using System.Collections.Generic;
using System.Text;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace ModuleTest.ViewModels
{
    public class TestViewModel : BindableBase, INavigationAware
    {
        private string _title = "Hello from TestViewModel";

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private bool _canExecute = false;

        public bool CanExecute
        {
            get => _canExecute;
            set
            {
                SetProperty(ref _canExecute, value);

                //ClickMeCommand.RaiseCanExecuteChanged();
            }
        }

        private int _pageViews;

        public int PageViews
        {
            get => _pageViews;
            set => SetProperty(ref _pageViews, value);
        }

        private string _navUri;

        public string NavUri
        {
            get => _navUri;
            set => SetProperty(ref _navUri, value);
        }

        public int ClickCount { get; private set; }

        public DelegateCommand ClickMeCommand { get; set; }

        public TestViewModel()
        {
            ClickMeCommand = new DelegateCommand(ClickMe)
                //.ObservesProperty(() => CanExecute);
                .ObservesCanExecute(() => CanExecute);
            ClickCount = 0;
        }

        //Needed for ObservesProperty or RaiseCanExecuteChanged
        //private bool CanClick()
        //{
        //    return CanExecute;
        //}

        private void ClickMe()
        {

            ClickCount++;
            Title = $"You clicked me {ClickCount} times.";
            if (ClickCount > 9)
            {
                CanExecute = false;
            }
            
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            PageViews++;
            if (navigationContext.Parameters.ContainsKey("NavUri"))
            {
                NavUri = navigationContext.Parameters.GetValue<string>("NavUri");
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}
