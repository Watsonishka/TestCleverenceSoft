using System.Text;

namespace Test1ConsoleApp
{
    public static class WordCompressor
    {
        public static List<(char symbol, int count)> Compress(string input)
        {

            if (string.IsNullOrWhiteSpace(input))
            {
                return new List<(char symbol, int count)>();
            }

            input = new string(input.Where(c => !char.IsWhiteSpace(c)).ToArray()).ToLower();
            var previousSymbol = input[0];
            var currentSymbol = ' ';
            var repeatSymbolCount = 1;
            var compresedChars = new List<(char symbol, int count)>();

            for (var i = 1; i < input.Length; i++)
            {
                currentSymbol = input[i];

                if (currentSymbol == previousSymbol)
                {
                    repeatSymbolCount++;
                }
                else
                {
                    compresedChars.Add((previousSymbol, repeatSymbolCount));
                    repeatSymbolCount = 1;
                    previousSymbol = currentSymbol;
                }
            }

            compresedChars.Add((previousSymbol, repeatSymbolCount));
            return compresedChars;
        }
        public static string ReadCompressedWord(List<(char symbol, int count)> compressedChars)
        {
            if (compressedChars == null || compressedChars.Count == 0)
            {
                return "";
            }

            var compressedWord = new StringBuilder();

            foreach (var compressedChar in compressedChars)
            {
                compressedWord.Append(compressedChar.symbol);
                if (compressedChar.count > 1)
                {
                    compressedWord.Append(compressedChar.count);
                }
            }
            return compressedWord.ToString();
        }
        public static string Decompress(List<(char symbol, int count)> compressedChars)
        {
            if (compressedChars == null || compressedChars.Count == 0)
            {
                return "";
            }

            var decompressedWord = new StringBuilder();

            foreach (var compressedChar in compressedChars)
            {
                if (compressedChar.count == 1)
                {
                    decompressedWord.Append(compressedChar.symbol);
                }
                else
                {
                    for (var i = 0; i < compressedChar.count; i++)
                    {
                        decompressedWord.Append(compressedChar.symbol);
                    }
                }
            }
            return decompressedWord.ToString();
        }
    }
}
