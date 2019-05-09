using System;
using System.Linq;

namespace Project_Euler.Multiples_Of_3_And_5
{
    /// <summary>
    /// If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
    /// Find the sum of all the multiples of 3 or 5 below 1000.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(sumOfMultiplesOf3or5(1000));

            Console.ReadKey();
        }

        static int sumOfMultiplesOf3or5(int maxNumber)
        {
            var nums = Enumerable.Range(1, maxNumber - 1)
                .Where(x => x % 3 == 0 || x % 5 == 0)
                .ToList();

            return nums.Sum();
        }
    }
}
