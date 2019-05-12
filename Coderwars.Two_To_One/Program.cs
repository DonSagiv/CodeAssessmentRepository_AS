using System;
using System.Linq;

namespace Coderwars.Two_To_One
{
    /// <summary>
    /// 
    /// Take 2 strings s1 and s2 including only letters from ato z. Return a new sorted string, the longest possible, containing distinct letters,
    /// 
    /// a = "xyaabbbccccdefww"
    /// b = "xxxxyyyyabklmopq"
    /// longest(a, b) -> "abcdefklmopqwxy"
    /// a = "abcdefghijklmnopqrstuvwxyz"
    /// longest(a, a) -> "abcdefghijklmnopqrstuvwxyz"
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var s1 = "aretheyhere";
            var s2 = "yestheyarehere";

            Console.WriteLine(Longest(s1, s2));
            Console.ReadKey();
        }

        static string Longest(string s1, string s2)
        {
            var charArray1 = s1.ToCharArray();
            var charArray2 = s2.ToCharArray();

            var allChars = charArray1
                .Concat(charArray2)
                .Distinct()
                .OrderBy(x => x)
                .ToArray();

            return new string(allChars);
        }
    }
}
