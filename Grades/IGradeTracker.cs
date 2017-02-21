using System.IO;

namespace Grades
{
    internal interface IGradeTracker
    {
        void AddGrade(float grade); // doesn't specify its implimentation b/c we dont' know what it will be exactly, we just know grades will need to be added.
        GradeStatistics ComputeStatistics();
        void WriteGrades(TextWriter destination);
        string Name { get; set; }
    }
}