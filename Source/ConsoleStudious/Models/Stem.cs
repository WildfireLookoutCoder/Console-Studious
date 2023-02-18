using System;
using System.Collections.Generic;

namespace ConsoleStudious
{
    public class Stem
    {
        public string stem { get; set; }
        public string bloomLabel { get; set; }
        public int bloomLevel { get; set; }
        public Stem(string stemValue, string bloomLabelValue, int bloomLevelValue)
        {
            stem = stemValue;
            bloomLabel = bloomLabelValue;
            bloomLevel = bloomLevelValue;
        }

        internal static List<Stem> GenerateBloomStems()
        {
            List<Stem> stems = new List<Stem>();
            stems.Add(new Stem("What do you remember about *?", "Knowledge", 1));
            stems.Add(new Stem("How would you define *?", "Knowledge", 1));
            stems.Add(new Stem("How would you identify *?", "Knowledge", 1));
            stems.Add(new Stem("How would you recognize *?", "Knowledge", 1));
            stems.Add(new Stem("What would you choose *?", "Knowledge", 1));
            stems.Add(new Stem("Describe what happens when *?", "Knowledge", 1));
            stems.Add(new Stem("How is (are) *?", "Knowledge", 1));
            stems.Add(new Stem("Where is (are) *?", "Knowledge", 1));
            stems.Add(new Stem("Which one *?", "Knowledge", 1));
            stems.Add(new Stem("Who was *?", "Knowledge", 1));
            stems.Add(new Stem("Why did *?", "Knowledge", 1));
            stems.Add(new Stem("What is (are) *?", "Knowledge", 1));
            stems.Add(new Stem("When did *?", "Knowledge", 1));
            stems.Add(new Stem("How would you outline *?", "Knowledge", 1));
            stems.Add(new Stem("List the * in order.", "Knowledge", 1));
            stems.Add(new Stem("How would you compare * with **?", "Comprehension", 2));
            stems.Add(new Stem("How would you contrast * with **?", "Comprehension", 2));
            stems.Add(new Stem("How would you clarify the meaning of *?", "Comprehension", 2));
            stems.Add(new Stem("How would you differentiate between * and **?", "Comprehension", 2));
            stems.Add(new Stem("How would you generalize *?", "Comprehension", 2));
            stems.Add(new Stem("How would you express *?", "Comprehension", 2));
            stems.Add(new Stem("What can you infer from *?", "Comprehension", 2));
            stems.Add(new Stem("What did you observe *?", "Comprehension", 2));
            stems.Add(new Stem("How would you identify *?", "Comprehension", 2));
            stems.Add(new Stem("How can you describe *?", "Comprehension", 2));
            stems.Add(new Stem("Will you restate *?", "Comprehension", 2));
            stems.Add(new Stem("Elaborate on *.", "Comprehension", 2));
            stems.Add(new Stem("What would happen if *?", "Comprehension", 2));
            stems.Add(new Stem("What is the main idea of *?", "Comprehension", 2));
            stems.Add(new Stem("What can you say about *?", "Comprehension", 2));
            stems.Add(new Stem("What actions would you take to perform *?", "Application", 3));
            stems.Add(new Stem("How would you develop _____________ to present *?", "Application", 3));
            stems.Add(new Stem("What other way would you choose to *?", "Application", 3));
            stems.Add(new Stem("What would the result be if *?", "Application", 3));
            stems.Add(new Stem("How would you demonstrate *?", "Application", 3));
            stems.Add(new Stem("How would you present *?", "Application", 3));
            stems.Add(new Stem("How would you change *?", "Application", 3));
            stems.Add(new Stem("How would you modify *?", "Application", 3));
            stems.Add(new Stem("How could you develop *?", "Application", 3));
            stems.Add(new Stem("Why does * work ?", "Application", 3));
            stems.Add(new Stem("How would you alter * to **?", "Application", 3));
            stems.Add(new Stem("What examples can you find that *?", "Application", 3));
            stems.Add(new Stem("How would you solve *?", "Application", 3));
            stems.Add(new Stem("How can you classify * according to _____________?", "Analysis", 4));
            stems.Add(new Stem("How can you compare the different parts *?", "Analysis", 4));
            stems.Add(new Stem("What explanation do you have for *?", "Analysis", 4));
            stems.Add(new Stem("How is * connected to **?", "Analysis", 4));
            stems.Add(new Stem("Discuss the pros and cons of *.", "Analysis", 4));
            stems.Add(new Stem("How can you sort the parts *?", "Analysis", 4));
            stems.Add(new Stem("What is the analysis of *?", "Analysis", 4));
            stems.Add(new Stem("What can you infer *?", "Analysis", 4));
            stems.Add(new Stem("What ideas validate *?", "Analysis", 4));
            stems.Add(new Stem("How would you explain *?", "Analysis", 4));
            stems.Add(new Stem("What can you point out about *?", "Analysis", 4));
            stems.Add(new Stem("What is the problem with *?", "Analysis", 4));
            stems.Add(new Stem("Why do you think *?", "Analysis", 4));
            stems.Add(new Stem("What criteria would you use to assess *?", "Evaluation", 5));
            stems.Add(new Stem("What data was used to evaluate *?", "Evaluation", 5));
            stems.Add(new Stem("What choice would you have made *?", "Evaluation", 5));
            stems.Add(new Stem("How would you determine the facts *?", "Evaluation", 5));
            stems.Add(new Stem("What is the most important *?", "Evaluation", 5));
            stems.Add(new Stem("What would you suggest *?", "Evaluation", 5));
            stems.Add(new Stem("How would you grade *?", "Evaluation", 5));
            stems.Add(new Stem("What is your opinion of *?", "Evaluation", 5));
            stems.Add(new Stem("How could you verify *?", "Evaluation", 5));
            stems.Add(new Stem("What information would you use to prioritize *?", "Evaluation", 5));
            stems.Add(new Stem("Rate the *.", "Evaluation", 5));
            stems.Add(new Stem("Rank the importance of *.", "Evaluation", 5));
            stems.Add(new Stem("Determine the value of *.", "Evaluation", 5));
            stems.Add(new Stem("What alternative would you suggest for *?", "Synthesis", 6));
            stems.Add(new Stem("What changes would you make to revise *?", "Synthesis", 6));
            stems.Add(new Stem("How would you explain the reason *?", "Synthesis", 6));
            stems.Add(new Stem("How would you generate a plan to *?", "Synthesis", 6));
            stems.Add(new Stem("What could you invent with *?", "Synthesis", 6));
            stems.Add(new Stem("What facts can you gather about *?", "Synthesis", 6));
            stems.Add(new Stem("Predict the outcome if *.", "Synthesis", 6));
            stems.Add(new Stem("What would happen if *?", "Synthesis", 6));
            stems.Add(new Stem("How would you portray *?", "Synthesis", 6));
            stems.Add(new Stem("Devise a way to *.", "Synthesis", 6));
            stems.Add(new Stem("How would you compile the facts for *?", "Synthesis", 6));
            stems.Add(new Stem("How would you elaborate on the reason *?", "Synthesis", 6));
            stems.Add(new Stem("How would you improve *?", "Synthesis", 6));
            return stems;
        }
    }
}