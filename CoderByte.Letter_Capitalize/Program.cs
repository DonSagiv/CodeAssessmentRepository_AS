using System;
using System.Collections.Generic;
using System.Linq;

namespace CoderByte.Letter_Capitalize
{
    /// <summary>
    /// Have the function LetterCapitalize(str) take the str parameter being passed and capitalize the first letter of each word.
    /// Words will be separated by only one space. 
    /// </summary>
    class Program
    {
        public static string LetterCapitalize(string str)
        {
            // Split to character arrays to make individual letters more manageable
            var words = str
                .Split(' ')
                .Select(x => x.ToCharArray());

            // New list of string to store capitalized words
            var capitalWords = new List<string>();

            foreach (var word in words)
            {
                // Change the first letter of the word to its capital
                // Then addd to the list of capitalized words.
                word[0] = char.ToUpper(word[0]);
                capitalWords.Add(new string(word));
            }

            // Coderbyte only uses the string.Join(string, params string[]) overload, so be careful of that.
            return string.Join(" ", capitalWords.ToArray());
        }

        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            Console.WriteLine(LetterCapitalize(input));
            Console.ReadKey();
        }
    }
}
