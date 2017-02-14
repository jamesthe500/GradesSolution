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
