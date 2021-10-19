using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using AnalyzerLibrary;


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
            streamreader.Close();
        }


        public Dictionary<string, int> ListReflectionOutput()
        {
            Dictionary<string, int> words = null;
            var assembly = Assembly.Load("AnalyzerLibrary");
            var types = assembly.DefinedTypes;
            var cl = types.FirstOrDefault(t => t.Name == "ListMaker");
            var obj = Activator.CreateInstance(cl);
            
            var method = obj.GetType().GetMethod("MakingWordList", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] param = new object[1];
            param[0] = (object)sb;
            words = (Dictionary<string, int>)method.Invoke(obj, param);

            return words;
        }




    public void AmountListFileInput(Dictionary<string, int> words)
        {
            bool isWritten = true;
            try
            {
                string writePath = Environment.CurrentDirectory;
                Console.WriteLine("Trying to write data to a file");
                using (StreamWriter streamwriter = new StreamWriter(@"..\..\InputFile.txt", false))
                {
                    foreach(var w in words)
                        streamwriter.WriteLine("{0} \t {1}", w.Key, w.Value);
                    streamwriter.Close();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Error!");
                Console.WriteLine("Message: {0}", e.Message);
                isWritten = false;
            }
          
            if(isWritten)
            {
                Console.WriteLine("Data was written successfully");
            }
        }






    }
}
