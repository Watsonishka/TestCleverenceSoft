using Newtonsoft.Json;

namespace Task3ConsoleApp
{
    public class LogsRepository
    {
        private static readonly List<Log> logs = new List<Log>();
        private const string logsFilePath = "LogsList.json";
        private const string problemsFilePath = "problems.txt";
        static LogsRepository()
        {
            if (!File.Exists(logsFilePath))
            {
                var jsonData = JsonConvert.SerializeObject(logs);
                FileManager.RewriteTextFile(logsFilePath, jsonData);
            }
            else
            {
                var logs = GetAll();
            }
        }
        public static List<Log> GetAll()
        {
            return FileManager.ReadTextFile<Log>(logsFilePath);
        }
        public static void RewriteFile(List<Log> logs)
        {
            var jsonData = JsonConvert.SerializeObject(logs);
            FileManager.RewriteTextFile(logsFilePath, jsonData);
        }

    }
}
