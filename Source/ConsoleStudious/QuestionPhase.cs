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
                foreach(Stem stem in stems)
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
            bool continueSelectingQuestions = true;
            List<Question> editedQuestions = new List<Question>();
            // Display unedited questions, Prompt for Int, then pisplay Unedited Questions for that term, then Prompt for Integer
            Console.WriteLine("**Add instructions on how to do Question phase task**");
            Console.WriteLine($"Studious has used Bloom's Taxonomy of Knowledge to generate {uneditedQuestions.Count} questions from {terms.Count} terms.");
            Helper.EmptyLines(2);
            Console.WriteLine("Press any key to see them all:");
            Console.ReadKey();
            Console.Clear();
            // display unedited questions
            foreach (Question question in uneditedQuestions)
            {
                Console.WriteLine($"{question.index}. {question.questionString} ({question.stem.bloomLevel} - {question.stem.bloomLabel})");
            };
            Helper.EmptyLines(2);
            Console.WriteLine(@"This is a large number of questions to deal with all at once.
We will group them by the term you copied down from your reading material.
Then we will also group these questions based on their complexity according to Bloom's Taxonomy.
Answering more complex questions will help you gain a deeper level of understanding for each term.

You must select which questions you would like to study this session.
When you select a question you will have the opportunity to edit its text before you add it to your session.

Press any key to see your questions listed by study term.");
            Console.ReadKey();
            Console.Clear();
            do
            {
                Question selectedQuestion = SelectQuestion();
                editedQuestions.Add(selectedQuestion);
                Console.WriteLine($"You have selected {editedQuestions.Count} questions.");
                Helper.EmptyLines(2);
                Console.WriteLine("Hit Enter to add another question to your session or type \"Finished\" to move on to the Reading Phase");
                if (Console.ReadLine().Equals("Finished"))
                {
                    continueSelectingQuestions = false;
                }
            } while (continueSelectingQuestions);

            Console.Clear();
            Console.WriteLine($"You have {editedQuestions.Count} questions in your study session:");
            foreach(Question question in editedQuestions)
            {
                Console.WriteLine($"{question.index}. {question.questionString}");
            }

            return editedQuestions;
        }

        private Question SelectQuestion()
        {
            Question selectedQuestion = null;
            do
            {
                foreach (Term term in terms)
                {
                    for (int i = 1; i < 7; i++)// Hardcoded this, but really it should be a list of Bloom somethings that stops iteration
                    {
                        Console.WriteLine($"Term: {term.term}");
                        Console.WriteLine($"Bloom Level: {uneditedQuestions.FirstOrDefault(q => q.stem.bloomLevel == i).stem.bloomLevel} - \"{uneditedQuestions.FirstOrDefault(q => q.stem.bloomLevel == i).stem.bloomLabel}\"");
                        Helper.EmptyLines(2);
                        foreach (Question question in uneditedQuestions.Where(q => q.stem.bloomLevel == i && q.term.term == term.term))
                        {
                            Console.WriteLine($"{question.index}. {question.questionString}");
                        }
                        Helper.EmptyLines(2);
                        Console.WriteLine("Enter the index number of a question you would like to add to your session, or type nothing and press Enter to see the next set of questions:");
                        string reply = Console.ReadLine();
                        int selectedIndex;
                        bool success = int.TryParse(reply, out selectedIndex);
                        if (success)
                        {
                            Console.Clear();
                            selectedQuestion = uneditedQuestions.FirstOrDefault(q => q.index == selectedIndex);
                            Console.WriteLine($"Selected: {selectedQuestion.questionString}");
                            Console.WriteLine(@"
Enter your edited version below or just press Enter to use the question as it is written.



");
                            reply = Console.ReadLine();
                            if(reply.Length != 0)
                            {
                                selectedQuestion.questionString = reply;// This doesn't belong here at all. Method is SELECT question
                            }
                            Console.WriteLine($"Selected: {selectedQuestion.questionString}");
                            Helper.EmptyLines(2);
                            return selectedQuestion;
                        }
                        Console.Clear();
                    }
                    Console.Clear();
                }
            } while (selectedQuestion == null);

            Console.WriteLine($"Selected: {selectedQuestion.questionString}");
            
            return selectedQuestion;
        }

        
    }
}