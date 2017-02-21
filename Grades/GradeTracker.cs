using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public abstract class GradeTracker : IGradeTracker // One way to implement an interface is to do so through the abstract method
        // This gradeTrackers is now an IGradeTracker & its members can be abstract
    {
        public abstract void AddGrade(float grade); // doesn't specify its implimentation b/c we dont' know what it will be exactly, we just know grades will need to be added.
        public abstract GradeStatistics ComputeStatistics();
        public abstract void WriteGrades(TextWriter destination);
        public abstract IEnumerator GetEnumerator();

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

                if (_name != value && NameChanged != null) // A delegate to let the program know when the name is changed. Databinding e.g.
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

        public event NameChangedDelegate NameChanged; 

        
        protected string _name;


    }
}
