using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Prism.Events;
using Prism.Mvvm;
using PrismUI.Core.Events;

namespace ModuleReceiveOutput.ViewModels
{
    public class ReceivedOutputListViewModel : BindableBase
    {
        private ObservableCollection<string> _messages = new ObservableCollection<string>();

        public ObservableCollection<string> Messages
        {
            get => _messages;
            set => SetProperty(ref _messages, value);
        }

        public ReceivedOutputListViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<MessageSentEvent>().Subscribe(OnMessageReceived, ThreadOption.PublisherThread, false, message => !message.Contains("fuck"));
        }

        private void OnMessageReceived(string message)
        {
            Messages.Add(message);
        }
    }
}
