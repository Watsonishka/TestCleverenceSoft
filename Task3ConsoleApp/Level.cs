using Microsoft.VisualBasic;

namespace Task3ConsoleApp
{
    public class Level
    {
        public enum LogLevel
        {
            unknown = 0,
            information = 1,
            warning = 2,
            error = 3,
            debug = 4
        }

        public static LogLevel Parse(string logLevel)
        {
            switch (logLevel.ToUpper())
            {
                case "INFO": return LogLevel.information;
                case "INFORMATION": return LogLevel.information;
                case "WARN": return LogLevel.warning;
                case "WARNING": return LogLevel.warning;
                case "ERROR": return LogLevel.error;
                case "DEBUG": return LogLevel.debug;
                default: return LogLevel.unknown;
            }
        }
    }
}