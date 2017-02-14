using Microsoft.VisualStudio.TestTools.UnitTesting;
using Grades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Tests
{
    [TestClass]
    public class GradeBookTests
    {
        [TestMethod]
        public void ComutesHighestGrade()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(10);
            book.AddGrade(90);
            GradeStatistics result = book.ComputeStatistics();

            Assert.AreEqual(90, result.HighestGrade);
        }

        [TestMethod]
        public void ComutesLowestGrade()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(10);
            book.AddGrade(90);
            GradeStatistics result = book.ComputeStatistics();

            Assert.AreEqual(10, result.LowestGrade);
        }

        [TestMethod]
        public void ComutesAvgGrade()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(10);
            book.AddGrade(90);
            book.AddGrade(50);
            GradeStatistics result = book.ComputeStatistics();

            Assert.AreEqual(50, result.AverageGrade);
        }
    }
}
