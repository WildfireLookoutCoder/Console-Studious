using System;
using System.Collections.Generic;

namespace ConsoleStudious
{
    public class ReadPhase
    {
        private List<Question> questions { get; set; }
        
        public ReadPhase(List<Question> questionsValue)
        {
            questions = questionsValue;
        }
        public void PromptForRead()
        {
            bool answerAnotherQuestion = true;
            ProvideInstructions();
            do
            {

            } while (answerAnotherQuestion);
        }

        private void ProvideInstructions()
        {
            
        }
    }
}