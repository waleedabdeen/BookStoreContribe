using System;
using System.IO;


namespace BookStoreWFClient.Modules.LoggingModule
{
    public class LoggingService
    {
        //Full log file path, directory + file name
        //Default directory is the program directory
        private static readonly string logFilePath = "log_s.txt";
        private static readonly string logTag = "LoggingService";

        private static LoggingStatus loggingStatus = LoggingStatus.on;

        public enum LogType
        {
            error,
            warning,
            info
        }

        public enum LoggingStatus
        {
            on,
            off,
            failed
        }

        static LoggingService()
        {
            //Open or create the log file 

        }

        public static void Initialize()
        {
            //Create the log file and write text to it
            Log(LogType.info, "Initializing log file", logTag);
        }

        public static void ChangeLoggingStatus(LoggingStatus status)
        {
            loggingStatus = status;
        }

        public static void Log(LogType logType, string message, string tag)
        {
            if (loggingStatus != LoggingStatus.on)
            {
                return;
            }
            string loggingString = "";
            loggingString = "[" + DateTime.Now.ToString() + "] " + logType.ToString() + ": "
                            + tag + " - " + message + "\r\n";
            try
            {
                File.AppendAllText(logFilePath, loggingString);
            }
            catch (Exception)
            {
                loggingStatus = LoggingStatus.failed;
            }

        }
    }
}
