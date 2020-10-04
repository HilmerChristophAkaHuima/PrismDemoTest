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
        private readonly MessageSentEvent _event;

        private SubscriptionToken _subscriptionToken;

        private ObservableCollection<string> _messages = new ObservableCollection<string>();

        public ObservableCollection<string> Messages
        {
            get => _messages;
            set => SetProperty(ref _messages, value);
        }

        private bool _isSubscribed;

        public bool IsSubscribed
        {
            get => _isSubscribed;
            set
            {
                SetProperty(ref _isSubscribed, value);
                //HandleSubscribe(_isSubscribed);
                HandleSubscribeToken(_isSubscribed);
            }
        }

        public ReceivedOutputListViewModel(IEventAggregator eventAggregator)
        {
            _event = eventAggregator.GetEvent<MessageSentEvent>();
            IsSubscribed = true;
        }

        private void HandleSubscribe(in bool isSubscribed)
        {
            if (isSubscribed)
            {
                _event.Subscribe(OnMessageReceived, ThreadOption.PublisherThread, false, message => !message.Contains("fuck", StringComparison.CurrentCultureIgnoreCase));
            }
            else
            {
                _event.Unsubscribe(OnMessageReceived);
            }

        }
        private void HandleSubscribeToken(in bool isSubscribed)
        {
            if (isSubscribed)
            {
                _subscriptionToken = _event.Subscribe(OnMessageReceived, ThreadOption.PublisherThread, false, message => !message.Contains("fuck", StringComparison.CurrentCultureIgnoreCase));
            }
            else
            {
                _event.Unsubscribe(_subscriptionToken);
            }

        }

        private void OnMessageReceived(string message)
        {
            Messages.Add(message);
        }
    }
}
