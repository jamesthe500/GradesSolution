using System.Collections;
using System.IO;

namespace Grades
{
    internal interface IGradeTracker : IEnumerable // want to have a foreach for an IGrade, so add this Interface from System.Collections
    {
        void AddGrade(float grade); // doesn't specify its implimentation b/c we dont' know what it will be exactly, we just know grades will need to be added.
        GradeStatistics ComputeStatistics();
        void WriteGrades(TextWriter destination);
        string Name { get; set; }
    }
}