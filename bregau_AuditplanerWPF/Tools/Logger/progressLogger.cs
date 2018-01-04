using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bregau_AuditplanerWPF.Tools.Logger
{
    class progressLogger : iProgressLogger
    {
        private System.Windows.Controls.ProgressBar p_progressBar;
        private System.Windows.Controls.Label p_statusLabel;
        private System.Timers.Timer p_showTimer;

        /// <summary>
        /// Erzeugt einen Logger der Fortschrittsdaten annimmt.
        /// </summary>
        /// <param name="statusLabel">Ein Label-Steuerelement einer Statusbar zum Anzeigen von Nachrichten</param>
        /// <param name="progBar">Ein Progressbar-Steuerelement einer Statusbar für die Ausgabe</param>
        /// <param name="displayDuration">Die Zeitspanne (in Millisekunden) in der die Meldung in der Statusleiste angezeigt werden soll. Werte kleiner/gleich Null für unendlich </param>
        public progressLogger(System.Windows.Controls.Label statusLabel, System.Windows.Controls.ProgressBar progBar, int displayDuration)
        {
            if (statusLabel != null)
                this.p_statusLabel = statusLabel;
            else
                this.p_statusLabel = new System.Windows.Controls.Label(); // Alternativ ein neues Objekt erzeugen (unsichtbar). Vermeidet bei Zuweisungen den Test auf Null
            if (progBar != null)
                this.p_progressBar = progBar;
            else
                this.p_progressBar = new System.Windows.Controls.ProgressBar(); // s.o.

            // Timereinstellungen zum zeitgestuerten Löschen der Nachrichten
            if (displayDuration > 0)
            {
                p_showTimer = new System.Timers.Timer(displayDuration);
                p_showTimer.Stop();
                p_showTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnStatusTimer);
            }
            
        }

        public LogLevel LogLevel { get; set; }

        public event EventHandler LoggerClosed;

        public bool AppendMessage(LogMessage LogMessage)
        {
            bool retBool;
            if (retBool = LogMessage != null)
                displayStatusText(LogMessage.Message);
            return retBool;
        }

        public bool AppendMessage(DateTime TimeStamp, string Message, LogLevel ll)
        {
            if (TimeStamp != null && Message != null && Message.Length > 0 && ll >= LogLevel)
                return this.AppendMessage(new LogMessage(TimeStamp, Message, ll));
            return false;
        }

        public void Clear()
        {
            this.p_statusLabel.Content = "";
            this.p_progressBar.Value = 0;
        }

        public List<LogMessage> Log()
        {
            return new List<LogMessage>();
        }

        public bool Show(System.Windows.Window owner)
        {
            return false; // Kann nicht angezeigt werden
        }

        /// <summary>
        /// Klassen Destruktor. Wird beim Löschen der Klasse aufgerufen.
        /// Falls das Ereignis einen Abonnenten hat (!=null), dann Ereignis auslösen.
        /// </summary>
        ~progressLogger()
        {
            LoggerClosed?.Invoke(this, new EventArgs()); // Fragezeichen Operator prüft ober Variable "null" ist und macht weiter falls nicht. Neu in C# 6.0
        }

        public double Progress
        {
            get
            {
                return this.p_progressBar.Value;
            }

            set
            {
                if (value == -1) // Switch to marquee mode
                {
                    this.p_progressBar.IsIndeterminate = true;
                    return;
                }
                value = System.Math.Abs(value) % 100;
                this.p_progressBar.IsIndeterminate = false;
                //this.p_progressBar.Style = ProgressBarStyle.Blocks;
                this.p_progressBar.Value = value;
            }
        }

        private void displayStatusText(string text)

        {
            if (p_statusLabel != null)
            {
                p_showTimer.Stop();
                p_showTimer.Interval = 10000;
                p_showTimer.Start();
            }
            p_statusLabel.Content = text;
        }

        /// <summary>
        /// Ereignisbehandlung wenn Timer ausläuft.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        private void OnStatusTimer(object source, System.Timers.ElapsedEventArgs args)
        {
            p_showTimer.Stop();
            p_statusLabel.Content = "";
        }
    }
}
