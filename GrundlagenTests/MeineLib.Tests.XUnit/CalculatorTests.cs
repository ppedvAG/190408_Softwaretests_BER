using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MeineLib.Tests.XUnit
{
    public class CalculatorTests
    {
        // Normalfall
        [Fact]
        [Trait("XUnit",null)]
        public void Calculator_Sum_3_AND_5_Results_8()
        {
            // Arrange
            Calculator c = new Calculator();
            // Act
            int result = c.Sum(3, 5);
            // Assert
            Assert.Equal(8, result);
        }

        // Normalfall mit DataRow
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(-10, 20, 10)]
        [InlineData(5, 6, 11)]
        [Trait("XUnit",null)]
        public void Calculator_Sum(int z1, int z2, int expectedResult)
        {
            // Arrange
            Calculator c = new Calculator();
            // Act
            int result = c.Sum(z1, z2);
            // Assert
            Assert.Equal(expectedResult, result);
        }

    }
}
