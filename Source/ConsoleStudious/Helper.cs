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
            Helper.EmptyLines(2);
            var reply = Console.ReadLine();
            Console.Clear();
            return reply;
        }

        internal static void Setup()
        {
            /*

            \' - single quote, needed for character literals
            \" - double quote, needed for string literals
            \\ - backslash
            \0 - Unicode character 0
            \a - Alert (character 7)
            \b - Backspace (character 8)
            \f - Form feed (character 12)
            \n - New line (character 10)
            \r - Carriage return (character 13)
            \t - Horizontal tab (character 9)
            \v - Vertical tab (character 11)

             */
            
            Console.Title = "Console Studious";            

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkGreen;

            Console.WindowWidth = 156;
            // Wide enough for 12 columns of 13 character-columns each
            // Col 78 is halfway point for whole screen
            // Col ((c-1)13 + 7) is center of column indicated by c
            Console.WindowHeight = 63;
            // Rule of Thirds = 20 characters per row

            Console.TreatControlCAsInput = false; // THis allows pating content from clipboard
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
                    EmptyLines(2);
                    Console.WriteLine(prompt);
                }
            } while (!success);

            return num;
        }
        internal static void AnyKeyToContinue()
        {
            Console.WriteLine("Press any key to continue...");
            EmptyLines(2);
            Console.ReadKey();
            Console.Clear();
        }
        internal static void EmptyLines(int lines)
        {
            for (int i = 0; i < lines; i++)
            {
                Console.WriteLine();
            }
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
            EmptyLines(2);
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
                EmptyLines(2);
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
                EmptyLines(2);

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
            EmptyLines(2);
            AnyKeyToContinue();

            return selectedQuestion;
        }

    }
}
