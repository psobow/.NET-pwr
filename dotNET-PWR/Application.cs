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

            foreach (int n in numbers)
            {
                if (numberIsDividedByThree(n) && !numberIsDividedByFive(n))
                {
                    results.Add("Fizz");
                }
                else if (numberIsDividedByFive(n) && !numberIsDividedByThree(n))
                {
                    results.Add("Buzz");
                }
                else if (numberIsDividedByThree(n) && numberIsDividedByFive(n))
                {
                    results.Add("FizzBuzz");
                }
                else
                {
                    results.Add(n.ToString());
                }

            }

            return results;
        }

        private static bool numberIsDividedByThree(int number)
        {
            return number % 3 == 0;
        }

        private static bool numberIsDividedByFive(int number)
        {
            return number % 5 == 0;
        }

    }
}
