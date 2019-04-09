using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.Antish.Logic.Tests
{
    [TestFixture]
    public class CoreTests
    {

        [Test]
        public void Core_RecruitPerson_can_recruit_5_Persons()
        {
            var core = new Core(null); // <---- Hier brauchen wir normalerweise Hardware

            var result = core.RecruitPersons(5);

            Assert.AreEqual(5, result.Count());
        }

    }
}
