using System;
using System.Collections.Generic;

namespace ConsoleStudious
{
    class Program
    {
        static void Main(string[] args)
        {
            SessionPhase session = new SessionPhase();
            session.PromptForSessionInfo();

            SurveyPhase survey = new SurveyPhase(session.subjectTitle);
            survey.PromptForSurvey();

            QuestionPhase question = new QuestionPhase(survey.terms);
            question.PromptForQuestion();

            ReadPhase read = new ReadPhase(question.questions);
            read.PromptForRead();

            /*Helper.EmptyLines(5);
            Console.WriteLine("Log of variables:");
            Console.WriteLine($"sessionStart = {session.sessionStart}");
            Console.WriteLine($"subjectTitle = {session.subjectTitle}");
            Console.WriteLine($"goalInHours = {session.goalInHours}");
            Console.WriteLine($"Total survey terms: {survey.terms.Count}");
            Helper.EmptyLines(7);*/


        }

        

        
    }
}
