using AutoFixture;
using ppedv.Antish.Domain;
using ppedv.Antish.Domain.Interfaces;
using System;

namespace RoboTech.Hardware
{
    public class XingRecruiter3000 : IDevice
    {
        private Fixture fix = new Fixture();

        public Person RecruitPerson()
        {
            Console.Beep(2000,250);
            Console.Beep(500,250);
            return fix.Create<Person>();
        }
    }
}
