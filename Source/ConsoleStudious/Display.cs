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
        private readonly int MainBufferRows = 5;
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
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = Center - (content.Length / 2); i == 0; i--){
                stringBuilder.Append(" ");
            }
            stringBuilder.Append(content);
            return stringBuilder.ToString();
        }
        public string SetCenterColumnLeftAlignedText(string content)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for(int i = CenterLeftMargin; i >= 0; i--)
            {
                stringBuilder.Append(" ");
            }
            stringBuilder.Append(content);
            return stringBuilder.ToString();
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
            if (content.Length > MaxLineLength * (MainRowCount-MainBufferRows))//
            {
                // divide content in halves A and B
                string contentA;
                string contentB;
                                // get the first index of space char in second half of text.
                contentA = content.Substring(0, content.Length / 2);
                contentA = contentA.Substring(0, contentA.LastIndexOf(" "));
                List<string> rowsA = ParseOneColumn(contentA);

                // grab the substring from the second half and add it to the first half, so the first half is longer than the second
                contentB = content.Substring(contentA.Length);
                List<string> rowsB = ParseOneColumn(contentB);
                // TRICKY LOOP: I want to iterate for the count of whichever loop is larger.
                //      SetTwoColumnLeftAlignedText(string contentA, string contentB) until BOTH lists are empty
            }
            else
            {
                List<string> rows = ParseOneColumn(content);
                if (rows.Count <= MainRowCount)
                {
                    foreach (string row in rows)
                    {
                        Console.WriteLine(SetCenterColumnLeftAlignedText(row));
                    }
                }
                else
                {
                    Console.WriteLine("ERROR: Too much content");
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
