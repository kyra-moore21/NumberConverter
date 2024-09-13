    using NumberConverterBackend.Interfaces;
using System.Numerics;
namespace NumberConverterBackend.Services
{
    public class ConvertNumbersService : IConvertNumbers
    {
        private static readonly string[] LargeNumberNames = new string[] {
    "",         //ones       
    "Thousand",
    "Million",
    "Billion",
    "Trillion",
    "Quadrillion",
    "Quintillion",
    "Sextillion",
    "Septillion",
    "Octillion",
    "Nonillion",
    "Decillion",
    "Undecillion",
    "Duodecillion",
    "Tredecillion",
    "Quattuordecillion",
    "Quindecillion",
    "Sexdecillion",
    "Septendecillion",
    "Octodecillion",
    "Novemdecillion",
    "Vigintillion",
    "Unvigintillion",
    "Duovigintillion",
    "Trevigintillion",
    "Quattuorvigintillion",
    "Quinvigintillion",
    "Sexvigintillion",
    "Septenvigintillion",
    "Octovigintillion",
    "Novemvigintillion",
    "Trigintillion",
    "Untrigintillion",
};
        public string ConvertNumbers(BigInteger number)
        {


            if (number == 0)
            {
                return "Zero";
            }
            if (number < 0)
            {
                return "Negative " + ConvertNumbers(BigInteger.Abs(number));
            }
            if (number == BigInteger.Pow(10, 100))
            {
                return "One Googol";
            }

            string words = "";
            int index = 0;


            while (number > 0)
            {
                BigInteger currentChunk = number % 1000;

                if (currentChunk != 0)
                {

                    if (currentChunk == 1 && index > 0)
                    {
                        words = "One " + LargeNumberNames[index] + " " + words;
                    }
                    else
                    {
                        string chunkWords = ConvertChunk(currentChunk);

                        if (!string.IsNullOrEmpty(LargeNumberNames[index]))
                        {
                            chunkWords += " " + LargeNumberNames[index];
                        }

                        words = chunkWords + " " + words;
                    }
                }

                number /= 1000; // Update the number after processing the chunk
                index++;
                //checking for a googol
              

              
            }
            return words.Trim();

        }

            private string ConvertChunk(BigInteger number)
            {
                string words = "";

                var ones = new string[]
                {
            "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine"
                };
                var teens = new string[]
                {
            "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"
                };
                var tens = new string[]
                {
            "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"
                };

                if (number / 100 > 0)
                {
                    words += ones[(int)(number / 100)] + " Hundred ";
                    number %= 100;
                }

                if (number > 0)
                {
                    if (number < 10)
                    {
                        words += ones[(int)number];
                    }
                    else if (number < 20)
                    {
                        words += teens[(int)(number - 10)];
                    }
                    else
                    {
                        words += tens[(int)(number / 10)];
                        if ((number % 10) > 0)
                        {
                            words += " " + ones[(int)(number % 10)];
                        }
                    }
                }

                return words.Trim();
            }
        }
    }

