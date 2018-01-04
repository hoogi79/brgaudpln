using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bregau_AuditplanerWPF.Tools.Logger
{
    class simpleLogger : iLogger
    {
        private List<LogMessage> listMessages = null;

        public LogLevel LogLevel { get; set; }

        public event EventHandler LoggerClosed;

        public bool AppendMessage(LogMessage LogMessage)
        {
            if (LogMessage != null)
            {
                listMessages.Add(LogMessage);
                return true;
            }
            else
                return false;
        }

        public bool AppendMessage(DateTime TimeStamp, string Message, LogLevel ll)
        {
            if (TimeStamp != null && Message != null && Message.Length > 0 && ll >= LogLevel)
                return this.AppendMessage(new LogMessage(TimeStamp, Message, ll));
            return false;
        }

        public void Clear()
        {
            listMessages.Clear();
        }

        public List<LogMessage> Log() => listMessages;
        

        /// <summary>
        /// Klassen Destruktor. Wird beim Löschen der Klasse aufgerufen.
        /// Falls das Ereignis einen Abonnenten hat (!=null), dann Ereignis auslösen.
        /// </summary>
        ~simpleLogger()
        {
            LoggerClosed?.Invoke(this, new EventArgs()); // Fragezeichen Operator prüft ober Variable "null" ist und macht weiter falls nicht. Neu in C# 6.0
        }

    }
}
