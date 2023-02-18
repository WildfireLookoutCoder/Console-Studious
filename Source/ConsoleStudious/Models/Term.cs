using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleStudious
{
    public class Term
    {
        public string term { get; set; }
        public string subject { get; set; }
        public int label { get; set; }
        public Term(int labelValue, string termValue, string subjectValue)
        {
            term = termValue;
            subject = subjectValue;
            label = labelValue;
        }
        
    }
    
}
