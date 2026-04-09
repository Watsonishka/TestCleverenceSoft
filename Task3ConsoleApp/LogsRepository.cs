using Newtonsoft.Json;

namespace Task3ConsoleApp
{
    public class LogsRepository
    {
        private static readonly List<Log> logs = new List<Log>();
        private const string logsFilePath = "LogsList.json";
        static LogsRepository()
        {
            if (!File.Exists(logsFilePath))
            {
                var jsonData = JsonConvert.SerializeObject(logs);
                FileManager.RewriteJSONFile(logsFilePath, jsonData);
            }
            else
            {
                var logs = GetAll();
            }
        }
        public static List<Log> GetAll()
        {
            return FileManager.ReadJSONFile<Log>(logsFilePath);
        }
        public static void RewriteFile(List<Log> logs)
        {
            var jsonData = JsonConvert.SerializeObject(logs);
            FileManager.RewriteJSONFile(logsFilePath, jsonData);
        }
    }
}
