using Xunit;
using NumberConverterBackend.Services;
using System.Numerics;
namespace NumberConverterTests
{
    public class NumberConverterServiceTests
    {
        private readonly ConvertNumbersService _service;
        public NumberConverterServiceTests()
        {
            _service = new ConvertNumbersService();
        }
        [Fact]
        public void ConvertNumberToWords_Given0_ShouldReturnZero()
        {
            //Arrange
            BigInteger number = 0;

            //Act
            var result = _service.ConvertNumbers(number);

            //Assert
            Assert.Equal("Zero", result);

        }
        [Fact]  
        public void ConvertNumberToWords_GivenNegativeNumber_ShouldReturnNegative()
        {
            //Arrange
            BigInteger number = -1;

            //Act
            var result = _service.ConvertNumbers(number);

            //Assert
            Assert.Equal("Negative One", result);
        }
        [Fact]

        public void ConvertNumberToWords_GivenOver900_ShouldReturnTrue()
        {
            //Arrange
            BigInteger number = 9000;

            //Act
            var result = _service.ConvertNumbers(number);

            //Assert
            Assert.Equal("Nine Thousand", result);
        }
        [Fact]
        public void ConvertNumberToWords_GivenAG0ogol_ShouldReturnTrue()
        {
            //Arrange
            BigInteger number =  BigInteger.Pow(10, 100);

            //Act
            var result = _service.ConvertNumbers(number);

            //Assert
            Assert.Equal("One Googol", result);
        }

        [Fact]
        public void ConvertNumberToWords_GivenASexvigintillion_ShouldReturnTrue()
        {
            // Arrange
            BigInteger number = BigInteger.Pow(10, 81);

            // Act
            var result = _service.ConvertNumbers(number);

            // Assert
            Assert.Equal("One Sexvigintillion", result);
        }

        [Fact]
        public void ConvertNumberToWords_GivenTenSexvigintillion_ShouldReturnTrue()
        {
            // Arrange
            BigInteger number = BigInteger.Pow(10, 82);

            // Act
            var result = _service.ConvertNumbers(number);

            // Assert
            Assert.Equal("Ten Sexvigintillion", result);
        }
        [Fact]
        public void ConvertNumberToWords_GivenLargeNumberWithNonZeroEnd_ShouldReturnTrue()
        {
            // Arrange
            BigInteger number = BigInteger.Parse("123456789012345678901234567890123456789012345678901234567890123456789012345678901234567");

            // Act
            var result = _service.ConvertNumbers(number);

            // Assert
            Assert.Equal("One Hundred Twenty Three Septenvigintillion Four Hundred Fifty Six Sexvigintillion Seven Hundred Eighty Nine Quinvigintillion Twelve Quattuorvigintillion Three Hundred Forty Five Trevigintillion Six Hundred Seventy Eight Duovigintillion Nine Hundred One Unvigintillion Two Hundred Thirty Four Vigintillion Five Hundred Sixty Seven Novemdecillion Eight Hundred Ninety Octodecillion One Hundred Twenty Three Septendecillion Four Hundred Fifty Six Sexdecillion Seven Hundred Eighty Nine Quindecillion Twelve Quattuordecillion Three Hundred Forty Five Tredecillion Six Hundred Seventy Eight Duodecillion Nine Hundred One Undecillion Two Hundred Thirty Four Decillion Five Hundred Sixty Seven Nonillion Eight Hundred Ninety Octillion One Hundred Twenty Three Septillion Four Hundred Fifty Six Sextillion Seven Hundred Eighty Nine Quintillion Twelve Quadrillion Three Hundred Forty Five Trillion Six Hundred Seventy Eight Billion Nine Hundred One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven", result);
        }

    }
}