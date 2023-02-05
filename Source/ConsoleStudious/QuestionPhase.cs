using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleStudious
{
    internal class QuestionPhase
    {
        private List<Term> terms { get; set; }
        private List<Stem> stems { get; set; }
        private List<Question> uneditedQuestions { get; set; }
        public List<Question> questions { get; set; }
        
        public QuestionPhase(List<Term> termsValue)
        {
            terms = termsValue;
            stems = Stem.GenerateBloomStems();
            uneditedQuestions = GenerateUneditedQuestions();

            
        }

        private List<Question> GenerateUneditedQuestions()
        {
            uneditedQuestions = new List<Question>();
            foreach(Term term in terms)
            {
                foreach(Stem stem in stems)
                {
                    string questionString = stem.stem.Replace("*", term.term);
                    Question newQuestion = new Question(questionString, stem.bloomLevel, term.subject);
                    uneditedQuestions.Add(newQuestion);
                }
            }
            return uneditedQuestions;
        }

        public List<Question> PromptForQuestion()
        {
            List<Question> editedQuestions = new List<Question>();
            // Display Terms, Prompt for Int, then pisplay Unedited Questions for that term, then Prompt for Integer
            Console.WriteLine("**Add instructions on how to do Question phase task**");
            string reply;
            do
            {
                // prompt for term on a loop

                // prompt for a question on a loop

                // ask if they need to edit the question

                // add question or edited question to list


                reply = Helper.Prompt("Type \"Finished\" if you are ready to move on to the Reading phase. Press Enter to add another question to you Session.");
            } while (!reply.Equals("Finished"));
            return editedQuestions;
        }
    }
}