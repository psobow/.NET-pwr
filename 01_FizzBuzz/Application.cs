using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz
{
    public class Application
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }

        public static List<string> MillNumbers(List<int> numbers)
        {
            List<string> results = new List<string>();

            foreach (int number in numbers)
            {
                if (isDividedBySeven(number))
                {
                    results.Add("Buzzinga");
                }
                else if (isDividedByThree(number) && isDividedByFive(number)
                    || areDigitsThreeAndFiveLocatedNextToEachOtherInside(number))
                {
                    results.Add("FizzBuzz");
                }
                else if (isDividedByFive(number) || isDigitFiveInside(number))
                {
                    results.Add("Buzz");
                }
                else if (isDividedByThree(number))
                {
                    results.Add("Fizz");
                }
                else
                {
                    results.Add(number.ToString());
                }

            }

            return results;
        }

        private static bool isDividedByThree(int number)
        {
            return number % 3 == 0;
        }

        private static bool isDividedByFive(int number)
        {
            return number % 5 == 0;
        }

        private static bool isDividedBySeven(int number)
        {
            return number % 7 == 0;
        }

        private static bool areDigitsThreeAndFiveLocatedNextToEachOtherInside(int number)
        {
            string numberToString = number.ToString();
            return numberToString.Contains("53") || numberToString.Contains("35");
        }

        private static bool isDigitFiveInside(int number)
        {
            return number.ToString().Contains("5");
        }
    }
}
