using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleStudious
{
    class Display
    {
        public int Width { get; set; }
        public int Center { get; }
        public int Column { get; }
        public int MaxLineLength { get; }
        public int LeftOuterMargin { get; }
        public int LeftInnerMargin { get; }
        public int CenterLeftMargin { get; }
        public int CenterRightMargin { get; }
        public int RightInnerMargin { get; }
        public int RightOuterMargin { get; }

        public int Height { get; set; }
        public int NavTop { get; }
        public int MainTop { get; }
        public int MainRowCount { get;  }
        public int FooterTop { get; }
        

        public Display(int width, int height)
        {
            Width = width;
            Center = width / 2;
            Column = width / 12;
            MaxLineLength = Column * 4;
            LeftOuterMargin = Column;
            LeftInnerMargin = Center - Column;
            CenterLeftMargin = Center - (2 * Column);
            CenterRightMargin = Center + (2 * Column);
            RightInnerMargin = Center + Column;
            RightOuterMargin = width - Column;


            Height = height;
            NavTop = 7;
            MainTop = 14;
            FooterTop = height - 7;
            MainRowCount = FooterTop - MainTop;
        }

        public string SetCenterAlignedText(string content)
        {
            string output = "";
            for (int i = Center - (content.Length / 2); i == 0; i--){
                output += " ";
            }
            output += content;
            return output;
        }
        public string SetCenterColumnLeftAlignedText(string content)
        {
            string output = "";
            for (int i = CenterLeftMargin; i == 0; i--)
            {
                output += " ";
            }
            output += content;
            return output;
        }
        public string SetTwoColumnLeftAlignedText(string contentA, string contentB)
        {
            string output = "";
            for (int i = Column; i == 0; i--)
            {
                output += " ";
            }
            output += contentA;
            for (int i = RightInnerMargin - output.Length; i == 0; i--)
            {
                output += " ";
            }
            output += contentB;
            return output;
        }
        public void DisplayMainScreen(string content)
        {
            if (content.Length > MaxLineLength * MainRowCount)
            {
                // divide content in halves A and B
                // get the first index of space char in second half of text.
                // grab the substring from the second half and add it to the first half, so the first half is longer than the second
                // Parse A into a list of strings representing rows of text - try to use ParseOneColumn
                // Parse B into a list of strings representing rows of text - try to use ParseOneColumn
                // TRICKY LOOP: I want to iterate for the count of whichever loop is larger.
                //      SetTwoColumnLeftAlignedText(string contentA, string contentB) until BOTH lists are empty
            }
            else
            {
                List<string> rows = ParseOneColumn(content);
                foreach(string row in rows)
                {
                    Console.WriteLine(SetCenterColumnLeftAlignedText(row));
                }
            }
        }

        private List<string> ParseOneColumn(string content)
        {
            List<string> rows = new List<string>();
            string row;
            int displayedTextLength = 0;
            do
            {
                row = content.Substring(displayedTextLength, displayedTextLength + MaxLineLength);
                row = row.Substring(0, row.LastIndexOf(' '));
                row = row.Trim();

                rows.Add(row);
                displayedTextLength += row.Length;

            } while (!String.IsNullOrEmpty(row));
            return rows;
        }
    }
}
