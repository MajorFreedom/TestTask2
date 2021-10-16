using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TestTask2
{
    class TextAnalyzer
    {

        private static readonly string filename = "largetext.txt";
        private StringBuilder sb;

        public TextAnalyzer() 
        {
            StreamReader streamreader = new StreamReader(Path.GetFullPath(filename));
            sb = new StringBuilder(streamreader.ReadToEnd().ToString());
        }

        public IOrderedEnumerable<KeyValuePair<string, int>> MakingWordList()
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


            IOrderedEnumerable<KeyValuePair<string, int>> sortedWords = dictionaryWords.OrderByDescending(w => w.Value);


            Console.WriteLine("Completed");
            return sortedWords;
        }
        
        public void AmountListFileInput(IOrderedEnumerable<KeyValuePair<string, int>> words)
        {
            try
            {
                string writePath = Environment.CurrentDirectory;
                Console.WriteLine("Trying to write data to a file");
                using (StreamWriter streamwriter = new StreamWriter(@"..\..\InputFile.txt", false))
                {
                    foreach(var w in words)
                        streamwriter.WriteLine("{0} \t {1}", w.Key, w.Value);

                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Error!");
                Console.WriteLine("Message: {0}", e.Message);  
            }
            finally
            {
                Console.WriteLine("Data was written successfully");
            }
        }






    }
}
