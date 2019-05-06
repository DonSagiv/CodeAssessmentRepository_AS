using System;
using System.Collections.Generic;
using System.Linq;

namespace Coderbyte.Letter_Changes
{
    /// <summary>
    /// Difficulty: Easy/Medium
    /// 
    /// Have the function LetterChanges(str) take the str parameter being passed and modify it using the following algorithm.
    /// Replace every letter in the string with the letter following it in the alphabet (ie. c becomes d, z becomes a).
    /// Then capitalize every vowel in this new string (a, e, i, o, u) and finally return this modified string.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(LetterChanges(Console.ReadLine()));
            Console.ReadKey();
        }

        public static string LetterChanges(string str)
        {
            // String to character array.
            var chars = str.ToCharArray();

            // Empty list for storage of new characters.
            var newChars = new List<char>();

            // vowel repository
            var vowels = new Dictionary<char, char>
            {
                { 'a', 'A' },
                { 'e', 'E' },
                { 'i', 'I' },
                { 'o', 'O' },
                { 'u', 'U' }
            };

            // Iterating through each character
            foreach (var item in chars.ToList())
            {
                // since z is the last letter in the alphabet, by default, it should go to captial A (since A is a vowel)
                if (item == 'z') newChars.Add('A');
                else
                {
                    // Letters are basically numeric bytes. Incrementing the byte moves to the next letter.
                    var charByte = Convert.ToByte(item);

                    // Setting the range of the possible bytes of lower-case letters (except z, which is the "if" case)
                    if (charByte < Convert.ToByte('a') || charByte > Convert.ToByte('y'))
                    {
                        // retains the character if its not a letter (Maybe using chars.IsLetter would have been a better idea)
                        newChars.Add(item);
                        continue;
                    }

                    // Getting the next letter in the alphabet
                    charByte++;
                    var newChar = Convert.ToChar(charByte);

                    // If vowel, capitalize the letter
                    if (vowels.Keys.Contains(newChar))
                        newChar = vowels[newChar];

                    // Adding the modified character to the array
                    newChars.Add(newChar);
                }
            }

            return new string(newChars.ToArray());
        }
    }
}
