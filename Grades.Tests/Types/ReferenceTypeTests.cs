using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Tests.Types
{
    [TestClass]
    public class TypeTests
    {
        [TestMethod]
        public void UsingArrays()
        {
            float[] grades; // declare it as an array first.
            grades = new float[3];

            AddGrades(grades);

            Assert.AreEqual(89.1f, grades[1]);
        }

        private void AddGrades(float[] grades)
        {
            //grades = new float[5]; // breaks test as arrays are references and the test is looking at a different grades
            grades[1] = 89.1f; 
        }

        [TestMethod]
        public void UpperCaseTheString()
        {
            string ego = "scott";
            ego = ego.ToUpper(); // like datetimes, strings are references, so to change the value you need to use this syntax.

            Assert.AreEqual("SCOTT", ego);
        }

        [TestMethod]
        public void AddDaysToDateTime()
        {
            DateTime date = new DateTime(2015, 1, 1);
            date = date.AddDays(1);

            Assert.AreEqual(2, date.Day); // now it passes b/c we're assigning it back to itself.
        }



        [TestMethod]
        public void ValuesTypesPassByMethod()
        {
            int s = 46;
            IncremenetNumber(s);

            Assert.AreEqual(s, 46);
        }

        private void IncremenetNumber(int number)
        {
            number++;
        }

        [TestMethod]
        public void ReferenceTypesPassByValue()
        {
            GradeBook book1 = new GradeBook();
            GradeBook book2 = book1;

            GiveBookAName(book2);
            Assert.AreEqual("A GradeBook", book1.Name);

        }

        private void GiveBookAName(GradeBook book)
        {
            //book = new GradeBook();
            book.Name = "A GradeBook";
        }


        [TestMethod]
        public void StringComparrisons()
        {
            string name1 = "Scott";
            string name2 = "scott";

            bool result = String.Equals(name1, name2, StringComparison.InvariantCultureIgnoreCase);
            Assert.IsTrue(result);

        }


        [TestMethod]
        public void IntVariabelsHoldAValue()
        {
            int x1 = 100;
            int x2 = x1;

            x1 = 4;
            Assert.AreNotEqual(x1, x2);
        }

        [TestMethod]
        public void GradeBookVariablesHoldAReference()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            g1.Name = "Jim's book";
            Assert.AreEqual(g1.Name, g2.Name);
        }
    }
}
