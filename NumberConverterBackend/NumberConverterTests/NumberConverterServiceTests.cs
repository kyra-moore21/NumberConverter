using Xunit;
using NumberConverterBackend.Services;
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
            int number = 0;

            //Act
            var result = _service.ConvertNumbers(number);

            //Assert
            Assert.Equal("Zero", result);

        }
        [Fact]  
        public void ConvertNumberToWords_GivenNegativeNumber_ShouldReturnNegative()
        {
            //Arrange
            int number = -1;

            //Act
            var result = _service.ConvertNumbers(number);

            //Assert
            Assert.Equal("Negative One", result);
        }
        [Fact]

        public void ConvertNumberToWords_GivenOver900_ShouldReturnTrue()
        {
            //Arrange
            int number = 9000;

            //Act
            var result = _service.ConvertNumbers(number);

            //Assert
            Assert.Equal("Nine Thousand", result);
        }
    }
}