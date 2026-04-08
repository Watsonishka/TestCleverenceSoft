using static Task3ConsoleApp.Level;

namespace Task3ConsoleApp
{
    public class Log
    {
        private DateOnly date;
        private TimeOnly time;
        private LogLevel level;
        private string message;
        private string callingMethod;
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public LogLevel Level { get; set; }
        public string Message { get; set; }
        public string CallingMethod { get; set; }
        public Log(DateOnly date, TimeOnly time, LogLevel level, string message, string callingMethod)
        {
            this.date = date;
            this.time = time;
            this.level = level;
            this.message = message;
            this.callingMethod = callingMethod;
        }
    }
}
