using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace bregau.AuditPlaner.Logic.UI.ViewModel
{
    public class BasicSettingsViewModel : BaseViewModel
    { 
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public BasicSettingsViewModel()
        {
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                // Code runs "for real"
            }
            OKCommand = new RelayCommand(
                () => { Trace.TraceInformation("OK"); },
                () => IsOK
                );
            ADServerAddress = "server2008.bregau.local";
        }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "ActiveDirectory-Serveradresse darf nicht leer sein.")]
        public string ADServerAddress { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "SQL-Serveradresse darf nicht leer sein.")]
        [Url(ErrorMessage ="SQL-Serveradresse muss eine URL sein.")]
        public string SQLServerAdress { get; set; }

        public RelayCommand OKCommand { get; private set; }
    }
}
