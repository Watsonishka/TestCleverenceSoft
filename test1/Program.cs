using System.Text;

namespace Test1ConsoleApp;

public class Program
{
    static void Main(string[] args)
    {
        var input = "aaagggr";
        var compressionWord = CompressWord(input);
        Console.WriteLine(compressionWord);
    }
    static string CompressWord(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return "";
        }
        if (input.Length == 1)
        {
            return input;
        }

        var previousSymbol = input[0];        
        var currentSymbol = ' ';
        var repeatSymbolCount = 1;
        var compressionWord = new StringBuilder();

        for (var i = 1; i < input.Length; i++)
        {
            currentSymbol = input[i];

            if (currentSymbol == previousSymbol)
            {
                repeatSymbolCount++;
            }
            else
            {
                compressionWord.Append(previousSymbol);
                if (repeatSymbolCount > 1)
                {
                    compressionWord.Append(repeatSymbolCount);
                }
                repeatSymbolCount = 1;
                previousSymbol = currentSymbol;
            }
            if (i == input.Length - 1)
            {
                compressionWord.Append(currentSymbol);
                if (repeatSymbolCount > 1)
                {
                    compressionWord.Append(repeatSymbolCount);

                }
            }
        }

        return compressionWord.ToString();
    }
}