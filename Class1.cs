using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnalyzerLibrary
{
    class ListMaker
    {
        private Dictionary<string, int> MakingWordList(StringBuilder sb)
        {
            Console.WriteLine("Making the word frequency list");
            var wordsArray = sb.ToString().
                Split(' ', ',', '.', '-', '!', '?', ':', ';', '"', '[', ']', '(', ')', '\r', '\t', '\n');

            Dictionary<string, int> dictionaryWords = new Dictionary<string, int>();

            foreach (var item in wordsArray)
            {
                if (dictionaryWords.ContainsKey(item))
                {
                    dictionaryWords[item]++;
                }
                else
                {
                    dictionaryWords.Add(item, 1);
                }
            }
            Dictionary<string, int> sortedWords = dictionaryWords.OrderByDescending(w => w.Value).ToDictionary(w => w.Key, w => w.Value);
            Console.WriteLine("Completed");
            return sortedWords;
        }

    }
}
