namespace Test1ConsoleApp;

public class Program
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine();
        var compressionWord = WordCompressor.Compress(input);
        Console.WriteLine(WordCompressor.ReadCompressedWord(compressionWord));
        var decompressionWord = WordCompressor.Decompress(compressionWord);
        Console.WriteLine(decompressionWord);
    }

}