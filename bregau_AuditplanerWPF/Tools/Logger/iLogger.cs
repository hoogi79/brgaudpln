using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bregau_AuditplanerWPF.Tools.Logger
{
    public interface iLogger
    {

        /// <summary>
        /// Ein Ereigniss das ausgelöst wird, sobald der Logger geschlossen/beendet wird. 
        /// </summary>
        event EventHandler LoggerClosed;

        /// <summary>
        /// Setzt den Log Level. Nur Nachrichten mit gleichem oder höherem 
        /// Log Level werden angenommen.
        /// </summary>
        LogLevel LogLevel { get; set; }

        /// <summary>
        /// Gibt den gesamten Log Inhalt als Liste von LogMessage zurück
        /// </summary>
        List<LogMessage> Log();

        ///// <summary>
        ///// Ruft eine irgendgeartete Anzeige Funktion des Logger auf.
        ///// </summary>
        ///// <param name="owner">Das Hauptfenster an dem die Ausgabe eingehängt werden soll, oder null</param>
        ///// <returns>Gibt false im Falle es eines Fehlers zurück oder falls keine Ausgabefunktion definiert ist</returns>
        //bool Show(System.Windows.Window owner);

        /// <summary>
        /// Fügt dem Logger eine Nachricht hinzu
        /// </summary>
        /// <param name="TimeStamp">DateTime Objek das den Zeitpunkt der Nachricht darstellt.</param>
        /// <param name="Message">Der Nachrichtentext.</param>
        /// <param name="ll">Der LogLevel</param>
        /// <returns>Gibt false zurück, falls die Nachricht fehlerhaft ist oder auf Grund eines zu geringen LogLevels nicht akzeptiert wurde.</returns>
        bool AppendMessage (DateTime TimeStamp, String Message, LogLevel ll);

        /// <summary>
        /// Fügt dem Logger eine Nachricht hinzu
        /// </summary>
        /// <param name="LogMessage">Die Nachricht als LogMessage-Objekt</param>
        /// <returns>Gibt false zurück, falls die Nachricht fehlerhaft ist oder auf Grund eines zu geringen LogLevels nicht akzeptiert wurde.</returns>
        bool AppendMessage(LogMessage LogMessage);

        /// <summary>
        /// Löscht sämtliche Nachrichten aus dem Logger
        /// </summary>
        void Clear();

    }

    /// <summary>
    /// Die möglichen Loglevel, je höher, desto mehr Informationen werden geloggt.
    /// </summary>
    public enum LogLevel {Info, Warn, Error, Debug, None }

    /// <summary>
    /// Log Nachricht bestehend aus Zeitpunkt, Nachricht und LogLevel
    /// </summary>
    public class LogMessage
    {
        public LogMessage() { }
        public LogMessage(DateTime dt, String mess, LogLevel lvl)
        {
            TimeStamp = dt;
            Message = mess;
            Level = lvl;
        }

        public override String ToString()
        {
            if (TimeStamp != null && Message != null)
            {
                string lvlString = Enum.GetName(typeof(LogLevel), Level);
                string timString = "";
                try
                {
                    timString = TimeStamp.ToString();
                }
                catch (ArgumentOutOfRangeException aoorException) { timString = "01.01.1970 00:00 + (" + aoorException.ToString() + ")"; }
                return timString + ": " + Message + " [" + lvlString + "]\n";
            }
            return null;
        }

        public DateTime TimeStamp {get; set;}
        public String Message { get; set; }
        public LogLevel Level { get; set; }
    }

}
