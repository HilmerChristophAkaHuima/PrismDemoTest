using System;
using System.Collections.Generic;
using System.Text;
using Prism.Mvvm;

namespace ModuleTest.ViewModels
{
    public class SecondViewModel : BindableBase
    {
        private string _text = "Hello from SecondViewModel";

        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }
    }
}
