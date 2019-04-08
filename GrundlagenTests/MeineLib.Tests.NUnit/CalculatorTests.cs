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

    }
}
