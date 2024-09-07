using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NumberConverterBackend.Controllers;
using NumberConverterBackend.Interfaces;
using NumberConverterBackend.Models;

namespace NumberConverterTests
{
    public class NumberConverterControllerTests
    {
        private readonly Mock<IConvertNumbers> _mockService;
        private readonly NumberConverterController _controller;
        public NumberConverterControllerTests()
        {
            _mockService = new Mock<IConvertNumbers>();
            _controller = new NumberConverterController(_mockService.Object);
        }

        [Fact]
        public void ConvertNumbers_GivenValidInput_ShouldReturnSortedResult()
        {
            //Arrange 
            var numberArray = new NumberArray
            {
                Numbers = new string[] { "3", "5432", "33" }
            };
            _mockService.Setup(x => x.ConvertNumbers(5432)).Returns("Five Thousand Thirty Two");
            _mockService.Setup(x => x.ConvertNumbers(33)).Returns("Thirty Three");
            _mockService.Setup(x => x.ConvertNumbers(3)).Returns("Three");

            //Act
            var result = _controller.ConvertNumbers(numberArray) as OkObjectResult;

            //Assert
            Assert.NotNull(result);
            var sortedResult = result.Value as List<NumberWord>;
            Assert.Equal(3, sortedResult.Count);
            Assert.Equal("Five Thousand Thirty Two", sortedResult[0].Word);
            Assert.Equal("Thirty Three", sortedResult[1].Word);
            Assert.Equal("Three", sortedResult[2].Word);

        }

        [Fact]
        public void ConvertNumbers_GivenInvalidInput_ShouldReturnBadRequest()
        {
            //Arrange 
            var numberArray = new NumberArray
            {
                Numbers = new string[] { "abc", "33", "3" }
            };

            //Act
            var result = _controller.ConvertNumbers(numberArray) as BadRequestObjectResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Invalid input", result.Value);
        }

        [Fact]
        public void ConvertNumbers_GivenMaxInput_ShouldReturnBadRequest()
        {
            //Arrange 
            var numberArray = new NumberArray
            {
                Numbers = new string[] { "2147483648", "33", "3" }
            };

            //Act
            var result = _controller.ConvertNumbers(numberArray) as BadRequestObjectResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Number too large", result.Value);
        }
        [Fact]
        public void ConvertNumbers_GivenEmptyInput_ShouldReturnBadRequest()
        {
            //Arrange 
            var numberArray = new NumberArray
            {
                Numbers = new string[] { }
            };

            //Act
            var result = _controller.ConvertNumbers(numberArray) as BadRequestObjectResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Cannot be empty", result.Value);
        }
    }
}
