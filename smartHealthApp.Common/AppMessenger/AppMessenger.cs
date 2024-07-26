using GalaSoft.MvvmLight.Messaging;
using smartHealthApp.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartHealthApp.Common.AppMessenger
{
    public static class AppMessenger
    {
        public static void Register(object recipient, Action<AppMessage> action)
        {
            Messenger.Default.Register<AppMessage>(recipient, action);
        }

        public static void Unregister(object recipient, Action<AppMessage> action)
        {
            Messenger.Default.Unregister<AppMessage>(recipient, action);
        }

        public static void Send(AppMessage message)
        {
            Messenger.Default.Send<AppMessage>(message);
        }

        public static void Navigate(NavigationPages NavigationTarget, Dictionary<String, Object> NavigationData = null, Transition? transition = null)
        {
            Send(new AppMessage() { MessageType = AppMessageType.Navigate, MessageData = new NavigationMessageData() { NavigationTarget = NavigationTarget, NavigationData = NavigationData, Transition = transition } });
        }

        public static void Close(NavigationPages NavigationTarget)
        {
            Send(new AppMessage() { MessageType = AppMessageType.Close, MessageData = new NavigationMessageData() { NavigationTarget = NavigationTarget } });
        }

       
    }
}
