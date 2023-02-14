using System;
using System.Collections.Generic;

namespace ConsoleStudious
{
    class Program
    {
        static void Main(string[] args)
        {
            Helper.Setup();

            Display display = new Display(156, 63);
            
            // 1,924 characters of lorem ipsum
            display.DisplayMainScreen("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer id interdum purus, id dignissim nibh. Aliquam venenatis tincidunt arcu rhoncus finibus. Cras vel egestas risus. Aenean sit amet diam tristique, finibus tellus ut, convallis turpis. Sed ac nisi dictum, auctor sapien eget, congue dui. Suspendisse blandit augue malesuada, mattis eros eget, tincidunt turpis. Fusce eu interdum dolor. Nulla commodo dolor porttitor cursus venenatis. Etiam varius, ex id ullamcorper mattis, mi dolor consequat nibh, non finibus libero erat ut justo. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nulla condimentum, neque in fermentum aliquam, arcu odio interdum mi, nec viverra diam mauris eu eros. Proin egestas tincidunt lorem, nec vulputate lorem volutpat quis. Proin ut rhoncus diam. Maecenas sit amet dictum sem. Aenean convallis odio eu massa rhoncus sagittis. Praesent semper vitae ipsum vel varius. Morbi sit amet tempor purus. Etiam varius dictum augue at rhoncus. Donec congue volutpat ex a interdum. Nulla lobortis eros ut nunc condimentum, consequat molestie neque ornare. Cras vulputate elit nec accumsan mollis. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Ut velit sapien, finibus at neque in, convallis euismod ipsum. Curabitur fringilla eget metus eget gravida. Proin ligula lectus, consequat et nunc ut, congue pellentesque lacus. Pellentesque fermentum ligula mi, sit amet pulvinar tellus aliquet id.Vestibulum ligula quam, eleifend sit amet sollicitudin ut, consequat commodo sapien. Nunc egestas sapien ipsum, at semper nisl posuere ac. Praesent sem ante, tincidunt in laoreet non, sodales at nisl. Proin pharetra gravida sollicitudin. Donec dapibus tempus mauris id hendrerit. Vivamus auctor dolor at consectetur condimentum. Maecenas pulvinar dignissim quam vel laoreet. Integer iaculis sit amet nisi eget commodo donec.");
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            /*SessionPhase session = new SessionPhase();
            session.PromptForSessionInfo();

            SurveyPhase survey = new SurveyPhase(session.subjectTitle);
            survey.PromptForSurvey();

            QuestionPhase question = new QuestionPhase(survey.terms);
            session.questions = question.PromptForQuestion();

            ReadPhase read = new ReadPhase(question.questions);
            session.questions = read.PromptForRead();*/
        }
    }
}
