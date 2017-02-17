using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
           
            //SpeechSynthesizer synth = new SpeechSynthesizer();
            //synth.Speak("Hello! I'm going to speak your grades.");

            GradeBook book = new GradeBook(); //constructor, new kw is invoking a new instance of GradeBook

            book.NameChanged += OnNameChanged; 
            book.NameChanged += OnNameChanged2;
            book.NameChanged += OnNameChanged2;
            book.NameChanged -= OnNameChanged2; // note, -= only wipes out one of the callings.

            book.Name = "Scott's Grade Book";
            book.Name = "Jim's Grade Book";
            book.Name = null; // b/c of the setter properties, it ignores this line. 
            book.AddGrade(91);
            book.AddGrade(89.5f); //The f instructs to make this a float.
            book.AddGrade(75);

            GradeStatistics stats = book.ComputeStatistics();
            Console.WriteLine(book.Name);
            WriteResults("Average", stats.AverageGrade);
            WriteResults("Highest", (int)stats.HighestGrade); // converts to an int in the calling
            WriteResults("Lowest", stats.LowestGrade);

        }

        static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Grade book changing name from {args.ExistingName} to {args.NewName}");
        }

        static void OnNameChanged2(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine("***");
        }

        // Helper method
        static void WriteResults(string desctiption, int result)
        {
            Console.WriteLine(desctiption + ": " + result); // SNIPPET - cw (tab tab) 
        }

        static void WriteResults(string description, float result)
        {
            //Console.WriteLine(desctiption + ": " + result); // stirng concat

            // same result with formatting string. It's an overload of the WriteLine method.
            // { 0} and {1} are placeholders that look in the array of params passed in second part.
            //Console.WriteLine("{0}: {1}", description, result); 

            // In this example, string formatting is done to make it a float with two decimal places
            // another one is to put a C in the place of F2, you'll get it as a currency.
            // There are many string formatting tricks like this.
            //Console.WriteLine("{0}: {1:F2}", description, result);

            // with C# 6, you can write it this way, which is even more clear:
            Console.WriteLine($"{description}: {result:F2}");

        }
    }

}
