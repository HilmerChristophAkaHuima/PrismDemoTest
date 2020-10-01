using System;
using System.Collections.Generic;
using System.Text;
using Prism.Commands;
using Prism.Mvvm;

namespace ModuleTest.ViewModels
{
    public class TestViewModel : BindableBase
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

        public int ClickCount { get; private set; }

        public DelegateCommand ClickMeCommand { get; set; }

        public TestViewModel()
        {
            ClickMeCommand = new DelegateCommand(ClickMe)
                //.ObservesProperty(() => CanExecute);
                .ObservesCanExecute(() => CanExecute);
            ClickCount = 0;
        }

        //Needed for ObservesProperty or RaisCanExecuteChanged
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
    }
}
