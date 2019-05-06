using System;

namespace Coderbyte.Simple_Adding
{
    /// <summary>
    /// Have the function SimpleAdding(num) add up all the numbers from 1 to num.
    /// For example: if the input is 4 then your program should return 10 because 1 + 2 + 3 + 4 = 10.
    /// For the test cases, the parameter num will be any number from 1 to 1000. 
    /// </summary>
    class Program
    {
        public static int SimpleAdding(int num)
        {
            int sum = 1;

            for(var i = 2; i <= num; i++)
                sum += i;

            return sum;
        }

        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            Console.WriteLine(SimpleAdding(int.Parse(input)));
            Console.ReadKey();
        }
    }
}
