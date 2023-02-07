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
            terms = new List<Term>();
            bool continueAddingTerms = true;
            int termCounter = 0;
            do
            {
                Console.WriteLine("Current List of All Terms");
                foreach (Term term in terms)
                {
                    Console.Write(term.term + ", ");
                }
                Helper.EmptyLines(2);
                string prompt = "Add another term" + (terms.Count >= 2 ? " or just press Enter to move on to the Question phase:":":");
                string input = Helper.Prompt(prompt);
                if (!input.Equals(""))
                {
                    termCounter++; // start term numbering at 1
                    Term newTerm = new Term(termCounter, input, subjectTitle);
                    terms.Add(newTerm);
                }
                else if (input.Equals("") && terms.Count >= 2)
                {
                    continueAddingTerms = false;
                    surveyEndTime = DateTime.Now;
                }
            } while (continueAddingTerms);
        }
    }
    
}
