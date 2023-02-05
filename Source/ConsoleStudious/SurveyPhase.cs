using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleStudious
{
    class SurveyPhase
    {
        public List<Term> terms { get; set; }

        public DateTime surveyStartTime { get; set; }
        public DateTime surveyEndTime { get; set; }
        public string subjectTitle{ get; set; }
        public SurveyPhase(string subjectTitleValue)
        {
            surveyStartTime = DateTime.Now;
            subjectTitle = subjectTitleValue;


        }
        public void PromptForSurvey()
        {
            Console.WriteLine("**Add instructions for how to do SQ3R - Survey Phase**");
            // Prompt for Terms
            this.terms = new List<Term>();
            bool addTerm = true;
            int termCounter = 0;
            do
            {
                Console.WriteLine("Current List of All Terms");
                foreach (Term term in terms)
                {
                    Console.Write(term.term + ", ");
                }
                Helper.EmptyLines(2);
                string input = Helper.Prompt("Add another term or type 'Finished' to move on to the Question phase:");
                if (input.Equals("Finished"))
                {
                    addTerm = false;
                    surveyEndTime = DateTime.Now;
                }
                else
                {
                    termCounter++;
                    Term newTerm = new Term(termCounter, input, subjectTitle);
                    terms.Add(newTerm);
                }
            } while (addTerm);
        }
    }
    
}
