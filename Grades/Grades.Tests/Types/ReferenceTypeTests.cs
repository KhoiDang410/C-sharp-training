using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Tests.Types
{
    [TestClass]
    public class ReferenceTypeTests
    {
        [TestMethod]
        public void UsingArray()
        {
            float[] grades;
            grades = new float[3];
            AddGrades(grades);
            Assert.AreEqual(89.5f, grades[1]);
        }

        private void AddGrades(float[] grades)
        {
            grades[1] = 89.5f;
        }

        [TestMethod]
        public void ReferenceTypePassByValue()
        {
            GradeBook book1 = new GradeBook();
            GradeBook book2 = book1;
            GiveBookAName(ref book2);
            Assert.AreEqual("A GradeBook", book2.Name);
        }
        private void GiveBookAName(ref GradeBook book)
        {
            book = new GradeBook();
            book.Name = "A GradeBook";
        }
        [TestMethod]
        public void ValueTypePassByValue()
        {
            int x = 46;
            IncrementNumber(ref x);
            Assert.AreEqual(47, x);
        }
        private void IncrementNumber(ref int number)
        {
            number++;
        }

        [TestMethod]
        public void StringComparison()
        {
            string name1 = "Scott";
            string name2 = "scott";
            bool result = String.Equals(name1, name2, System.StringComparison.InvariantCultureIgnoreCase);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IntVariablesHoldValue()
        {
            int x1 = 100;
            Int32 x2 = x1;
            x1 = 4;
            Assert.AreNotEqual(x1, x2);
        }
        [TestMethod]
        public void VariablesHoldTheReference()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            g1.Name = "Scott";
            Assert.AreEqual(g1.Name, g2.Name);
        }
    }
}
