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

        public int ClickCount { get; private set; }

        public DelegateCommand ClickMeCommand { get; set; }

        public TestViewModel()
        {
            ClickMeCommand = new DelegateCommand(ClickMe, CanClick);
            ClickCount = 0;
        }

        private bool CanClick()
        {
            return ClickCount < 10;
        }

        private void ClickMe()
        {
            ClickCount++;
            Title = $"You clicked me {ClickCount} times.";
        }
    }
}
