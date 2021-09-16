using System;


namespace TestTask2
{
    class Program
    {
        static void Main(string[] args)
        {
            TextAnalyzer text = new TextAnalyzer();
            text.AmountListFileInput(text.MakingWordList());

            Console.WriteLine("Press key to exit");
            Console.ReadLine();
        }
    }
}
