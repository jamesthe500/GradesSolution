using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class ThrowAwayGradeBook : GradeBook // This class inherits all the fnality of GradeBook
    {
        public override GradeStatistics ComputeStatistics() // override kw needed for polymorphism
            // the other ComputeStatistics can still be used by invoking the base kw
            // if ComputeStatistics is invoced, we have teh ability to change the behavior of what will happen
        {
            Console.WriteLine("Throw away gb::Compute statistics");
            float lowest = float.MaxValue;
            foreach (float grade in grades)
            {
                lowest = Math.Min(grade, lowest);
            }
        
            grades.Remove(lowest); // convenient method for a list.
            // considerations for the realworld: what if someone runs this more than once, there's only one grade in the book, or no grades
            // What if there are multiple grades that are the same lowest value.
            return base.ComputeStatistics(); // kw base reach methods in a method youve inheritied
        }
    }
}
