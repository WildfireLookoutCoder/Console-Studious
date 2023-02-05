using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleStudious
{
    class Helper
    {
        public static string Prompt(string prompt)
        {
            Console.WriteLine(prompt);
            var reply = Console.ReadLine();
            Console.Clear();
            return reply;
        }
        public static void EmptyLines(int lines)
        {
            for (int i = 0; i < lines; i++)
            {
                Console.WriteLine();
            }
        }
        public static string Nowish()
        {
            var nowish = "today";

            if (DateTime.Now.Hour >= 3 && DateTime.Now.Hour < 12)
            {
                nowish = "this morning";
            }
            else if (DateTime.Now.Hour >= 12 && DateTime.Now.Hour < 18)
            {
                nowish = "this afternoon";
            }
            else if (DateTime.Now.Hour >= 18 && DateTime.Now.Hour < 20)
            {
                nowish = "this evening";
            }
            else if (DateTime.Now.Hour >= 20 || DateTime.Now.Hour < 3)
            {
                nowish = "tonight";
            }
            return nowish;
        }

        internal static int PromptForInt(string prompt)
        {
            int num;
            while (!int.TryParse(Prompt(prompt), out num))
                Console.WriteLine("Try again");
            return num;
        }
    }
}
