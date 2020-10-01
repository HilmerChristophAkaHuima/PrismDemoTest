using System;
using System.Collections.Generic;
using System.Text;
using Prism.Commands;
using Prism.Mvvm;
using PrismUI.Core.Commands;

namespace ModuleTest.ViewModels
{
    public class SecondViewModel : BindableBase
    {
        private string _title;

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private bool _canUpdate;

        public bool CanUpdate
        {
            get => _canUpdate;
            set => SetProperty(ref _canUpdate, value);
        }

        private string _updateText;

        public string UpdateText
        {
            get => _updateText;
            set => SetProperty(ref _updateText, value);
        }

        public DelegateCommand UpdateCommand { get; private set; }

        public SecondViewModel(IApplicationCommands applicationCommands)
        {
            UpdateCommand = new DelegateCommand(Update).ObservesCanExecute(() => CanUpdate);
            applicationCommands.SaveAllCommand.RegisterCommand(UpdateCommand);
        }

        private void Update()
        {
            UpdateText = $"Update Date: {DateTime.Now}";
        }
    }
}
