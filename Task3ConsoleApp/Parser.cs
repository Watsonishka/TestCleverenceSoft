using System.Globalization;
using static Task3ConsoleApp.Level;

namespace Task3ConsoleApp
{
    public static class Parser
    {
        public static Log? TryParseLog(string inputFile, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                if (inputFile.Contains('|'))
                {
                    return ParseFormat2(inputFile);
                }
                else
                {
                    return ParseFormat1(inputFile);
                }
            }
            catch (Exception)
            {
                ProblemsRepository.AddToFile(inputFile);
                errorMessage = "Лог не смог запарситься! Требуется ручная обработка! Проблемный лог записан в \"problems.txt\"!";
            }
            return null;
        }
        private static Log ParseFormat1(string line)
        {
            var parts = line.Split(' ', 4);            
            var date = ParseDate(parts[0].Trim());
            var time = TimeOnly.Parse(parts[1].Trim());
            var level = Level.GetLog(parts[2].Trim());
            var callingMethod = "DEFAULT";
            var message = parts[3].Trim();
            return new Log(date, time, level, message, callingMethod);
        }
        private static Log ParseFormat2(string line)
        {
            var parts = line.Split('|', StringSplitOptions.RemoveEmptyEntries);
            var dateTimeParts = parts[0].Trim().Split(' ');

            var date = ParseDate(dateTimeParts[0].Trim());
            var time = TimeOnly.Parse(dateTimeParts[1].Trim());
            var level = Level.GetLog(parts[1].Trim());
            var callingMethod = parts[3].Trim();
            var message = parts[4].Trim();
            return new Log(date, time, level, message, callingMethod);
        }
        private static DateOnly ParseDate(string inputDate)
        {
            if (inputDate.Contains("."))
            {
                inputDate = inputDate.Replace('.', '-');
            }
            else
            {
                var parts = inputDate.Split('-');
                inputDate = $"{parts[2]}-{parts[1]}-{parts[0]}";
            }
            return DateOnly.ParseExact(inputDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        }
    }
}
