using Task3ConsoleApp;

namespace Test3ConsoleApp;

public class Program
{
    static void Main(string[] args)
    {
        //var s = "10.03.2025 15:14:49.523 INFORMATION Версия программы: '3.4.0.48729'";
        var s = "2025-03-10 15:14:51.5882| INFO|11|MobileComputer.GetDeviceId| Код устройства: '@MINDEO-M40-D-410244015546'";
        var log = Parser.ParseLog(s);
        Console.WriteLine($"Дата: {log.Date:dd-MM-yyyy}");
        Console.WriteLine($"Время: {log.Time:HH:mm:ss.fff}");
        Console.WriteLine($"Уровень: {log.Level}");
        Console.WriteLine($"Метод: {log.CallingMethod}");
        Console.WriteLine($"Сообщение: {log.Message}");
    }

}