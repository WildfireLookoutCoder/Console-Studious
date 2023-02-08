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

            return editedQuestions;
        }

        private static void ClosingMessage(List<Question> editedQuestions)
        {
            Console.Clear();
            Console.WriteLine($"You have {editedQuestions.Count} questions in your study session:");
            foreach (Question question in editedQuestions)
            {
                Console.WriteLine($"{question.label}. {question.questionString}");
            }
        }

        private void ProvideInstructions()
        {
            // Display unedited questions, Prompt for Int, then pisplay Unedited Questions for that term, then Prompt for Integer
            Console.WriteLine($"Studious has used Bloom's Taxonomy of Knowledge to generate {uneditedQuestions.Count} questions from {terms.Count} terms.");
            Helper.EmptyLines(2);
            Console.WriteLine("Press any key to see them all:");
            Helper.EmptyLines(2);
            Console.ReadKey();
            Console.Clear();
            // display unedited questions
            foreach (Question question in uneditedQuestions)
            {
                Console.WriteLine($"{question.label}. {question.questionString} ({question.stem.bloomLevel} - {question.stem.bloomLabel})");
            };
            Helper.EmptyLines(2);
            Console.WriteLine(@"This is a large number of questions to deal with all at once.
We will group them by the term you copied down from your reading material.
Then we will also group these questions based on their complexity according to Bloom's Taxonomy.
Answering more complex questions will help you gain a deeper level of understanding for each term.

You must select which questions you would like to study this session.
When you select a question you will have the opportunity to edit its text before you add it to your session.");
            Helper.EmptyLines(2);
            Helper.AnyKeyToContinue();
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