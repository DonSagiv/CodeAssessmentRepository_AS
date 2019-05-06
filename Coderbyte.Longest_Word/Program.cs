using System;
using System.Linq;

namespace Coderbyte.Longest_Word
{
    /// <summary>
    /// Difficulty: Easy/Medium
    /// 
    /// Have the function LongestWord(sen) take the sen parameter being passed and return the largest word in the string.
    /// If there are two or more words that are the same length, return the first word from the string with that length.
    /// Ignore punctuation and assume sen will not be empty.
    /// </summary>
    class Program
    {
        public static string LongestWord(string sen)
        {
            // Split words in sentence by space
            var words = sen.Split(' ');

            // Original solution had char.IsLetter instead of !char.IsPunctuation
            // Only 4 out of 5 test cases were correct when this was used.
            var longestWord = words
                .Select(x => x.ToCharArray().Where(y => !char.IsPunctuation(y))) // Remove non-punctuation characters
                .Select(x => new { word = x, length = x.Count() }) // get actual word and its length
                .OrderByDescending(x => x.length) // Order by length, desceding. This will ensure the first word from the string with that length is selected.
                .FirstOrDefault().word;

            return new string(longestWord.ToArray());
        }


        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            Console.WriteLine(LongestWord(input));
            Console.ReadKey();
        }
    }
}
