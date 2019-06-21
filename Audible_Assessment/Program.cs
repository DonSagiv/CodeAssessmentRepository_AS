using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Audible_Assessment
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = Console.ReadLine();

            var lines = File.ReadAllLines(filename);

            var rowInfo = lines.Select(x => x.Split(' '))
                .Select(x => new RowInfo(x))
                .Where(x => x.code == "200")
                .Where(x => x.requestType == "\"GET")
                .Where(x => !string.IsNullOrWhiteSpace(x.gifName))
                .Where(x => x.extension.ToLower() == ".gif")
                .GroupBy(x => x.gifName)
                .Select(x => x.First().gifName)
                .ToList();

            var gifsFileName = $"gifs_{filename}";

            File.WriteAllLines(gifsFileName, rowInfo);

            Console.WriteLine(gifsFileName);
        }

        public class RowInfo
        {
            public string gifName { get; set; }
            public string requestType { get; set; }
            public string extension { get; set; }
            public string code { get; set; }

            public RowInfo(IEnumerable<string> rowStringInfo)
            {
                var rowStringArray = rowStringInfo.ToArray();

                gifName = Path.GetFileName(rowStringArray[6]);
                extension = Path.GetExtension(rowStringArray[6]);
                requestType = rowStringArray[5];
                code = rowStringArray[8];
            }
        }
    }
}
