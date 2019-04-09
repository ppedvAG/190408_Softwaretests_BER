using ppedv.Antish.Domain;
using ppedv.Antish.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ppedv.Antish.Logic
{
    public class Core // Geschäftslogik
    {
        public Core(IDevice device)
        {
            this.device = device;
        }
        public Core(IRepository repository)
        {
            this.repository = repository;
        }

        private readonly IRepository repository;
        private readonly IDevice device;

        /* Irgendeine Logik, die meine Hardware intern verwendet
         * Problem: Man muss den Core testen, ohne dass das echte Gerät (Device) angesteuert wird
         * => Testgeräte verwenden
         * Neues Problem: Es steht nicht überall ein Testgerät/Roboterarm etc zur Verfügung
         * => Mocks
         */
        public List<Person> RecruitPersons(int amount)
        {
            if (amount < 0) // Trick mit Verify: Diese 2 Zeilen könnten auch viel später kommen und .RecruitPerson() könnte auch vor dem werfen der Exception einmal passieren...
                throw new ArgumentException();

            List<Person> output = new List<Person>();
            for (int i = 0; i < amount; i++)
            {
                output.Add(device.RecruitPerson()); // Echtgerät aufrufen
            }
            return output;
        }


        // Logik in der die DB verwendet wird:
        public List<Person> GetAllPeopleFromDB()
        {
            return repository.GetAll<Person>().ToList();
        }

        public Person GetPersonWithHighestBalance()
        {
            return repository.GetAll<Person>()
                             .OrderByDescending(x => x.Balance)
                             .First();
        }



    }
}
