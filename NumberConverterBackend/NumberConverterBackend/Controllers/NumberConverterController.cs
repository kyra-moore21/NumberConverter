using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using NumberConverterBackend.Interfaces;
using NumberConverterBackend.Models;

namespace NumberConverterBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumberConverterController : ControllerBase
    {
        private readonly IConvertNumbers _convertNumbersService;

        public NumberConverterController(IConvertNumbers convertNumbersService)
        {
            _convertNumbersService = convertNumbersService;
        }
        //https://localhost:7054/api/NumberConverter/sort
        //api/NumberConverter/sort
        [HttpPost("sort")]

        public IActionResult ConvertNumbers([FromBody] NumberArray numberArray)
        {
            if (numberArray == null || numberArray.Numbers.Length == 0)
            {
                return BadRequest("Cannot be empty");
            }

            var result = new List<NumberWord>();

            foreach (var number in numberArray.Numbers)
            {
                if (long.TryParse(number, out long n))
                {
                    //catching larger than max int
                    if(n > int.MaxValue || n < int.MinValue)
                    {
                       return BadRequest("Number too large");
                    }

                    int validNumber = (int)n;
                    if(validNumber > 9000)
                    {
                    string word = _convertNumbersService.ConvertNumbers(validNumber);
                        result.Add(new NumberWord { Word = word, Over9000 = true });
                    }
                    else
                    {
                        string word = _convertNumbersService.ConvertNumbers(validNumber);
                         result.Add(new NumberWord { Word = word, Over9000 = false }); 
                    }
                }
                else
                {
                    //catching letters and special characters
                    return BadRequest("Invalid input");
                }
            }
            var sortedResult = result.OrderBy(x => x.Word).ToList();

            return Ok(sortedResult);
        }
    }
}
