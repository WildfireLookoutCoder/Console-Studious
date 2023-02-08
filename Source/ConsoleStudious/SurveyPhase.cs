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
            bool continueAddingTerms = true;
            int termCounter = 0;
            string prompt;
            string input;
            terms = new List<Term>();

            ProvideInstructions();
            
            do
            {
                Console.WriteLine("Current List of All Terms");
                Helper.EmptyLines(2);
                Helper.DisplayTerms(terms);
                // This is backwards from the QuestionPhase where we ask users to type finished when they are ready to move on. I shoud match that pattern.
                prompt = "Add another term" + (terms.Count >= 2 ? " or just press Enter to move on to the Question phase:":":");
                input = Helper.Prompt(prompt);

                if (!input.Equals(""))
                {
                    termCounter++; // start term numbering at 1
                    Term newTerm = new Term(termCounter, input.ToLower(), subjectTitle);
                    terms.Add(newTerm);
                }
                else if (input.Equals("") && terms.Count >= 2)
                {
                    continueAddingTerms = false;
                    surveyEndTime = DateTime.Now;
                }
            } while (continueAddingTerms);

            ClosingMessage(terms);
        }

        private void ProvideInstructions()
        {
            Console.WriteLine("Survey instructions go here");
            Helper.AnyKeyToContinue();
        }
        private static void ClosingMessage(List<Term> terms)
        {
            Console.Clear();
            Console.WriteLine($"You have {terms.Count} terms in your study session:");
            foreach (Term term in terms)
            {
                Console.WriteLine($"{term.label}. {term.term}");
            }
            Helper.AnyKeyToContinue();
        }
    }
    
}
