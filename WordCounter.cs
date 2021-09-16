
namespace TestTask2
{
    class WordCounter
    {
        public string word { get; set; }
        public int amount { get; set; }

        public WordCounter(string word, int amount)
        {
            this.word = word;
            this.amount = amount;
        }
    }
}
