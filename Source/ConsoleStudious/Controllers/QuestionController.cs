using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleStudious
{
    internal class QuestionController : Controller
    {
        private List<Term> terms { get; set; }
        private List<Stem> stems { get; set; }
        private List<Question> uneditedQuestions { get; set; }
        public List<Question> questions { get; set; }

        public QuestionController(List<Term> termsValue)
        {
            terms = termsValue;
            stems = Stem.GenerateBloomStems();
            uneditedQuestions = GenerateUneditedQuestions();
            StartTime = DateTime.Now;
        }

        public List<Question> PromptForQuestion()
        {
            string input;
            List<Question> editedQuestions = new List<Question>();

            ProvideInstructions();

            do
            {
                Question selectedQuestion = Helper.SelectQuestionByTermByBloom(uneditedQuestions);
                selectedQuestion = EditQuestion(selectedQuestion);
                editedQuestions.Add(selectedQuestion);
                Console.WriteLine($"You have added {editedQuestions.Count} questions to your session so far.");
                Helper.EmptyLines(2);
                input = Helper.Prompt("Hit Enter to add another question to your session or type \"Finished\" to move on to the Reading Phase");           

            } while (!input.Equals("Finished"));

            ClosingMessage(editedQuestions);
            questions = editedQuestions;
            return editedQuestions;
        }       

        private void ProvideInstructions()
        {
            Console.WriteLine("Question Phase instructions go here...");
            Helper.AnyKeyToContinue();
        }

        private static void ClosingMessage(List<Question> editedQuestions)
        {
            Console.Clear();
            Console.WriteLine($"You have {editedQuestions.Count} questions in your study session:");
            Helper.AnyKeyToContinue();
        }

        private List<Question> GenerateUneditedQuestions()
        {
            uneditedQuestions = new List<Question>();
            int questionCounter = 0;
            var random = new Random();
            int randomIndex;

            foreach (Term term in terms)
            {
                foreach (Stem stem in stems)
                {
                    string questionString;

                    do
                    {
                        randomIndex = random.Next(terms.Count);
                    } while (randomIndex == terms.IndexOf(term));

                    questionString = stem.stem.Replace("**", terms[randomIndex].term);
                    questionString = questionString.Replace("*", term.term);
                    questionCounter++; // start counting at 1

                    Question newQuestion = new Question(questionCounter, questionString, stem, term);

                    uneditedQuestions.Add(newQuestion);
                }
            }
            return uneditedQuestions;
        }

        private Question EditQuestion(Question question)
        {
            string input; 
            Console.WriteLine("Edit the following:");
            Helper.EmptyLines(2);
            Console.WriteLine(question.questionString);
            Helper.EmptyLines(2);
            Console.WriteLine("Enter your edited version below or just press Enter to use the question as it is written.");
            Helper.EmptyLines(2);

            input = Console.ReadLine();
            if (input.Length != 0)
            {
                question.questionString = input;
            }

            Console.WriteLine($"Your finished question: {question.questionString}");
            Helper.EmptyLines(2);
            Helper.AnyKeyToContinue();

            return question;
        }
    }
}