using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Task3ConsoleApp
{
    public static class Parser
    {
        public static Log ParseLog(string inputFile)
        {
            var parts = Divide(inputFile);

            var date = ParseDate(parts[0].Trim());
            var time = TimeOnly.Parse(parts[1].Trim());
            var level = Level.GetLog(parts[2].Trim());
            var callingMethod = "DEFAULT";
            var message = "";

            for (var i = 3; i < parts.Length; i++)
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
                    message += $"{parts[i].Trim()} ";
                }
            }
            return new Log(date, time, level, message.Trim(), callingMethod);
        }
        private static string[] Divide(string inputFile)
        {
            if (inputFile.Contains("|"))
            {
                return inputFile.Split(new char[] { '|', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
            var parts = inputFile.Split(' ', 4);
            return parts;
        }
        private static DateOnly ParseDate(string inputDate)
        { 
            if (inputDate.Contains("."))
            {
                inputDate = inputDate.Replace('.', '-');
                return DateOnly.ParseExact(inputDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            }
            var parts = inputDate.Split('-');
            inputDate = $"{parts[2]}-{parts[1]}-{parts[0]}";
            return DateOnly.ParseExact(inputDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
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
