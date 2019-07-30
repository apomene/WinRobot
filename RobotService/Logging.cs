using System;
using System.Collections.Generic;
using NLog;


namespace Logging
{
    public static class Logging
    {
        private static NLog.Logger _log = NLog.LogManager.GetLogger("generalLogger");

        public static void LogMsgToFile(string msg)
        {
            _log.Info(msg);
        }
        public static void LogErrorToFile(string msg)
        {
            _log.Error(msg);
        }
    }
}

