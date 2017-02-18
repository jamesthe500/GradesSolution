using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook
    {
        public GradeBook() // constructor, custom. Default (doesn't take parameters)
        {
            _name = "default grade book";
            grades = new List<float>(); // This is brought from below. new instance of List FIELD with every instance of GradeBook.
        }

        public GradeStatistics ComputeStatistics()
        {
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

        public void WriteGrades(TextWriter destination) // TextWriter type doesn't care where it's sending the text.
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

        public void AddGrade(float grade)
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
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be blank.");
                }

                if (_name != value) // A delegate to let the program know when the name is changed. Databinding e.g.
                {
                    //Name Changed(_name, value) // pseudo-code to guide what delegate to make
                    NameChangedEventArgs args = new NameChangedEventArgs();
                    args.ExistingName = _name;
                    args.NewName = value;

                    NameChanged(this, args);
                }
                _name = value;

            }
        }

        public event NameChangedDelegate NameChanged; // just add the event kw and this becomes one.

        // an explicitly created field to hold the string value is needed.
        private string _name;

        private List<float> grades; //  = new List<float>(); // must initialize a new instance of List, insure it points to an obj.
    }
}
