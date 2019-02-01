using System.Windows;
using bregau.AuditPlaner.Logic.UI.Messages;
using GalaSoft.MvvmLight.Messaging;

namespace bregau.AuditPlaner.Logic.UI.Helpers
{
    class ShutdownService
    {
        public static void RequestShutdown()
        {
            var shouldAbortShutdown = false;

            Messenger.Default.Send(new NotificationMessageAction<bool>(
                Notifications.ConfirmShutdown,
                shouldAbort => shouldAbortShutdown |= shouldAbort));

            if (!shouldAbortShutdown)
            {
                // This time it is for real
                Messenger.Default.Send(new NotificationMessage(Notifications.NotifyShutdown));

                Messenger.Default.Send(new NotificationMessage(Notifications.RequestImmediateShutdown));
            }
        }
    }
}
