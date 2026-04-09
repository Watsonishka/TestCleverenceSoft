using Microsoft.VisualBasic;

namespace Task3ConsoleApp
{
    public class Level
    {
        public enum LogLevel
        {
            UNKNOWN,
            INFO,
            WARN,
            ERROR,
            DEBUG
        }

        public static LogLevel GetLog(string logLevel)
        {
            switch (logLevel.Trim().ToUpper())
            {
                case "INFO": return LogLevel.INFO;
                case "INFORMATION": return LogLevel.INFO;
                case "WARN": return LogLevel.WARN;
                case "WARNING": return LogLevel.WARN;
                case "ERROR": return LogLevel.ERROR;
                case "DEBUG": return LogLevel.DEBUG;
                default: return LogLevel.UNKNOWN;
            }
        }
    }
}