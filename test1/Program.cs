using System.Text;

namespace Test1ConsoleApp;

public class Program
{
    static void Main(string[] args)
    {
        var input = "faaaaaaaaaaaagggrrrrrrrrrrr";
        var compressionWord = CompressWord(input);
        Console.WriteLine(compressionWord);
        var decompressionWord = DecompressWord(compressionWord);
        Console.WriteLine(decompressionWord);
    }
    public static string CompressWord(string input)
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

    public static string DecompressWord (string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return "";
        }
        if (input.Length == 1)
        {
            return input;
        }

        var currentSymbol = input[0];
        var decompressionWord = new StringBuilder();
        var countSymbols = "";
        var isNumberStart = false;

        for (var i = 1; i < input.Length; i++)
        {
            if (char.IsDigit(input[i]))
            {
                isNumberStart = true;
                countSymbols += input[i].ToString();
            }
            else if (!char.IsDigit(input[i]) && isNumberStart)
            {
                var count = int.Parse(countSymbols);
                for (var j = 1; j <= count; j++)
                {
                    decompressionWord.Append(currentSymbol);
                }
                countSymbols = "";
                isNumberStart = false;
                currentSymbol = input[i];
            }
            else
            {
                decompressionWord.Append(currentSymbol);
                currentSymbol = input[i];
            }
            if (i == input.Length - 1)
            {
                if (char.IsDigit(input[i]))
                {
                    var count = int.Parse(countSymbols);
                    for (var j = 1; j <= count; j++)
                    {
                        decompressionWord.Append(currentSymbol);
                    }
                }
                else
                {
                    decompressionWord.Append(currentSymbol);
                }
            }
        }
        return decompressionWord.ToString();
    }

}