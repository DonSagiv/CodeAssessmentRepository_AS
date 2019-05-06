using System;
using System.Linq;

namespace Coderbyte.First_Reverse
{
    /// <summary>
    /// Difficulty: Easy
    /// 
    /// Have the function FirstReverse(str) take the str parameter being passed and return the string in reversed order.
    /// For example: if the input string is "Hello World and Coders" then your program should return the string sredoC dna dlroW olleH.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FirstReverse(Console.ReadLine()));
            Console.ReadKey();
        }

        public static string FirstReverse(string str)
        {
            var reverseString = new string(str.Reverse().ToArray());
            return reverseString;
        }
    }
}
