using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void ComputeHighestGrade()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(10);
            book.AddGrade(90);
            GradeStatistics result = book.ComputeStatistics();
            Assert.AreEqual(result.HighestGrade, 90);
        }
        [TestMethod]
        public void ComputeLowestGrade()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(10);
            book.AddGrade(90);
            GradeStatistics result = book.ComputeStatistics();
            Assert.AreEqual(result.LowestGrade, 10);
        }
        [TestMethod]
        public void ComputeAverageGrade()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(10);
            book.AddGrade(90);
            GradeStatistics result = book.ComputeStatistics();
            Assert.AreEqual(result.AverageGrade, 50);
        }
        [TestMethod]
        public void ComputeAverage2Grade()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(91.1f);
            book.AddGrade(89.5f);
            book.AddGrade(89.5f);
            GradeStatistics result = book.ComputeStatistics();
            Assert.AreEqual(result.AverageGrade,90.03,0.01 );
        }
    }
}
