using Task3ConsoleApp;

namespace Test3ConsoleApp;

public class Program
{
    static void Main(string[] args)
    {
        var s = "10.03.2025 15:14:49.523 INFORMATION Версия программы: '3.4.0.48729'";
        var log = Parser.ParseLog(s, out string errorMessage);
        if (log == null)
        {
            Console.WriteLine(errorMessage);
            var count = 1;
            var problems = ProblemsRepository.GetAll();
            foreach (var problem in problems)
            {
                Console.WriteLine($"{count}: {problem}");
                count++;
            }
        }
        else
        {
            Console.WriteLine(log.ReadToTabSeparatedString());
        }
    }
}
