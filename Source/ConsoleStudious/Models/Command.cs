namespace ConsoleStudious
{
    internal class Command
    {
        public bool Selected { get; set; }
        public bool Locked { get; set; }
        public string Title { get; set; }

        public Command(string title, bool selected)
        {
            Selected = selected;
            Title = title;
        }
    }
}