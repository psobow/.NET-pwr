using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestFizzBuzz
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void checkDivisionBy3()
        {
            List<int> numbers = new List<int>() { 3, 9, 21, 27, 2 };

            List<string> expectedResult = new List<string>() { "Fizz", "Fizz", "Fizz", "Fizz", "2" };

            List<string> result = FizzBuzz.Application.MillNumbers(numbers);

            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void checkDivisionBy5()
        {
            List<int> numbers = new List<int>() { 5, 10, 20, 40, 2 };

            List<string> expectedResult = new List<string>() { "Buzz", "Buzz", "Buzz", "Buzz", "2" };

            List<string> result = FizzBuzz.Application.MillNumbers(numbers);

            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void checkDivisionBy5And3()
        {
            List<int> numbers = new List<int>() { 15, 30, 60, 45, 2 };

            List<string> expectedResult = new List<string>() { "FizzBuzz", "FizzBuzz", "FizzBuzz", "FizzBuzz", "2" };

            List<string> result = FizzBuzz.Application.MillNumbers(numbers);

            CollectionAssert.AreEqual(expectedResult, result);
        }
    }
}

