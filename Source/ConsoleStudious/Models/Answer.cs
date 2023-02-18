using System;

namespace ConsoleStudious
{
    public class Answer
    {
        public string answerString { get; set; }
        public string urlReferece { get; set; }
        public int? pageNumber { get; set; }


        public Answer(Question question)
        {

            int num;

            do
            {
                Console.WriteLine(question.questionString);
                Helper.EmptyLines(2);
                answerString = Helper.Prompt("Enter your answer:");
            } while (answerString.Equals(""));
            
            if (int.TryParse(Helper.Prompt("Enter a page number associated with this answer or just press Enter if your reading material does not have page numbers."), out num))
            {
                pageNumber = num;
            }


        }
    }
}