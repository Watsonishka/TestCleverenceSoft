using Task2ConsoleApp;

namespace Test2ConsoleApp;

public class Program
{
    static void Main(string[] args)
    {
        Server.AddToCount(1);
        Server.AddToCount(180);
        Console.WriteLine(Server.GetCount());
    }

}