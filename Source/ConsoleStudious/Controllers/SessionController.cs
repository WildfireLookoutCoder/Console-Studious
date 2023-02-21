using System;
using System.Collections.Generic;

namespace ConsoleStudious
{
    class SessionController : Controller
    {
        public string SubjectTitle { get; set; }
        public double GoalInHours { get; set; }
        public List<Question> Questions { get; set; }
        public Display Display { get; set; }
        public SessionController(Display display)
        {
            Display = display;
            Questions = new List<Question>();
            Commands.Add(new Command("Session", true));
            
            /*commands.Add(new Command("Survey", false));
            commands.Add(new Command("Question", true));
            commands.Add(new Command("Read", false));
            commands.Add(new Command("Recite", false));
            commands.Add(new Command("Review", false));*/
        }

        public void PromptForReadingMaterials()
        {
            do
            {
                Input = Display.Screen(Commands, Content, Prompt, Error);
            } while (string.IsNullOrEmpty(Input));
        }

        public void PromptForSessionInfo()
        {
            ProvideInstructions();

            StartTime = DateTime.Now;
            subjectTitle = Helper.Prompt($"What are we studying {Helper.Nowish()}?");
            // goalInHours = Helper.PromptForInt($"And how many hours are we intending to study {subjectTitle} tonight?");

            ClosingMessage();
        }
        private void ProvideInstructions()
        {
            Console.WriteLine("Session Info instructions go here");
            Helper.AnyKeyToContinue();
        }
        private static void ClosingMessage()
        {
            Console.WriteLine("Session closing messages go here");
            Helper.AnyKeyToContinue();
        }

    }
}