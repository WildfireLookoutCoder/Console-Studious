using System;
using System.Collections.Generic;

namespace ConsoleStudious
{
    internal class Controller
    {
        public DateTime StartTime { get; set; }
        public List<Command> Commands { get; set; }
        public string Content { get; set; }
        public string Prompt { get; set; }
        public string Error { get; set; }
        public string Input { get; set; }
    }
}