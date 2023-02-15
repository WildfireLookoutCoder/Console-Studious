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

        public void DisplayMainScreen(string content)
        {
            if (content.Length > MaxLineLength * (MainRowCount - MainBufferRows))//
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
        public string SetLeftAlignedText(string content, int margin)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < margin; i++)
            {
                stringBuilder.Append(" ");
            }
            stringBuilder.Append(content);
            return stringBuilder.ToString();
        }
        public string SetLeftAlignedText(string contentA, string contentB)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < Column; i++)
            {
                stringBuilder.Append(" ");
            }
            stringBuilder.Append(contentA);
            for (int i = stringBuilder.Length; i <= RightInnerMargin; i++)
            {
                stringBuilder.Append(" ");
            }
            stringBuilder.Append(contentB);
            return stringBuilder.ToString();
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
