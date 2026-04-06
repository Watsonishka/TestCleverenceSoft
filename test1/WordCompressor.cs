using System.Text;

namespace Test1ConsoleApp
{
    public static class WordCompressor
    {
        public static string Compress(string userInput)
        {
            if (string.IsNullOrEmpty(userInput))
            {
                return "";
            }
            var compressedWord = new StringBuilder();
            var repeatSymbolCount = 1;

            for (int i = 1; i <= userInput.Length; i++)
            {
                if (i < userInput.Length && userInput[i] == userInput[i - 1])
                {
                    repeatSymbolCount++;
                }
                else
                {
                    compressedWord.Append(userInput[i - 1]);

                    if (repeatSymbolCount > 1)
                    {
                        compressedWord.Append(repeatSymbolCount);
                    }
                    repeatSymbolCount = 1;
                }
            }
            return compressedWord.ToString();
        }
        public static string Decompress(string userInput)
        {
            if (string.IsNullOrEmpty(userInput))
            {
                return "";
            }

            var decompressedWord = new StringBuilder();

            for (int i = 0; i < userInput.Length; i++)
            {
                var symbol = userInput[i];
                var repeatSymbolCount = 0;

                while (i + 1 < userInput.Length && char.IsDigit(userInput[i + 1]))
                {
                    i++;
                    var lastNumber = Convert.ToInt32(Convert.ToString(userInput[i]));
                    repeatSymbolCount = repeatSymbolCount * 10 + lastNumber;
                }
                if (repeatSymbolCount == 0)
                {
                    repeatSymbolCount = 1;
                }
                decompressedWord.Append(new string(symbol, repeatSymbolCount));
            }

            return decompressedWord.ToString();
        }
    }
}
