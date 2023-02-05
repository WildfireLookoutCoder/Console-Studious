using System;

namespace ConsoleStudious
{
    public class SessionPhase
    {
        public DateTime sessionStart { get; set; }
        public string subjectTitle { get; set; }
        public double goalInHours { get; set; }

        public void PromptForSessionInfo()
        {
            this.sessionStart = DateTime.Now;
            this.subjectTitle = Helper.Prompt($"What are we studying {Helper.Nowish()}?");
            this.goalInHours = Double.Parse(Helper.Prompt($"And how long (in hours) are we intending to study {subjectTitle} tonight?"));
            
        }
        public SessionPhase()
        {

        }
    }
}