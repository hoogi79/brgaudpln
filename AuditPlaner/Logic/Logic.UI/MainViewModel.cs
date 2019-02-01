using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Diagnostics;

namespace bregau.AuditPlaner.Logic.UI.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
                DynamicWindowTitle = "(Design Time)" + " " + WindowTitle;
            }  
            else
            {
                // Code runs "for real"
                //DynamicWindowTitle = WindowTitle;
                //System.Timers.Timer tmr = new System.Timers.Timer(100);
                //tmr.Elapsed += (s, e) => { Progress += 1; };
                //tmr.Enabled = true;

                //this.PropertyChanged += (s, e) =>
                //{
                //    if (e.PropertyName == "Progress" && Progress == 100)
                //        Progress = 0;
                //};
                Einstellungen = new RelayCommand(() =>
                {
                    MessengerInstance.Send(new Messages.OpenSettingsWindow());
                });

                Verbinden = new RelayCommand(
                    () =>
                    {
                        Trace.TraceInformation("Verbinden ...");
                    },
                    () => CanConnect);

                Beenden = new RelayCommand(() => Helpers.ShutdownService.RequestShutdown());


            }
        }


        public int Progress { get; set; } = 0;

        public bool CanConnect { get; private set; } = false;

        public string WindowTitle { get; set; } = "AuditLog";
        public string DynamicWindowTitle { get; private set;}

        public RelayCommand Einstellungen { get; private set; }
        public RelayCommand Verbinden { get; private set; }
        public RelayCommand Beenden { get; private set; }

    }
}