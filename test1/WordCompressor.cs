using System.Text;

namespace Test1ConsoleApp
{
    public class WordCompressor
    {
        public List<(char symbol, int count)> Compress(string input)
        {

            if (string.IsNullOrEmpty(input))
            {
                return new List<(char symbol, int count)>();
            }

            var previousSymbol = input[0];
            var currentSymbol = ' ';
            var repeatSymbolCount = 1;
            var compressionWords = new List<(char symbol, int count)>();

            for (var i = 1; i < input.Length; i++)
            {
                currentSymbol = input[i];

                if (currentSymbol == previousSymbol)
                {
                    repeatSymbolCount++;
                }
                else
                {
                    compressionWords.Add((previousSymbol, repeatSymbolCount));
                    repeatSymbolCount = 1;
                    previousSymbol = currentSymbol;
                }
            }

            compressionWords.Add((previousSymbol, repeatSymbolCount));
            return compressionWords;
        }

        public static string Decompress(string input)
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
}
