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

        public IEnumerable<WordCounter> MakingWordList()
        {
            Console.WriteLine("Making the word frequency list");
            var wordsArray = sb.ToString().
                Split(' ', ',', '.', '-', '!', '?', ':', ';', '"', '[', ']', '(', ')', '\r', '\t', '\n');

            List<WordCounter> words = new List<WordCounter>();

            foreach (var item in wordsArray)
            {
                WordCounter foundword = words.Find(x => x.word == item);
                if (foundword == null)
                {
                    words.Add(new WordCounter(item, 1));
                }
                else
                {
                    foundword.amount++;
                }
            }

            IEnumerable<WordCounter> sortedWords = words.OrderByDescending(w => w.amount);
            Console.WriteLine("Completed");
            return sortedWords;
        }
        public void AmountListFileInput(IEnumerable<WordCounter> words)
        {
            try
            {
                string writePath = Environment.CurrentDirectory;
                Console.WriteLine("Trying to write data to a file");
                using (StreamWriter streamwriter = new StreamWriter(@"..\..\InputFile.txt", false))
                {
                    foreach (var w in words)
                        streamwriter.WriteLine("{0} \t {1}", w.word, w.amount);
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
