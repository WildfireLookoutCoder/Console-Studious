using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleStudious
{
    class Display
    {

        // ToDo: At the end of the project go through these properties and clean out any that are unused.
        // ToDo: Make sure display methods can handle content with new line characters

        /*

            \' - single quote, needed for character literals
            \" - double quote, needed for string literals
            \\ - backslash
            \0 - Unicode character 0
            \a - Alert (character 7)
            \b - Backspace (character 8)
            \f - Form feed (character 12)
            \n - New line (character 10)
            \r - Carriage return (character 13)
            \t - Horizontal tab (character 9)
            \v - Vertical tab (character 11)

        */

        public int Width { get; set; }
        public int Height { get; set; }
        public int Center { get; }
        public int Column { get; }
        public int MaxLineLength { get; }
        public int LeftOuterMargin { get; }
        public int LeftInnerMargin { get; }
        public int CenterLeftMargin { get; }
        public int CenterRightMargin { get; }
        public int RightInnerMargin { get; }
        public int RightOuterMargin { get; }        
        public int NavTop { get; }
        public int MainTop { get; }
        public int MainRowCount { get;  }
        public int MainBufferRows = 5;
        public int FooterTop { get; }
        

        public Display(int width, int height)
        {
            Width = width;
            Height = height;

            Center = width / 2;
            Column = width / 12;
            MaxLineLength = Column * 4;
            LeftOuterMargin = Column;
            LeftInnerMargin = Center - Column;
            CenterLeftMargin = Center - (2 * Column);
            CenterRightMargin = Center + (2 * Column);
            RightInnerMargin = Center + Column;
            RightOuterMargin = width - Column;
            NavTop = 7;
            MainTop = 14;
            FooterTop = height - 7;
            MainRowCount = FooterTop - MainTop;

            Console.Title = "Console Studious";
            Console.WindowWidth = width;
            Console.WindowHeight = height;
            SetTextColourNormal();
        }

        public string Screen(List<Command> commands, string content, string prompt, string error)
        {
            Console.Clear();
            SetTextColourNormal();
            DisplayHeader();
            DisplayNavigation(commands);
            DisplaySystemStatus();
            DisplayMain(content);
            return DisplayFooter(prompt, error);
        }
        internal void DisplayHeader()
        {
            Console.WriteLine(SetHorizontalRule());
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(SetCenterAlignedText("STUDIOUS"));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(SetHorizontalRule());
        }
        internal void DisplayNavigation(List<Command> commands)
        {
            // This method abandons the StringBuilder because we will want to switch Console properties mid-line.
            // We can access the length of the written line via Console.Out.ToString().Length, but I had trouble finding the formula to snap 
            Console.WriteLine();
            Console.Write(new string(' ', Column)); // We want the whole navbar on one line of text.
            foreach (Command command in commands)
            {
                if (command.Selected)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }                
                Console.Write(command.Title);
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(new string(' ', Column));
            }
            Console.WriteLine(); // ends the current line
            Console.WriteLine(); // one line of empty space
            Console.WriteLine(SetHorizontalRule());
        }
        internal void DisplaySystemStatus()
        {
            Console.WriteLine();
            Console.WriteLine(SetCenterAlignedText("System Status: Coming Soon..."));
            Console.WriteLine();
            Console.WriteLine(SetHorizontalRule());
        }
        internal void DisplayMain(string content)
        {
            Console.WriteLine();
            if (content.Length > MaxLineLength * (MainRowCount - MainBufferRows))
            {
                List<string> rows = ParseTwoColumns(content);
                if (rows.Count <= MainRowCount)
                {
                    foreach (string row in rows)
                    {
                        Console.WriteLine(row);
                    }
                }
                else
                {
                    Console.WriteLine("ERROR: Too much content");
                }
            }
            else
            {
                List<string> rows = ParseOneColumn(content);
                if (rows.Count <= MainRowCount)
                {
                    foreach (string row in rows)
                    {
                        Console.WriteLine(SetLeftAlignedText(row, CenterLeftMargin));
                    }
                }
                else
                {
                    Console.WriteLine("ERROR: Too much content");
                }

            }
            Console.WriteLine();
            Console.WriteLine(SetHorizontalRule());
        }
        internal string DisplayFooter(string prompt, string error)
        {
            Console.WriteLine();
            Console.WriteLine(SetLeftAlignedText(prompt, LeftOuterMargin));
            SetEmptyLines(5);
            Console.Write(new string(' ', Column));
            SetTextColourHighlighted();
            Console.WriteLine(!string.IsNullOrEmpty(error) ? error : "");
            SetTextColourNormal();
            Console.WriteLine(SetHorizontalRule());
            Console.WriteLine();
            Console.SetCursorPosition(Column, Console.CursorTop - 6);
            return Console.ReadLine();
        }

        private void SetTextColourNormal()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
        }
        private void SetTextColourHighlighted()
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        private string SetCenterAlignedText(string content)
        {
            StringBuilder stringBuilder = new StringBuilder(new string(' ', Center - (content.Length / 2)));
            stringBuilder.Append(content);
            return stringBuilder.ToString();
        }
        private string SetLeftAlignedText(string content, int margin)
        {
            StringBuilder stringBuilder = new StringBuilder(new string(' ', margin));
            stringBuilder.Append(content);
            return stringBuilder.ToString();
        }
        private string SetLeftAlignedText(string contentA, string contentB)
        {
            StringBuilder stringBuilder = new StringBuilder(new string(' ', Column));
            stringBuilder.Append(contentA);
            for (int i = stringBuilder.Length; i <= RightInnerMargin; i++)
            {
                stringBuilder.Append(" ");
            }
            stringBuilder.Append(contentB);
            return stringBuilder.ToString();
        }
        private string SetHorizontalRule()
        {
            StringBuilder stringBuilder = new StringBuilder(new string('-', Width));
            return stringBuilder.ToString();
        }
        private void SetEmptyLines(int lines)
        {
            for (int i = 0; i < lines; i++)
            {
                Console.WriteLine();
            }
        }


        private List<string> ParseTwoColumns(string content)
        {
            // divide content in halves A and B
            string contentA;
            string contentB;
            int rowMax;
            List<string> output = new List<string>();
            // get the first index of space char in second half of text.
            contentA = content.Substring(0, content.Length / 2);
            contentA = contentA.Substring(0, contentA.LastIndexOf(" "));
            List<string> rowsA = ParseOneColumn(contentA);
            contentB = content.Substring(contentA.Length);
            List<string> rowsB = ParseOneColumn(contentB);
            // TRICKY LOOP: I want to iterate for the count of whichever loop is larger.
            //      SetTwoColumnLeftAlignedText(string contentA, string contentB) until BOTH lists are empty
            if (rowsA.Count > rowsB.Count)
            {
                rowsB.Add("");
                rowMax = rowsA.Count;
            }
            else
            {
                rowsA.Add("");
                rowMax = rowsB.Count;
            }

            for (int i = 0; i < rowMax; i++)
            {
                output.Add(SetLeftAlignedText(rowsA[i], rowsB[i]));
            }

            return output;
        }
        private List<string> ParseOneColumn(string content)
        {
            List<string> rows = new List<string>();
            string row;
            int displayedTextLength = 0;
            do
            {
                row = displayedTextLength < content.Length ? content.Substring(displayedTextLength) : null;
                if (!string.IsNullOrEmpty(row))
                {


                    row = row.Length > MaxLineLength ? row.Substring(0, MaxLineLength) : row;
                    row = displayedTextLength + row.Length != content.Length && !content.Substring(row.Length + displayedTextLength).StartsWith(" ") ? row.Substring(0, row.LastIndexOf(' ')) : row;

                    displayedTextLength += row.Length;

                    row = row.Trim();

                    rows.Add(row);
                }
                

            } while (!string.IsNullOrEmpty(row));
            return rows;
        }

        
    }
}
