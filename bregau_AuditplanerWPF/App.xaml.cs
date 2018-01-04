using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using bregau_AuditplanerWPF.Tools.Logger;

namespace bregau_AuditplanerWPF
{

    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// 
        /// </summary>
        public multiLogManager LogManager { get; protected set; } = new multiLogManager();

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            LogManager.Add(new simpleLogger() { LogLevel = Tools.Logger.LogLevel.Info });

            //Program.mainLogger.Add(new Tools.Logger.progressLogger(this.toolStripStatusLabel1, this.toolStripProgressBar1, 10000));
        }
    }
}
