namespace ConsoleStudious
{
    public class Question
    {
        public string questionString { get; set; }
        public int bloomLevel { get; set; }
        public string subject { get; set; }

        public Question(string questionString, int bloomLevel, string subject)
        {
            this.questionString = questionString;
            this.bloomLevel = bloomLevel;
            this.subject = subject;
        }
    }
}