using System.Globalization;

namespace Task3ConsoleApp
{
    public static class Parser
    {
        private static readonly int _minTimeStringLength = 12;
        public static Log ParseLog(string inputFile)
        {
            var parts = Divide(inputFile);

            var date = DateOnly.ParseExact(parts[0].Trim(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
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
                    message = parts[i].Trim();
                }
            }
            return new Log(date, time, level, message, callingMethod);
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
