using System;
using System.Collections.Generic;
using NLog;


namespace BcpShell
{
   
    public static class Logging
    {
        private static NLog.Logger _log = NLog.LogManager.GetLogger("generalLogger");

        private static NLog.Logger _metricLogger = NLog.LogManager.GetLogger("metricLogger");

        public static string ConString { get; set; }
        public static void LogMsgToFile(string msg)
        {
            _log.Info(msg);
        }

        public static void LogErrorToFile(string msg)
        {
            _log.Error(msg);
        }

        public static void LogToDatabase(string tblName, int srcRows,int trgRows)
        {
           //TO DO??
        }

        public static void LogMetrics(Dictionary<string,int> metrics,string databaseName)
        {
            _metricLogger.Info($"Metrics for Database: {databaseName} ...");
            foreach (var metric in metrics)
            {
                _metricLogger.Info($"Table Name: {metric.Key} \t \t #Rows: {metric.Value}");
            }
        }

        public static void LogMetrics(Dictionary<string, int> metrics)
        {         
            foreach (var metric in metrics)
            {
                _metricLogger.Info($"Table Name: {metric.Key} \t \t #Rows: {metric.Value}");
            }
        }

        public static void LogMetrics()
        {           
           _metricLogger.Info(Environment.NewLine);          
        }
    }
}
