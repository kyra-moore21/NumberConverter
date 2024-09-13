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

    }
}