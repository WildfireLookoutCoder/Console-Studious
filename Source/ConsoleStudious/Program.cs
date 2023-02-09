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
            session.questions = question.PromptForQuestion();

            ReadPhase read = new ReadPhase(question.questions);
            session.questions = read.PromptForRead();
        }
    }
}
