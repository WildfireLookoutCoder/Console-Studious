namespace ConsoleStudious
{
    public class Question
    {
        public int label { get; set; }
        public string questionString { get; set; }
        public Stem stem { get; set; }
        public Term term { get; set; }

        public Question(int labelValue, string questionStringValue, Stem stemValue, Term termValue)
        {
            label = labelValue;
            questionString = questionStringValue;
            stem = stemValue;
            term = termValue;
        }
    }
}