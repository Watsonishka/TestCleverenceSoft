using Test1ConsoleApp;

namespace Task1TestProject
{
    public class Task1Tests
    {
        [Fact]
        public void Compress_SimpleString_ReturnsCorrectCompressed()
        {
            var input = "aaabbcccdde";
            var expected = new List<(char, int)>
            {
                ('a', 3), ('b', 2), ('c', 3), ('d', 2), ('e', 1)
            };
            var result = WordCompressor.Compress(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Compress_WithMoreThanTenRepeatingLetters_ReturnsCorrectCount()
        {
            var input = "aaaaaaaaaaaabbcccdd";
            var expected = new List<(char, int)>
            {
                ('a', 12), ('b', 2), ('c', 3), ('d', 2)
            };
            var result = WordCompressor.Compress(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Compress_SingleCharacter_ReturnsOneGroup()
        {
            var input = "a";
            var expected = new List<(char, int)>
            {
                ('a', 1)
            };
            var result = WordCompressor.Compress(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Compress_EmptyString_ReturnsEmptyList()
        {
            var input = "";
            var expected = new List<(char, int)>();
            var result = WordCompressor.Compress(input);
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Compress_StringWithOnlySpaces_ReturnsEmptyList()
        {
            var input = "   ";
            var expected = new List<(char, int)>();
            var result = WordCompressor.Compress(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Compress_WithDigitsAndSymbols_CompressesCorrectly()
        {
            var input = "aaa55555====u4";
            var expected = new List<(char, int)>
            {
                ('a', 3), ('5', 5), ('=', 4), ('u', 1), ('4', 1)
            };
            var result = WordCompressor.Compress(input);
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Compress_WithSpaces_RemovesSpacesAndCompresses()
        {
            var input = "aaa      ggggg c";
            var expected = new List<(char, int)>
            {
                ('a', 3), ('g', 5), ('c', 1)
            };
            var result = WordCompressor.Compress(input);
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Compress_MixedCase_ConvertsToLower()
        {
            var input = "AaABbB";
            var expected = new List<(char, int)> 
            { 
                ('a', 3), ('b', 3) 
            };
            var result = WordCompressor.Compress(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Decompress_WithValidData_ReturnsOriginalString()
        {
            var compressed = new List<(char, int)>
            {
                ('a', 3), ('b', 2), ('c', 1)
            };
            var expected = "aaabbc";
            var result = WordCompressor.Decompress(compressed);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Decompress_WithDigitsLettersAndSymbols_ReturnsOriginalString()
        {
            var compressed = new List<(char, int)>
            {
                ('a', 3), ('5', 5), ('=', 2), ('с', 1)
            };
            var expected = "aaa55555==с";
            var result = WordCompressor.Decompress(compressed);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Decompress_EmptyList_ReturnsEmptyString()
        {
            var compressed = new List<(char, int)>();
            var expected = "";
            var result = WordCompressor.Decompress(compressed);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Decompress_SingleCharacter_ReturnsSameLetter()
        {
            var compressed = new List<(char, int)>
            {
                ('с', 1)
            };
            var expected = "с";
            var result = WordCompressor.Decompress(compressed);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Decompress_WithDoubleDigitCount_ReturnsCorrectString()
        {
            var compressed = new List<(char, int)>
            {
                ('a', 12), ('b', 10), ('c', 5)
            };
            var expected = "aaaaaaaaaaaabbbbbbbbbbccccc";
            var result = WordCompressor.Decompress(compressed);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ReadCompressedWord_WithValidData_ReturnsCompressedString()
        {
            var compressed = new List<(char, int)>
            {
                ('a', 3), ('b', 2), ('c', 1)
            };
            var expected = "a3b2c";
            var result = WordCompressor.ReadCompressedWord(compressed);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ReadCompressedWord_WithDigitsAndSymbols_ReturnsCompressedString()
        {
            var compressed = new List<(char, int)>
            {
                ('5', 3), ('a', 4), ('=', 3), ('!', 2)
            };
            var expected = "53a4=3!2";
            var result = WordCompressor.ReadCompressedWord(compressed);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ReadCompressedWord_EmptyList_ReturnsEmptyString()
        {
            var compressed = new List<(char, int)>();
            var result = WordCompressor.ReadCompressedWord(compressed);
            Assert.Equal("", result);
        }

        [Fact]
        public void ReadCompressedWord_SingleCharacter_ReturnsLetterWithoutNumber()
        {
            var compressed = new List<(char, int)>
            {
                ('a', 1)
            };
            var result = WordCompressor.ReadCompressedWord(compressed);
            Assert.Equal("a", result);
        }

        [Fact]
        public void ReadCompressedWord_WithLargeCount_ReturnsNumberAsIs()
        {
            var compressed = new List<(char, int)>
            {
                ('a', 100), ('b', 50), ('c', 25)
            };
            var expected = "a100b50c25";
            var result = WordCompressor.ReadCompressedWord(compressed);
            Assert.Equal(expected, result);
        }
    }
}
