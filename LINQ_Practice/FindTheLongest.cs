using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace LINQ_Practice
{
    class FindTheLongest
    {
        public static void Mainx()
        {
            Console.WriteLine(GetLongest(new[] { "azaz", "as", "sdsd" }));
            Console.WriteLine(GetLongest(new[] { "zzzz", "as", "sdsd" }));
            Console.WriteLine(GetLongest(new[] { "as", "12345", "as", "sds" }));
        }

        public static string GetLongest(IEnumerable<string> words)
        {
            return words
                .Where(word => word.Length == words
                    .Max(s => s.Length))
                .Min(); ;
        }
    }
}
