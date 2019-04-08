using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeineLib.Tests.NUnit
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        [Category("NUnit")]
        public void Calculator_Sum_3_AND_5_Results_8()
        {
            Calculator calc = new Calculator();
            int result = calc.Sum(3, 5);
            Assert.AreEqual(8, result);
        }

        // Normalfall mit TestCase
        [Test]
        [TestCase(1, 2, 3)]
        [TestCase(-10, 20, 10)]
        [TestCase(5, 6, 11)]
        [Category("NUnit")]
        public void Calculator_Sum(int z1, int z2, int expectedResult)
        {
            // Arrange
            Calculator c = new Calculator();
            // Act
            int result = c.Sum(z1, z2);
            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("asd",false)]
        [TestCase(-12,false)]
        [TestCase(false,true)]
        public void Calculator_Is_not_typeOf_Parameter(object parameter,bool expectedResult)
        {
            Calculator c = new Calculator();

            Assert.Equals(expectedResult,c.Equals(parameter));
        }

    }
}
