using System;

namespace Coderbyte.First_Factorial
{
    /// <summary>
    /// Difficulty: Easy
    /// 
    /// Have the function FirstFactorial(num) take the num parameter being passed and return the factorial of it.
    /// For example: if num = 4, then your program should return (4 * 3 * 2 * 1) = 24.
    /// For the test cases, the range will be between 1 and 18 and the input will always be an integer. 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var integer = int.Parse(Console.ReadLine());

            Console.WriteLine(FirstFactorial(integer));
            Console.ReadKey();
        }

        public static int FirstFactorial(int num)
        {
            // 1! = 1
            int factorialNum = 1;

            // Starts multiplication at 2.
            // Use dynamic programming to continue multiplication in for loop.
            for (var i = 2; i <= num; i++)
                factorialNum = i * factorialNum;

            return factorialNum;
        }
    }
}
