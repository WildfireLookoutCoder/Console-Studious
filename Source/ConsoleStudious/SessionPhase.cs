using System;

namespace ConsoleStudious
{
    public class SessionPhase
    {
        public DateTime sessionStart { get; set; }
        public string subjectTitle { get; set; }
        public double goalInHours { get; set; }
        public SessionPhase()
        {

        }
        public void PromptForSessionInfo()
        {
            ProvideInstructions();

            sessionStart = DateTime.Now;
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