using System.Globalization;

namespace Task3ConsoleApp
{
    public static class Parser
    {
        public static Log? ParseLog(string inputFile, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                var parts = Divide(inputFile);

                var date = ParseDate(parts[0].Trim());
                var time = TimeOnly.Parse(parts[1].Trim());
                var level = Level.GetLog(parts[2].Trim());
                var callingMethod = "DEFAULT";
                var message = "";

                for (var i = 3; i < parts.Length; i++)
                {
                    if (IsContainsOnlyNumbers(parts[i]))
                    {
                        continue;
                    }

                    if (IsContainsRussianLetters(parts[i]))
                    {
                        message = parts[i].Trim();
                    }
                    else
                    {
                        callingMethod = parts[i].Trim();
                    }
                }
                return new Log(date, time, level, message.Trim(), callingMethod);
            }
            catch
            {
                ProblemsRepository.AddToFile(inputFile);
                errorMessage = "Лог не смог запарситься! Требуется ручная обработка! Проблемный лог записан в \"problems.txt\"!";
            }
            return null;
        }
        private static string[] Divide(string inputFile)
        {
            if (inputFile.Contains("|"))
            {
                var pipeParts = inputFile.Split('|', StringSplitOptions.RemoveEmptyEntries);
                var dateTimeParts = pipeParts[0].Trim().Split(' ');
                return new string[]
                {
                    dateTimeParts[0].Trim(),
                    dateTimeParts[1].Trim(),
                    pipeParts[1].Trim(),
                    pipeParts[2].Trim(),
                    pipeParts[3].Trim(),
                    pipeParts[4].Trim()
                };
            }
            var parts = inputFile.Split(' ', 4);
            return parts;
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
        private static bool IsContainsOnlyNumbers(string inputString)
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
        private static bool IsContainsRussianLetters(string inputString)
        {
            for (var i = 0; i < inputString.Length; i++)
            {
                var c = inputString[i];
                if ((c >= 'а' && c <= 'я') || c == 'ё' ||
                    (c >= 'А' && c <= 'Я') || c == 'Ё')
                {
                    return true;
                }
            }
            return false;
        }
    }
}
