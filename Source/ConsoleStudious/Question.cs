using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleStudious
{
    public class Question
    {
        public int label { get; set; }
        public string questionString { get; set; }
        public Stem stem { get; set; }
        public Term term { get; set; }
        private List<Answer> answers { get; set; }

        public Question(int labelValue, string questionStringValue, Stem stemValue, Term termValue)
        {
            label = labelValue;
            questionString = questionStringValue;
            stem = stemValue;
            term = termValue;
            answers = new List<Answer>();
        }

        internal void AddAnswer(Answer answer)
        {
            answers.Add(answer);
        }
    }
}