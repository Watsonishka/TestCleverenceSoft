using System.Text;

namespace Test1ConsoleApp;

public class Program
{
    static void Main(string[] args)
    {
        var input = "faaaaaaaaaaaa***gggrrrrrrrrrrr";
        var compressionWord = WordCompressor.Compress(input);
        Console.WriteLine(compressionWord);
        var decompressionWord = WordCompressor.Decompress(compressionWord);
        Console.WriteLine(decompressionWord);
    }  

}