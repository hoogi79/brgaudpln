using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace bregau_AuditplanerWPF.ViewModel
{
    public class LogViewModel : ViewModelBase
    {

        private Tools.Logger.iLogger p_Logger = null;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public LogViewModel(Tools.Logger.iLogger logger)
        {
            if (logger != null)
                p_Logger = logger;
            else
                p_Logger = new Tools.Logger.simpleLogger();
        }

        public string LogText => p_Logger.ToString();
        
    }
}
