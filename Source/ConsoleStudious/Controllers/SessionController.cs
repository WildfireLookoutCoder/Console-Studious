using System;
using System.Collections.Generic;

namespace ConsoleStudious
{
    class SessionController : Controller
    {
        public string subjectTitle { get; set; }
        public double goalInHours { get; set; }
        internal List<Question> questions;
        public SessionController()
        {

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