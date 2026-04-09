using Task3ConsoleApp;

namespace Test3ConsoleApp;

public class Program
{
    static void Main(string[] args)
    {
        var s = "2025-03-10 15:14:51.5882| INFO|11|MobileComputer.GetDeviceId| Код устройства: '@MINDEO-M40-D-410244015546'";
        var log = Parser.TryParseLog(s, out string errorMessage);
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
