namespace ConsoleStudious
{
    public class Question
    {
        public int index { get; set; }
        public string questionString { get; set; }
        public Stem stem { get; set; }
        public Term term { get; set; }

        public Question(int indexValue, string questionString, Stem stemValue, Term termValue)
        {
            this.index = indexValue;
            this.questionString = questionString;
            this.stem = stemValue;
            this.term = termValue;
        }
    }
}