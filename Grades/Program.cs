using System;
using System.Collections.Generic;
using System.IO;
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
            GradeBook book = CreateGradeBook(); //constructor, new kw is invoking a new instance of GradeBook

            // These methods were created by highlighting code and ctrl-. to extract method. Too many things on Main method.
            GetBookName(book);
            AddGrades(book);
            SaveGrades(book);
            WriteResults(book);
        }

        private static GradeBook CreateGradeBook()
        {
            return new ThrowAwayGradeBook();
        }

        private static void WriteResults(GradeBook book)
        {
            GradeStatistics stats = book.ComputeStatistics();
            WriteResults("Average", stats.AverageGrade);
            WriteResults("Highest", stats.HighestGrade);
            WriteResults("Lowest", stats.LowestGrade);
            WriteResults(stats.Description, stats.LetterGrade);
        }

        private static void SaveGrades(GradeBook book)
        {
            /*
            StreamWriter outputFile = File.CreateText("grades.txt"); // had to add system.IO namespace to top. Typed "File" ctrl-. to let VS make it easy.
            book.WriteGrades(outputFile);
            outputFile.Close(); // necessary to close the stream otherwise the stream gets buffered and nothing sometimes gets written.
            */

            // This is a better way:
            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outputFile);
                // .Close() isn't needed as the using block does it aoutomatically. StreamWriter has to have that method or dispose() in order for this to work (it does)
            }
        }

        private static void AddGrades(GradeBook book)
        {
            book.AddGrade(91);
            book.AddGrade(89.5f); //The f instructs to make this a float.
            book.AddGrade(75);
        }

        private static void GetBookName(GradeBook book)
        {
            try // b/c the written value could be null and thus throw and exception, we try it first
            {
                Console.WriteLine("Enter a grade book name.");
                book.Name = Console.ReadLine();
            }
            catch (ArgumentException ex) // the ex is a var to hold the exception object thrown.
            {
                Console.WriteLine(ex.Message); // accessing the Message property of the exception. There are many others like stack trace.
            }
            catch (NullReferenceException) // this exception is happening when no one is subscribed to the NameChanged event.
            {
                Console.WriteLine("Something went wrong");
            }
            catch (Exception) // chaining catches. Evaluated in order, so put more specific above less. "Exception" is dangerous
            {
                Console.WriteLine("AACK!");
            }
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
