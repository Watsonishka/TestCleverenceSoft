using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Task3ConsoleApp.Level;

namespace Task3ConsoleApp
{
    public static class Parser
    {
        private static readonly int _minTimeStringLength = 12;
        public static Log ParseLog(string inputFile)
        {
            var parts = Divide(inputFile);

            var date = DateOnly.ParseExact(parts[0], "DD-MM-YYYY");
            var time = TimeOnly.Parse(parts[1]);
            var level = GetLog(parts[2]); 
            var callingMethod = "DEFAULT";
            var message = "";

            for ( var i = 3; i < parts.Length; i++)
            {
                if (isContainsOnlyNumbers(parts[i]))
                {
                    continue;
                }
                if (IsContainsOnlyLatinLetters(parts[i]))
                {
                    callingMethod = parts[i].Trim();
                }
                else
                {
                    message = parts[i].Trim();
                }
            }
            return new Log(date,time,level,message,callingMethod);
        }
        private static string[] Divide(string inputDate)
        {
            var divideInput = new List<string>();
            if (inputDate.Contains("|"))
            {
                return inputDate.Split('|');
                
            }
            return inputDate.Split(' ');
        }
        private static LogLevel GetLog(string logLevel)
        {
            switch (logLevel.Trim().ToUpper())
            {
                case "INFO": return LogLevel.INFO;
                case "INFORMATION": return LogLevel.INFORMATION;
                case "WARN": return LogLevel.WARN;
                case "WARNING": return LogLevel.WARNING;
                case "ERROR": return LogLevel.ERROR;
                case "DEBUG": return LogLevel.DEBUG;
                default: return LogLevel.UNKNOWN;
            }
        }
        private static bool isContainsOnlyNumbers(string inputString)
        {
            for (var i = 0; inputString.Length > i; i++)
            {
                if (!char.IsDigit(inputString[i]))
                {
                    return false;
                }
            }
            return true;
        }
        private static bool IsContainsOnlyLatinLetters(string inputString)
        {
            for (var i = 0; i < inputString.Length; i++)
            {
                var c = inputString[i];
                if (!((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || c == '.'))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
