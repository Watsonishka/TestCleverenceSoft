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
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("CallingMethod не может быть пустым или null!");
                }
                foreach (char c in value)
                {
                    if (!((c >= 'a' && c <= 'z') ||
                          (c >= 'A' && c <= 'Z') ||
                          c == '.' ||
                          (c >= '0' && c <= '9')))
                    {
                        throw new ArgumentException($"CallingMethod содержит недопустимые символы! Разрешены только латинские буквы, цифры и точки!");
                    }
                }
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
        public string ReadToTabSeparatedString()
        {
            var date = Date.ToString("dd-MM-yyyy");
            var time = Time.ToString("HH:mm:ss.fffffff").TrimEnd('0');
            var level = Level;
            var method = CallingMethod;
            var message = Message;
            return $"{date}\t{time}\t{level}\t{method}\t{message}";
        }
    }
}
