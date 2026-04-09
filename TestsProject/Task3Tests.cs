using Task3ConsoleApp;
using static Task3ConsoleApp.Level;

namespace TestsProject
{
    public class Task3Tests
    {
        [Fact]
        public void ParseFormat1_ValidLogWithDefaultMethod_ReturnsLog()
        {
            string input = "10.03.2025 15:14:49.523 INFORMATION Версия программы: '3.4.0.48729'";
            var result = Parser.TryParseLog(input, out string errorMessage);
            Assert.NotNull(result);
            Assert.Equal("10-03-2025", result.Date.ToString("dd-MM-yyyy"));
            Assert.Equal("15:14:49.523", result.Time.ToString("HH:mm:ss.fff"));
            Assert.Equal(LogLevel.INFO, result.Level);
            Assert.Equal("Версия программы: '3.4.0.48729'", result.Message);
            Assert.Equal("DEFAULT", result.CallingMethod);
            Assert.Equal("", errorMessage);
        }

        [Fact]
        public void ParseFormat1_WarningLevel_ReturnsWarn()
        {
            string input = "10.03.2025 15:14:49.523 WARNING Сообщение";
            var result = Parser.TryParseLog(input, out string errorMessage);
            Assert.NotNull(result);
            Assert.Equal(LogLevel.WARN, result.Level);
        }

        [Fact]
        public void ParseFormat2_ValidLog_ReturnsLog()
        {
            string input = "2025-03-10 15:14:51.5882| INFO|11|MobileComputer.GetDeviceId| Код устройства: '@MINDEO-M40-D-410244015546'";
            var result = Parser.TryParseLog(input, out string errorMessage);
            Assert.NotNull(result);
            Assert.Equal("10-03-2025", result.Date.ToString("dd-MM-yyyy"));
            Assert.Equal("INFO", result.Level.ToString());
            Assert.Equal("MobileComputer.GetDeviceId", result.CallingMethod);
            Assert.Equal("", errorMessage);
        }

        [Fact]
        public void ParseInvalidLog_ReturnsNullAndAddsToProblems()
        {
            string input = "99.99.2025 15:14:49.523 INFORMATION Сообщение";
            var result = Parser.TryParseLog(input, out string errorMessage);
            Assert.Null(result);
            Assert.NotEmpty(errorMessage);
            Assert.Equal("Лог не смог запарситься! Требуется ручная обработка! Проблемный лог записан в \"problems.txt\"!", errorMessage);
        }

        [Fact]
        public void ParseEmptyString_ReturnsNull()
        {
            string input = "";
            var result = Parser.TryParseLog(input, out string errorMessage);
            Assert.Null(result);
            Assert.NotEmpty(errorMessage);
            Assert.Equal("Лог не смог запарситься! Требуется ручная обработка! Проблемный лог записан в \"problems.txt\"!", errorMessage);
        }

        [Fact]
        public void ParseInvalidLog_AddsToProblemsFile()
        {
            ProblemsRepository.DeleteFile();
            string input = "99.99.2025 15:14:49.523 INFORMATION Сообщение";
            var result = Parser.TryParseLog(input, out string errorMessage);
            Assert.Null(result);
            var problems = ProblemsRepository.GetAll();
            Assert.Single(problems);
            Assert.Equal(input, problems[0]);
        }

        [Fact]
        public void ProblemsRepository_DeleteFile_ClearsContent()
        {
            ProblemsRepository.DeleteFile();
            ProblemsRepository.AddToFile("Problem 1");
            ProblemsRepository.DeleteFile();
            var problems = ProblemsRepository.GetAll();
            Assert.Empty(problems);
        }
    }
}
