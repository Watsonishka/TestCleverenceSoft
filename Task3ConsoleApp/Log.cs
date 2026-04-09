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
        public DateOnly Date 
        { 
            get => date;
            set
            {
                date = value;
            }
        }
        public TimeOnly Time
        {
            get => time;
            set
            {
                time = value;
            }
        }
        public LogLevel Level
        {
            get => level;
            set
            {
                level = value;
            }
        }
        public string Message
        {
            get => message;
            set
            {
                message = value;
            }
        }
        public string CallingMethod
        {
            get => callingMethod;
            set
            {
                callingMethod = value;
            }
        }
        public Log(DateOnly date, TimeOnly time, LogLevel level, string message, string callingMethod)
        {
            this.date = date;
            this.time = time;
            this.level = level;
            this.message = message;
            this.callingMethod = callingMethod;
        }
        public static string ReadToTabSeparatedString(Log log)
        {
            var date = log.Date.ToString("dd-MM-yyyy");
            var time = log.Time.ToString("HH:mm:ss.fffffff").TrimEnd('0');
            var level = log.Level;
            var method = log.CallingMethod;
            var message = log.Message;

            return $"{date}\t{time}\t{level}\t{method}\t{message}";
        }
    }
}
