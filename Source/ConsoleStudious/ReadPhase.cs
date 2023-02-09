﻿using System;
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
        public List<Question> PromptForRead()
        {
            string input;
            Question selectedQuestion;

            ProvideInstructions();

            do
            {
                Helper.DisplayQuestions(questions);
                selectedQuestion = Helper.SelectQuestionByTermByBloom(questions);

                Answer answer = new Answer(selectedQuestion);

                selectedQuestion.AddAnswer(answer);

                input = Helper.Prompt("Hit Enter to answer another question, or type \"Finished\" to move on to the Recite Phase");

            } while (!input.Equals("Finished"));

            ClosingMessage();

            return questions;
        }

        private void ProvideInstructions()
        {
            Console.WriteLine("Read Phase instructions go here");
            Helper.AnyKeyToContinue();
        }

        private void ClosingMessage()
        {
            Console.WriteLine("Read Phase summary goes here");
            Helper.AnyKeyToContinue();
        }
    }
}