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
            List<int> numbers = new List<int>() { 3, 9, 27, 2 };

            List<string> expectedResult = new List<string>() { "Fizz", "Fizz", "Fizz", "2" };

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

        [TestMethod]
        public void checkDivisionBy7()
        {
            List<int> numbers = new List<int>() { 7, 14, 21, 2 };

            List<string> expectedResult = new List<string>() { "Buzzinga", "Buzzinga", "Buzzinga", "2" };

            List<string> result = FizzBuzz.Application.MillNumbers(numbers);

            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void checkDigits3And5Apperance()
        {
            List<int> numbers = new List<int>() { 352, 5321 };

            List<string> expectedResult = new List<string>() { "FizzBuzz", "FizzBuzz" };

            List<string> result = FizzBuzz.Application.MillNumbers(numbers);

            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void checkDigits5Apperance()
        {
            List<int> numbers = new List<int>() { 251, 5111 };

            List<string> expectedResult = new List<string>() { "Buzz", "Buzz" };

            List<string> result = FizzBuzz.Application.MillNumbers(numbers);

            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void checkPassEmptyList()
        {
            List<int> numbers = new List<int>() {};

            List<string> expectedResult = new List<string>() {};

            List<string> result = FizzBuzz.Application.MillNumbers(numbers);

            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void MoreRealisticTest()
        {
            List<int> numbers = new List<int>() {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            List<string> expectedResults = new List<string>() {
                "1","2","Fizz","4","Buzz","Fizz","Buzzinga","8","Fizz","Buzz",
                 "11","Fizz","13","Buzzinga","FizzBuzz","16","17","Fizz","19","Buzz"};
            List<string> actualResluts = FizzBuzz.Application.MillNumbers(numbers);
            CollectionAssert.AreEqual(expectedResults, actualResluts);
        }
    }
}

