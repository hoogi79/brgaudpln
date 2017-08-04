using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bregau_Auditplaner.Tools.Logger
{
    interface iProgressLogger : iLogger
    {
        /// <summary>
        /// Der Fortschrittswert. Der Wertebereich liegt zwischen 0 und 100 (MOD Wert). Erlaubt ist auch -1
        /// </summary>
        int Progress { get; set; }
    }
}
