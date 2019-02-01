// ****************************************************************************
// <copyright file="Notifications.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>15.10.2009</date>
// <project>CleanShutdown</project>
// <web>http://www.galasoft.ch</web>
// <license>
// See license.txt in this solution or http://www.galasoft.ch/license_MIT.txt
// </license>
// ****************************************************************************

using System;

namespace bregau.AuditPlaner.Logic.UI.Messages
{
    public static class Notifications
    {
        /// <summary>
        ///  This is the request to the listening application to immediatly shutdown the application
        /// </summary>
        public static readonly string RequestImmediateShutdown = Guid.NewGuid().ToString();

        /// <summary>
        /// This message is send to listeners directly before shutdown. Listeners can not stop shutdown but take emergency measures
        /// </summary>
        public static readonly string ConfirmShutdown = Guid.NewGuid().ToString();

        /// <summary>
        /// This message is send to listeners first. They can react to it and delay shutdown to finalize processes
        /// </summary>
        public static readonly string NotifyShutdown = Guid.NewGuid().ToString();
    }
}