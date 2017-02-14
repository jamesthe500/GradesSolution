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
        public void ValuesTypesPassByMethod()
        {
            int s = 46;
            IncremenetNumber(ref s);

            Assert.AreEqual(s, 47);
        }

        private void IncremenetNumber(ref int number) // can pass by ref with values as well. 
            // Think of number as a refference to the s varialbe location. Any changes made to s in this function will
            // affect the value of s.
        {
            number++;
        }

        [TestMethod]
        public void ReferenceTypesPassByValue()
        {
            GradeBook book1 = new GradeBook();
            GradeBook book2 = book1;

            GiveBookAName(ref book2); // passing by reference. ref is kw, also in method parameter, must be in both places.
            Assert.AreEqual("A GradeBook", book2.Name);

        }

        private void GiveBookAName(ref GradeBook book) // As i understand, you're passing in a reference, rather than the 
            // pointer which would affect the object itself. 
        {
            book = new GradeBook();
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
