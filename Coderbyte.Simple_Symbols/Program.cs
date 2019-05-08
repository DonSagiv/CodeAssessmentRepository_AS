using System;

namespace Coderbyte.Simple_Symbols
{
    /// <summary>
    /// Have the function SimpleSymbols(str) take the str parameter being passed and determine if it is an acceptable sequence by either returning the string true or false.
    /// The str parameter will be composed of + and = symbols with several letters between them (ie. ++d+===+c++==a) and for the string to be true each letter must be surrounded by a + symbol.
    /// So the string to the left would be false. The string will not be empty and will have at least one letter. 
    /// </summary>
    class Program
    {
        public static bool SimpleSymbols(string str)
        {
            // Separate string into characters, so each character can be run through
            var chars = str.ToCharArray();

            for(var i = 0; i < chars.Length; i++)
            {
                // Character must be a letter to perform test.
                if (char.IsLetter(chars[i]))
                {
                    // In order to be true, both before and after the letters must be '+', so the edge conditions are false.
                    if (i == 0 || i == chars.Length - 1)
                        return false;
                    else
                    {
                        // Check if both characters before and after the letter are '+'
                        if (chars[i - 1] == '+' && chars[i + 1] == '+')
                        {
                            continue;
                        }
                        else
                        {
                            // On first test that fails, return false.
                            return false;
                        }
                    }
                }
            }

            // All tests have passed, so return true.
            return true;
        }

        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            // For some reason, you need a lower-case "true" instead of the simple parsed "True" with a capital T.
            // So the parsed boolean is made lower-case.
            Console.WriteLine(SimpleSymbols(input).ToString().ToLower());
            Console.ReadKey();
        }
    }
}
