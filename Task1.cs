﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    // Задача: реализовать метод CountVowels, который должен подсчитывать количество гласных символов в переданной строке.
    //   * Гласными считаются символы - 'a', 'e', 'i', 'o', 'u'.
    //   * Метод должен выбрасывать исключение ArgumentNullException в случае, если в метод передали null.
    //   * В решении разрешается использовать только конструкции языка. Использовать LINQ запрещено.

    class Program
    {
        // ИЗМЕНИТЕ КОД ЭТОГО МЕТОДА

        public static int CountVowels(string s)
        {
            var str = s;
            const string substr = "aeiou";
            int cnt = 0;
            try
            {
                for (int i = 0; i < s.Length; i++)
                    for (int j = 0; j < s.Length; ++j)
                        if (str[i] == substr[j])
                            ++cnt;
                return cnt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new NullReferenceException();
            }
            //finally { }
        }

        public static void Main()
        {
            Console.WriteLine("Task is done when all test cases are correct:");

            int testCaseNumber = 1;

            TestReturnedValues(testCaseNumber++, "", 0);
            TestReturnedValues(testCaseNumber++, " ", 0);
            TestReturnedValues(testCaseNumber++, "a", 1);
            TestReturnedValues(testCaseNumber++, "b", 0);
            TestReturnedValues(testCaseNumber++, "ab", 1);
            TestReturnedValues(testCaseNumber++, "ba", 1);
            TestReturnedValues(testCaseNumber++, "aba", 2);
            TestReturnedValues(testCaseNumber++, "bab", 1);
            TestReturnedValues(testCaseNumber++, "aeiou", 5);
            TestReturnedValues(testCaseNumber++, "bacedifoguh", 5);
            TestReturnedValues(testCaseNumber++, "Lorem ipsum dolor sit amet", 9);
            TestException<ArgumentNullException>(testCaseNumber++, null);
        }

        private static void TestReturnedValues(int testCaseNumber, string s, int expectedResult)
        {
            try
            {
                if (CountVowels(s) == expectedResult)
                {
                    Console.WriteLine(correctCaseTemplate, testCaseNumber);
                }
                else
                {
                    Console.WriteLine(incorrectCaseTemplate, testCaseNumber);
                }
            }
            catch (Exception)
            {
                Console.WriteLine(correctCaseTemplate, testCaseNumber);
            }
        }

        private static void TestException<T>(int testCaseNumber, string s) where T : Exception
        {
            try
            {
                CountVowels(s);
                Console.WriteLine(incorrectCaseTemplate, testCaseNumber);
            }
            catch (ArgumentException)
            {
                Console.WriteLine(correctCaseTemplate, testCaseNumber);
                correctTestCaseAmount++;
            }
            catch (Exception)
            {
                Console.WriteLine(incorrectCaseTemplate, testCaseNumber);
            }
        }

        private static string correctCaseTemplate = "Case #{0} is correct.";
        private static string incorrectCaseTemplate = "Case #{0} IS NOT CORRECT";
        private static int correctTestCaseAmount = 0;
    }
}

