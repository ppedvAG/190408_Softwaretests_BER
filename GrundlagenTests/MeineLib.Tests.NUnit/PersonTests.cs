using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeineLib.Tests.NUnit
{
    [TestFixture]
    [Category("Personentests")]
    class PersonTests
    {
        [Test]
        public void Person_Equals_with_Parameter_Null_Throws_ArgumentNullException()
        {
            Person p1 = new Person { Vorname = "Tom", Nachname = "Ate", Alter = 10, Kontostand = 100 };
            Assert.Throws<ArgumentNullException>(() => p1.Equals(null));
        }

        [Test]
        [Category("Personentests")]
        public void Person_Equals_with_wrong_Type_returns_false()
        {
            Person p1 = new Person { Vorname = "Tom", Nachname = "Ate", Alter = 10, Kontostand = 100 };
            StringBuilder sb = new StringBuilder(); // <--- Kann leider nicht mit TestCase genutzt werden
            object o1 = new object(); // <--- Kann leider nicht mit TestCase genutzt werden
            int zahl1 = 12;
            string text1 = "asdasd";

            Assert.IsFalse(p1.Equals(sb));
            Assert.IsFalse(p1.Equals(o1));
            Assert.IsFalse(p1.Equals(zahl1));
            Assert.IsFalse(p1.Equals(text1));
        }

        [Test]
        [Category("Personentests")]
        public void Person_Equals_with_same_reference_returns_true()
        {
            Person p1 = new Person { Vorname = "Tom", Nachname = "Ate", Alter = 10, Kontostand = 100 };
            Person p2 = p1; // Referenzkopie

            Assert.IsTrue(p1.Equals(p2));
        }

        [Test]
        [Category("Personentests")]
        public void Person_Equals_with_person_that_has_same_values_returns_true()
        {
            Person p1 = new Person { Vorname = "Tom", Nachname = "Ate", Alter = 10, Kontostand = 100 };
            Person p2 = new Person { Vorname = "Tom", Nachname = "Ate", Alter = 10, Kontostand = 100 };

            Assert.IsTrue(p1.Equals(p2));
        }
    }
}
