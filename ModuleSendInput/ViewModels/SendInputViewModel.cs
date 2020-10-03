using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using PrismUI.Core.Events;

namespace ModuleSendInput.ViewModels
{
    public class SendInputViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        private string _inputText = "Hello from SendInputModule";

        public string InputText
        {
            get => _inputText;
            set
            {
                SetProperty(ref _inputText, value);
                CanSendInput = value.Length > 0;
            }
        }

        private bool _canSendInput = true;

        public bool CanSendInput
        {
            get => _canSendInput;
            set => SetProperty(ref _canSendInput, value);
        }

        public DelegateCommand SendCommand { get; set; }

        public SendInputViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            SendCommand = new DelegateCommand(SendInput).ObservesCanExecute(() => CanSendInput);
        }

        private void SendInput()
        {
            _eventAggregator.GetEvent<MessageSentEvent>().Publish(InputText);
        }
    }
}
