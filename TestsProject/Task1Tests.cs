using Test1ConsoleApp;

namespace TestsProject
{
    public class Task1Tests
    {
        [Fact]
        public void Compress_SimpleString_ReturnsCorrectCompressed()
        {
            var input = "aaabbcccdde";
            var expected = "a3b2c3d2e";
            var result = WordCompressor.Compress(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Compress_WithMoreThanTenRepeatingLetters_ReturnsCorrectCount()
        {
            var input = "aaaaaaaaaaaabbcccdd";
            var expected = "a12b2c3d2";
            var result = WordCompressor.Compress(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Compress_SingleCharacter_ReturnsOneGroup()
        {
            var input = "a";
            var expected = "a";
            var result = WordCompressor.Compress(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Compress_EmptyString_ReturnsEmptyList()
        {
            var input = "";
            var expected = "";
            var result = WordCompressor.Compress(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Compress_NullInput_ReturnsEmptyString()
        {
            var result = WordCompressor.Compress(null);
            Assert.Equal("", result);
        }

        [Fact]
        public void Decompress_WithValidData_ReturnsOriginalString()
        {
            var compressed = "a3b2c";
            var expected = "aaabbc";
            var result = WordCompressor.Decompress(compressed);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Decompress_EmptyList_ReturnsEmptyString()
        {
            var compressed = "";
            var expected = "";
            var result = WordCompressor.Decompress(compressed);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Decompress_SingleCharacter_ReturnsSameLetter()
        {
            var compressed = "с";
            var expected = "с";
            var result = WordCompressor.Decompress(compressed);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Decompress_WithDoubleDigitCount_ReturnsCorrectString()
        {
            var compressed = "a12b10c5";
            var expected = "aaaaaaaaaaaabbbbbbbbbbccccc";
            var result = WordCompressor.Decompress(compressed);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Decompress_NullInput_ReturnsEmptyString()
        {
            var result = WordCompressor.Decompress(null);
            Assert.Equal("", result);
        }
    }
}
