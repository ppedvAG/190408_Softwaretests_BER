using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboTech.Hardware.Tests
{
    [TestFixture]
    public class XingRecruiter3000Tests
    {
        [Test]
        public void XingRecruiter3000_can_recruit_person()
        {
            var recruiter = new XingRecruiter3000();

            var person = recruiter.RecruitPerson();

            Assert.NotNull(person);

            // Wenn der Test ausgeführt wird, piepst es !!!
            // Problem: Bei einem UnitTest wollen wir die Maschine ja nicht in echt steuern
            // Ziel: Simulieren, dass die Maschine etwas macht (piept)
        }
    }
}
