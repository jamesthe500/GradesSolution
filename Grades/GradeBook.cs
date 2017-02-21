using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook : GradeTracker // for the abstract class, it must inherit from it.
    {
        public GradeBook() // constructor, custom. Default (doesn't take parameters)
        {
            _name = "default grade book";
            grades = new List<float>(); // This is brought from below. new instance of List FIELD with every instance of GradeBook.
        } 

        public override GradeStatistics ComputeStatistics() // switched to override becasue now ComputeStatistics is providing an implementation for the abstract in GradTracker
        {
            Console.WriteLine("gb::Compute statistics"); // This was to test which "ComputeStatistics was being called. It was this one.
            GradeStatistics stats = new GradeStatistics();

            float sum = 0;
            foreach (float grade in grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade); // Slick way to avoid writing an if
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }
            stats.AverageGrade = sum / grades.Count;
            return stats;

        }

        public override void WriteGrades(TextWriter destination) // TextWriter type doesn't care where it's sending the text.
        {
            /*
            for (int i = 0; i < grades.Count; i++)
            {
                destination.WriteLine(grades[i]);   
            }
            */

            foreach (float grade in grades)
            {
                destination.WriteLine(grade);
            }
        }

        public override void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        // rewriting this as a property
        // in this state, it doesnt' make a huge difference, but in some parts of the .NET fw, a property is needed.
        // e.g. serialization will only look at properties, not fields. Data binding features will move properties directly onto
        // the screen, won't work with fields
        /*
        public string Name 
        {
            get; set;
        }
        */

        // here we have some data validation. the auto implement sytax (get; set;) is all or nothing, so both have to have code internal
        // protected level gives access to this class and in a derived class
        protected List<float> grades; //  = new List<float>(); // must initialize a new instance of List, insure it points to an obj.
    }
}
