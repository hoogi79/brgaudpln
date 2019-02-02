namespace bregau.AuditPlaner.UI.Desktop
{
    using GalaSoft.MvvmLight.Messaging;
    using Logic.UI.Messages;
    using Logic.UI.ViewModel;
    using System.Windows;


    /// <summary>
    /// Central listenere for all messages of the app.
    /// </summary>
    public class MessageListener
    {
        #region constructors and destructors

        public MessageListener()
        {
            InitMessenger();
        }

        #endregion

        #region methods

        /// <summary>
        /// Is called by the constructor to define the messages we are interested in.
        /// </summary>
        private void InitMessenger()
        {
            // Hook to the message that states that some caller wants to open a ChildWindow.
            Messenger.Default.Register<OpenSettingsWindow>(
                this,
                msg =>
                {
                    var window = new BasicSettingsWindow();
                    var model = window.DataContext as BasicSettingsViewModel;
                    window.ShowDialog();
                });

            // Hook to the application shutdown request from Logic
            Messenger.Default.Register<NotificationMessage>(
                this,
                msg =>
                {
                    if (msg.Notification == Notifications.RequestImmediateShutdown)
                        Application.Current.Shutdown();
                });
        }

        #endregion

        #region properties

        /// <summary>
        /// We need this property so that this type can be put into the ressources.
        /// </summary>
        public bool BindableProperty => true;

        #endregion
    }
}
