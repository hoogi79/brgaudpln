using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bregau_Auditplaner.Tools.Logger
{
    public partial class simpleLoggerForm : Form, iLogger
    {
        private List<LogMessage> logMessages = null;

        public simpleLoggerForm()
        {
            InitializeComponent();
            LogLevel = LogLevel.Error;
            logMessages = new List<LogMessage>();
        }

        public LogLevel LogLevel { get; set; }

        public event EventHandler LoggerClosed;

        public bool AppendMessage(LogMessage LogMessage)
        {
            if (LogMessage != null && LogMessage.Level>=LogLevel)
            {
                logMessages.Add(LogMessage);
                this.txtLog.AppendText(LogMessage.ToString());
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
            logMessages = new List<LogMessage>();
            this.txtLog.Clear();
        }

        public List<LogMessage> Log()
        {
            return logMessages;
        }

        bool iLogger.Show(System.Windows.Forms.Form owner)
        {
            if (this.Visible == false)
            {
                this.MdiParent = owner;
                this.Show();
            }
            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.Clear();
        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~simpleLoggerForm()
        {
           LoggerClosed?.Invoke(this, new EventArgs());
        }


        /// <summary>
        /// Das Ereignis wird beim Schließen des Fensters ausgelöst. Der Code verhindert das Schließen/Zerstören und setzt es stattdessen auf unsichtbar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleLoggerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sender == this)
            { 
            e.Cancel = true;
            this.Hide();
            }
        }
    }
}
