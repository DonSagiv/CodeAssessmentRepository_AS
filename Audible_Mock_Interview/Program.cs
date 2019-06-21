using System;
using System.Collections.Generic;

namespace Audible_Mock_Interview
{
    class Program
    {
        static void Main(string[] args)
        {
            // So this is our input

            var inputNumArray = new[] { 3, 5, 2, -4, 8, 11 };

            // How can we get each pair of numbers in the array that add up to a certain input number?

            var addendPairs = findAddendPairs(inputNumArray, 7);

            foreach(var addendPair in addendPairs)
            {
                Console.WriteLine($"{addendPair[0]}, {addendPair[1]}");
            }
        }

        public static IEnumerable<int[]> findAddendPairs(int[] inputNumArray, int requiredSum)
        {
            var arrayLength = inputNumArray.Length;
            var addendPairs = new List<int[]>();

            for (var i = 0; i < arrayLength; i++)
            {
                for (var j = i; j < arrayLength; j++)
                {
                    if (inputNumArray[i] + inputNumArray[j] == requiredSum)
                    {
                        var addendPair = new[] { inputNumArray[i], inputNumArray[j] };

                        addendPairs.Add(addendPair);
                    }
                }
            }

            return addendPairs;
        }
    }
}
