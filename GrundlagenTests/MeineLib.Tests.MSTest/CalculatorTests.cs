using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MeineLib.Tests.MSTest
{
    [TestClass]
    public class CalculatorTests
    {
        // Klassenname_Methodenname_Szenario_erwartetesErgebnis

        // Normalfall
        [TestMethod]
        [TestCategory("MSTest")]
        public void Calculator_Sum_3_AND_5_Results_8()
        {
            // Arrange
            Calculator c = new Calculator();
            // Act
            int result = c.Sum(3, 5);
            // Assert
            Assert.AreEqual(8, result);
        }

        // Null-Fall
        [TestMethod]
        [TestCategory("MSTest")]
        public void Calculator_Sum_0_AND_0_Results_0()
        {
            // Arrange
            Calculator c = new Calculator();
            // Act
            int result = c.Sum(0, 0);
            // Assert
            Assert.AreEqual(0, result);
        }

        // Grenzfall
        [TestMethod]
        [TestCategory("MSTest")]
        public void Calculator_Sum_IntMAX_AND_1_throws_OverflowException()
        {
            Calculator c = new Calculator();

            Assert.ThrowsException<OverflowException>(() => c.Sum(Int32.MaxValue, 1));
        }
        // Grenzfall
        [TestMethod]
        [TestCategory("MSTest")]
        public void Calculator_Sum_IntMIN_AND_NEG1_throws_OverflowException()
        {
            Calculator c = new Calculator();
            
            Assert.ThrowsException<OverflowException>(() => c.Sum(Int32.MinValue, -1));
        }
    }
}
