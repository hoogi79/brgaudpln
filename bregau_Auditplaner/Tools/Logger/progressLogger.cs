using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bregau_Auditplaner.Tools.Logger
{
    class progressLogger : iProgressLogger
    {
        private ToolStripProgressBar p_progressBar;
        private ToolStripStatusLabel p_statusLabel;

        /// <summary>
        /// Erzeugt einen Logger der Fortschrittsdaten annimmt.
        /// </summary>
        /// <param name="statusLabel">Ein Label-Steuerelement einer Statusbar zum Anzeigen von Nachrichten</param>
        /// <param name="progBar">Ein Progressbar-Steuerelement einer Statusbar für die Ausgabe</param>
        public progressLogger(ToolStripStatusLabel statusLabel, ToolStripProgressBar progBar)
        {
            if (statusLabel != null)
                this.p_statusLabel = statusLabel;
            else
                this.p_statusLabel = new ToolStripStatusLabel(); // Alternativ ein neues Objekt erzeugen (unsichtbar). Vermeidet bei Zuweisungen den Test auf Null
            if (progBar != null)
                this.p_progressBar = progBar;
            else
                this.p_progressBar = new ToolStripProgressBar(); // s.o.
        }

        public LogLevel LogLevel { get; set; }

        public event EventHandler LoggerClosed;

        public bool AppendMessage(LogMessage LogMessage)
        {
            bool retBool;
            if (retBool = LogMessage!=null)
                p_statusLabel.Text = LogMessage.Message;
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
            this.p_statusLabel.Text = "";
            this.p_progressBar.Value = 0;
        }

        public List<LogMessage> Log()
        {
            return new List<LogMessage>();
        }

        public bool Show(System.Windows.Forms.Form owner)
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

        public int Progress
        {
            get
            {
                return this.p_progressBar.Value;
            }

            set
            {
                if (value == -1) // Swtich to marquee mode
                {
                    this.p_progressBar.Style = ProgressBarStyle.Marquee;
                    return;
                }
                value = System.Math.Abs(value) % 100;
                this.p_progressBar.Style = ProgressBarStyle.Blocks;
                this.p_progressBar.Value = value;
            }
        }
    }
}
