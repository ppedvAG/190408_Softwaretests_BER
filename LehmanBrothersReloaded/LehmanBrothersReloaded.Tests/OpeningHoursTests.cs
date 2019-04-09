using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LehmanBrothersReloaded.Tests
{
    [TestFixture]
    public class OpeningHoursTests
    {
        [Test]
        [TestCase(2019, 4, 8, 10, 29, 00, false)]// Mo
        [TestCase(2019, 4, 8, 10, 30, 00, true)] // Mo
        [TestCase(2019, 4, 8, 12, 30, 00, true)] // Mo
        [TestCase(2019, 4, 8, 19, 00, 00, true)] // Mo
        [TestCase(2019, 4, 8, 19, 01, 00, false)] // Mo
        [TestCase(2019, 4, 8, 22, 00, 00, false)] // Mo
        [TestCase(2019, 4,9, 10, 29, 00, false)]// Di
        [TestCase(2019, 4,9, 10, 30, 00, true)] // Di
        [TestCase(2019, 4,9, 12, 30, 00, true)] // Di
        [TestCase(2019, 4,9, 19, 00, 00, true)] // Di
        [TestCase(2019, 4,9, 19, 01, 00, false)] //Di
        [TestCase(2019, 4,9, 22, 00, 00, false)] //Di
        [TestCase(2019, 4, 10, 10, 29, 00, false)]// Mi
        [TestCase(2019, 4, 10, 10, 30, 00, true)] // Mi
        [TestCase(2019, 4, 10, 12, 30, 00, true)] // Mi
        [TestCase(2019, 4, 10, 19, 00, 00, true)] // Mi
        [TestCase(2019, 4, 10, 19, 01, 00, false)] //Mi
        [TestCase(2019, 4, 10, 22, 00, 00, false)] //Mi
        [TestCase(2019, 4, 11, 10, 29, 00, false)]// Do
        [TestCase(2019, 4, 11, 10, 30, 00, true)] // Do
        [TestCase(2019, 4, 11, 12, 30, 00, true)] // Do
        [TestCase(2019, 4, 11, 19, 00, 00, true)] // Do
        [TestCase(2019, 4, 11, 19, 01, 00, false)] //Do
        [TestCase(2019, 4, 11, 22, 00, 00, false)] //Do
        [TestCase(2019, 4, 12, 10, 29, 00, false)]// Fr
        [TestCase(2019, 4, 12, 10, 30, 00, true)] // Fr
        [TestCase(2019, 4, 12, 12, 30, 00, true)] // Fr
        [TestCase(2019, 4, 12, 19, 00, 00, true)] // Fr
        [TestCase(2019, 4, 12, 19, 01, 00, false)] //Fr
        [TestCase(2019, 4, 12, 22, 00, 00, false)] //Fr
        [TestCase(2019, 4, 13, 10, 29, 00, false)]// Sa
        [TestCase(2019, 4, 13, 10, 30, 00, true)] // Sa
        [TestCase(2019, 4, 13, 12, 30, 00, true)] // Sa
        [TestCase(2019, 4, 13, 14, 00, 00, true)] // Sa
        [TestCase(2019, 4, 13, 14, 01, 00, false)] //Sa
        [TestCase(2019, 4, 13, 22, 00, 00, false)] //Sa
        [TestCase(2019, 4, 14, 10, 29, 00, false)]// So
        [TestCase(2019, 4, 14, 10, 30, 00, false)] //So
        [TestCase(2019, 4, 14, 12, 30, 00, false)] //So
        [TestCase(2019, 4, 14, 14, 00, 00, false)] //So
        [TestCase(2019, 4, 14, 14, 01, 00, false)] //So
        [TestCase(2019, 4, 14, 22, 00, 00, false)] //So
        public void OpeningHours_IsOpen(int year, int month, int day, int hour, int minute, int second, bool expectedResult)
        {
            var oh = new OpeningHours();
            var dt = new DateTime(year, month, day, hour, minute, second);

            Assert.AreEqual(expectedResult, oh.IsOpen(dt));
        }


        [Test]
        public void OpeningHours_IsNowOpen()
        {
            var oh = new OpeningHours();

            var result = oh.IsNowOpen();

            // Interpretationsproblem: zwischen 14:00 und 17:00 ists True, ansonsten False
            // Abhängigkeit auf DateTime.Now auflösen
            // 1) Fakes-Framework (VS Enterprise)
            // 2) Pose (Kostenlos)
            // 3) TypeMock (kostenpflichtig)v
        }
    }
}
