using System.Text;

namespace Test1ConsoleApp;

public class Program
{
    static void Main(string[] args)
    {
        var input = "";
        while (true)
        {
            Console.WriteLine("Введи строчку из строчных латинских букв, которую хочешь скомпрессировать!");
            var errorMessage = "";
            input = Console.ReadLine();
            if (InputValidatior.Check(input, out errorMessage))
            {
                break;
            }
            Console.WriteLine(errorMessage);
        }
        var compressionWord = WordCompressor.Compress(input);
        Console.WriteLine(compressionWord);
        var decompressionWord = WordCompressor.Decompress(compressionWord);
        Console.WriteLine(decompressionWord);
    }   

}