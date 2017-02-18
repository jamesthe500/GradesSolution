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
           
            GradeBook book = new GradeBook(); //constructor, new kw is invoking a new instance of GradeBook

            book.AddGrade(91);
            book.AddGrade(89.5f); //The f instructs to make this a float.
            book.AddGrade(75);
            book.WriteGrades(Console.Out);

            GradeStatistics stats = book.ComputeStatistics();
            WriteResults("Average", stats.AverageGrade);
            WriteResults("Highest", stats.HighestGrade);
            WriteResults("Lowest", stats.LowestGrade);
            WriteResults(stats.Description, stats.LetterGrade);
        }

        static void WriteResults(string description, float result)
        {
            
            Console.WriteLine($"{description}: {result:F2}");

        }
        
        static void WriteResults(string description, string result)
        {

            Console.WriteLine($"{description}: {result}");

        }
    }

}
