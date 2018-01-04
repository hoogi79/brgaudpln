using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace bregau_AuditplanerWPF.Tools.Logger
{
    class nullLogger : iLogger
    {
        public LogLevel LogLevel { get; set; }
          
        public event EventHandler LoggerClosed;

        public bool AppendMessage(LogMessage LogMessage)
        {
            return true;
        }

        public bool AppendMessage(DateTime TimeStamp, string Message, LogLevel ll)
        {
            return true;
        }

        public void Clear() {}

        public List<LogMessage> Log()
        {
            return new List<LogMessage>();
        }

        public bool Show(Window owner)
        {
            return true;
        }
    }
}
