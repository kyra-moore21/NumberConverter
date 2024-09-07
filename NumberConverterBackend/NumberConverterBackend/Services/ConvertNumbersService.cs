    using NumberConverterBackend.Interfaces;
namespace NumberConverterBackend.Services
{
    public class ConvertNumbersService : IConvertNumbers
    {
        public string ConvertNumbers(int number)
        {
            if(number == 0)
            {
                return "Zero";
            }
            if(number < 0)
            {
                return "Negative " + ConvertNumbers(Math.Abs(number));
            }

            string words = "";
            if (number / 1000000 > 0)
            {
                words += ConvertNumbers(number / 1000000) + " Million ";
                number %= 1000000;
            }
            if (number / 1000 > 0)
            {

                words += ConvertNumbers(number / 1000) + " Thousand ";
                number %= 1000;
            }
            if(number / 100 > 0)
            {
                words += ConvertNumbers(number / 100) + " Hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                var ones = new string[]
                {
                    "",
                    "One",
                    "Two",
                    "Three",
                    "Four",
                    "Five",
                    "Six",
                    "Seven",
                    "Eight",
                    "Nine",
                };
                var teens = new string[]
                {
                    "Ten",
                    "Eleven",
                    "Twelve",
                    "Thirteen",
                    "Fourteen",
                    "Fifteen",
                    "Sixteen",
                    "Seventeen",
                    "Eighteen",
                    "Nineteen"
                };
                var tens = new string[]
                {
                    "",
                    "",
                    "Twenty",
                    "Thirty",
                    "Forty",
                    "Fifty",
                    "Sixty",
                    "Seventy",
                    "Eighty",
                    "Ninety"
                };

                if(number < 10)
                {
                    words += ones[number] + " ";
                } 
                else if(number < 20)
                {
                    words += teens[number - 10] + " ";
                }
                else
                {
                    words += tens[number / 10] + " ";
                    if(number % 10 > 0)
                    {
                        words += ones[number % 10] + " ";
                    }
                }
            }

            //added trim to make unit testing easier
            return words.Trim();
         
        }
    }
}
