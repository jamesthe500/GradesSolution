using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public abstract class GradeTracker // abstract classes define some general behavior.?
        // can't instantiate an abstract class directly. you can work with it, just no "new GradeTracker"...
    {
        public abstract void AddGrade(float grade); // doesn't specify its implimentation b/c we dont' know what it will be exactly, we just know grades will need to be added.
        public abstract GradeStatistics ComputeStatistics();
        public abstract void WriteGrades(TextWriter destination);

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
