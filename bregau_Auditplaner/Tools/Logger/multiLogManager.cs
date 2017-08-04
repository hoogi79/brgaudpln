using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bregau_Auditplaner.Tools.Logger
{
    /// <summary>
    /// Der multLogManager erlaubt es mehrere unterschiedliche Logger zu verwenden.
    /// Dies kann beispielsweise parallel ein Log-Fenster, ein Datei-Logger und 
    /// eine Status-Logbar sein. Die einzelnen Instanzen eines die Schnittstellen iLogger 
    /// implementierenden Loggers können dem multiLogManager über Add bzw. Remove hinzugefügt bzw. entfernt werden. 
    /// </summary>
    class multiLogManager : iProgressLogger
    {
        private List<iLogger> p_loggers = new List<iLogger>();
        private int p_progress = 0;
        private bool p_containsProgressLogger = false;

        /// <summary>
        /// Fügt dem LogManager einen Logger hinzu
        /// </summary>
        /// <param name="iLog">Die Instanz des Loggers</param>
        public void Add(iLogger iLog)
        {
            this.p_loggers.Add(iLog);
            if (this.p_containsProgressLogger == false && iLog is iProgressLogger)
                this.p_containsProgressLogger = true;
        }

        /// <summary>
        /// Entfernt einen bestimmten Logger vom multiLogManager
        /// </summary>
        /// <param name="iLog">Die Instanz des Loggers</param>
        /// <returns></returns>
        public bool Remove(iLogger iLog)
        {
            if (this.p_loggers.Contains(iLog))
            {
                this.p_loggers.Remove(iLog);
                // Check if still a progress Logger is in list
                this.p_containsProgressLogger = (this.p_loggers.Find(x => x.GetType() == typeof(iProgressLogger)) != null);
                return true;
            }
            return false;
        }


        /// <summary>
        ///  Entfertn sämtliche Logger
        /// </summary>
        public void ClearLoggers()
        {
            foreach (iLogger iLog in this.p_loggers)
                this.Remove(iLog); // Nicht die schnellste Variante aber was solls, wenigstens sauber
        }

        /// <summary>
        /// Gibt eine Liste sämtlicher angefügter Logger zurück.
        /// </summary>
        /// <returns></returns>
        public List<iLogger> GetLoggers()
        {
            return this.p_loggers;
        }

        #region iProgressLogger members
        public LogLevel LogLevel
        {
            get
            {
                LogLevel maxll = LogLevel.None;
                foreach (iLogger ilog in this.p_loggers)
                    maxll = (LogLevel) System.Math.Max((int)ilog.LogLevel, (int)maxll);
                return maxll;
            }
            set { } /// Die LogLevel der anghängten Logger müssen individuell angepasst werden. 
        }

        public int Progress
        {
            get
            {
                return this.p_progress;
            }

            set
            {
                if (this.p_containsProgressLogger)
                {
                    foreach (iLogger ilog in this.p_loggers)
                    {
                        if (ilog is iProgressLogger)
                            ((iProgressLogger)ilog).Progress = value;
                    }
                }
            }
        }

        public event EventHandler LoggerClosed;

        public bool AppendMessage(LogMessage LogMessage)
        {
            foreach (iLogger ilog in this.p_loggers)
                ilog.AppendMessage(LogMessage);
            return this.p_loggers.Count > 0;
        }

        public bool AppendMessage(DateTime TimeStamp, string Message, LogLevel ll)
        {
            foreach (iLogger ilog in this.p_loggers)
                ilog.AppendMessage(TimeStamp,Message,ll);
            return this.p_loggers.Count > 0;
        }

        public void Clear()
        {
            foreach (iLogger ilog in this.p_loggers)
                ilog.Clear();
        }

        public List<LogMessage> Log()
        {
            LogLevel ll = this.LogLevel; // Nur einmal Abfragen ...
            try
            {
                return this.p_loggers.Find(x => x.LogLevel >= ll).Log();
            } catch (ArgumentNullException) { return new List<LogMessage>(); }
        }

        public bool Show(System.Windows.Forms.Form owner)
        {
            return this.p_loggers.Find(x => x.Show(owner) != false)!=null; // Sucht den ersten Logger der sich anzeigen lässt (Show gibt nicht false zurück), falls keiner gefunden, dann wird Null zurückgegeben.
        }
        #endregion

    }
}
