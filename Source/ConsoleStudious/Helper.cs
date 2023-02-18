using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleStudious
{
    public class Helper
    {
        internal static string Prompt(string prompt)
        {
            Console.WriteLine(prompt);
            // SetEmptyLines(2);
            var reply = Console.ReadLine();
            Console.Clear();
            return reply;
        }

        internal static int PromptForInt(string prompt)
        {
            int num;
            bool success;
            do
            {
                success = int.TryParse(Prompt(prompt), out num);
                if (!success)
                {
                    Console.Clear();
                    Console.WriteLine("That is not a number, try again.");
                    // EmptyLines(2);
                    Console.WriteLine(prompt);
                }
            } while (!success);

            return num;
        }
        internal static void AnyKeyToContinue()
        {
            Console.WriteLine("Press any key to continue...");
            // EmptyLines(2);
            Console.ReadKey();
            Console.Clear();
        }
        
        internal static string Nowish()
        {
            var nowish = "today";

            if (DateTime.Now.Hour >= 3 && DateTime.Now.Hour < 12)
            {
                nowish = "this morning";
            }
            else if (DateTime.Now.Hour >= 12 && DateTime.Now.Hour < 18)
            {
                nowish = "this afternoon";
            }
            else if (DateTime.Now.Hour >= 18 && DateTime.Now.Hour < 20)
            {
                nowish = "this evening";
            }
            else if (DateTime.Now.Hour >= 20 || DateTime.Now.Hour < 3)
            {
                nowish = "tonight";
            }
            return nowish;
        }
        internal static void DisplayTerms(List<Term> terms)
        {
            foreach (Term term in terms)
            {
                Console.Write($"{term.label}.  {term.term}, ");
            }
            // EmptyLines(2);
        }
        internal static Term SelectTerm(List<Term> terms)
        {
            int selectedIndex;
            Term selectedTerm = null;

            do
            {
                Console.WriteLine("Current List of All Terms");
                DisplayTerms(terms);
                selectedIndex = PromptForInt("Type a number to indicate your selection:");
                selectedTerm = terms.FirstOrDefault(t => t.label == selectedIndex);
                Console.Clear();
            } while (selectedTerm == null);

            /*Console.WriteLine($"You have selected {selectedTerm.label}. {selectedTerm.term}");
            EmptyLines(2);
            AnyKeyToContinue();*/

            return selectedTerm;
        }
        internal static void DisplayQuestions(List<Question> questions)
        {
            if (questions.Count > 0)
            {
                foreach (Question question in questions)
                {
                    Console.WriteLine($"{question.label}.  {question.questionString}");
                }
                // EmptyLines(2);
            }
        }
        internal static Question SelectQuestionByTermByBloom(List<Question> questions)
        {
            int bloomLevel = 1;
            int selectedIndex;
            string input;
            Term selectedTerm = null;
            Question selectedQuestion = null;
            List<Term> terms = new List<Term>();

            foreach (Question question in questions)
            {
                if(!terms.Contains(question.term))
                    terms.Add(question.term);
            }

            Console.WriteLine("Which term would you like to select a question for?");
            selectedTerm = SelectTerm(terms);

            do
            {
                Console.WriteLine($"Term: {selectedTerm.term}");
                Console.WriteLine($"Bloom Level: {questions.FirstOrDefault(q => q.stem.bloomLevel == bloomLevel).stem.bloomLevel} - \"{questions.FirstOrDefault(q => q.stem.bloomLevel == bloomLevel).stem.bloomLabel}\"");
                // EmptyLines(2);

                DisplayQuestions(questions.Where(q => q.stem.bloomLevel == bloomLevel && q.term == selectedTerm).ToList());

                bloomLevel++;

                if (bloomLevel > 6) {
                    bloomLevel = 1;
                }

                input = Prompt("Type a number to indicate your selection or just press Enter to see the next group of questions:");

                if (int.TryParse(input, out selectedIndex))
                {
                    selectedQuestion = questions.FirstOrDefault(q => q.label == selectedIndex);
                }

                Console.Clear();

            } while (selectedQuestion == null);

            Console.WriteLine($"You have selected {selectedQuestion.label}. {selectedQuestion.questionString}");
            // EmptyLines(2);
            AnyKeyToContinue();

            return selectedQuestion;
        }

    }
}
