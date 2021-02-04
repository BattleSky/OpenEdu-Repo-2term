using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LINQ_Practice
{
    public class Document
    {
        public int Id;
        public string Text;
    }

    class ReverseIndex
    {
        public static void Main()
        {
            Document[] documents =
            {
                new Document {Id = 1, Text = "Hello world!"},
                new Document {Id = 2, Text = "World, world, world... Just words..."},
                new Document {Id = 3, Text = "Words — power"},
                new Document {Id = 4, Text = ""}
            };
            var index = BuildInvertedIndex(documents);
            //SearchQuery("world", index);
            //SearchQuery("words", index);
            //SearchQuery("power", index);
            //SearchQuery("cthulhu", index);
            //SearchQuery("", index);
        }

        public static ILookup<string, int> BuildInvertedIndex(Document[] documents)
        {
            return documents
                .Select(document => Regex.Split(document.Text.ToLower(), @"\W+")
                    .Where(word => word != "")
                    .Select(word => Tuple.Create(word, document.Id))
                    .Distinct()
                )
                .SelectMany(manyTuples => manyTuples
                        .Select(tuple => tuple))
                .ToLookup(tuple => tuple.Item1, tuple => tuple.Item2);
        }
    }
}
