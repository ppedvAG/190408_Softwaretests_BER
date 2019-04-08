using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MeineLib.Tests.MSTest
{
    [TestClass]
    public class CalculatorTests
    {
        // Klassenname_Methodenname_Szenario_erwartetesErgebnis
        [TestMethod]
        public void Calculator_Sum_3_AND_5_Results_8()
        {
            // Arrange
            Calculator c = new Calculator();
            // Act
            int result = c.Sum(3, 5);
            // Assert
            Assert.AreEqual(8, result);
        }
    }
}
