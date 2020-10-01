using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
