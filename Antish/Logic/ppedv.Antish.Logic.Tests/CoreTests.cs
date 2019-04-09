using Moq;
using NUnit.Framework;
using ppedv.Antish.Domain;
using ppedv.Antish.Domain.Interfaces;
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
            var fakeHardware = new Mock<IDevice>(); // Erstellt ein Fake von der Schnittstelle
            fakeHardware.Setup(x => x.RecruitPerson())
                        .Returns(() => new Person { FirstName = "Tom", LastName = "Ate", Age = 10, Balance = 100m });

            var core = new Core(fakeHardware.Object); // <---- Hier brauchen wir normalerweise Hardware

            var result = core.RecruitPersons(5);

            Assert.AreEqual(5, result.Count());

            // Stelle sicher, dass die Methode 5 Mal wirklich(!!!) aufgerufen wurde
            fakeHardware.Verify(x => x.RecruitPerson(), Times.Exactly(5));
        }

        [Test]
        public void Core_RecruitPerson_with_invalid_amount_throws_ArgumentException()
        {
            // Microsoft Fakes -> "Moles" anstelle von Mock
            var fakeHardware = new Mock<IDevice>();
            var core = new Core(fakeHardware.Object);

            Assert.Throws<ArgumentException>(() => core.RecruitPersons(-20));
            fakeHardware.Verify(x => x.RecruitPerson(), Times.Never());
        }

        [Test]
        public void Core_GetAllPeopleFromDB_Get_Exactly_5_People()
        {
            var dataBaseMock = new Mock<IRepository>();
            dataBaseMock.Setup(x => x.GetAll<Person>())
                        .Returns(() =>
                        {
                            return new Person[]
                            {
                                new Person{FirstName="Tom",LastName="Ate",Age=10,Balance=100},
                                new Person{FirstName="Anna",LastName="Nass",Age=20,Balance=2000},
                                new Person{FirstName="Peter",LastName="Silie",Age=30,Balance=-300},
                                new Person{FirstName="Franz",LastName="Ose",Age=40,Balance=500},
                                new Person{FirstName="Martha",LastName="Pfahl",Age=50,Balance=1234}
                            };
                        });

            var core = new Core(dataBaseMock.Object);
            var result = core.GetAllPeopleFromDB();

            Assert.AreEqual(5, result.Count);
        }

        [Test]
        public void Core_GetPersonWithHighestBalance_Returns_AnnaNass()
        {
            var dataBaseMock = new Mock<IRepository>();
            dataBaseMock.Setup(x => x.GetAll<Person>())
                        .Returns(() =>
                        {
                            return new Person[]
                            {
                                new Person{FirstName="Tom",LastName="Ate",Age=10,Balance=100},
                                new Person{FirstName="Anna",LastName="Nass",Age=20,Balance=2000},
                                new Person{FirstName="Peter",LastName="Silie",Age=30,Balance=-300},
                                new Person{FirstName="Franz",LastName="Ose",Age=40,Balance=500},
                                new Person{FirstName="Martha",LastName="Pfahl",Age=50,Balance=1234}
                            };
                        });

            var core = new Core(dataBaseMock.Object);
            var result = core.GetPersonWithHighestBalance();

            Assert.AreEqual("Anna", result.FirstName); // Anna Nass
        }
    }
}
