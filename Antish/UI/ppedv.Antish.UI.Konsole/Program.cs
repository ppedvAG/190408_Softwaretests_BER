using ppedv.Antish.Data.EF;
using ppedv.Antish.Domain;
using ppedv.Antish.Logic;
using RoboTech.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.Antish.UI.Konsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var core = new Core(new EFRepository(new EFContext()),
                                new XingRecruiter3000());

            Console.WriteLine("Wie viele Personen wollen Sie generieren?");
            int anzahl = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Personen werden nun erstellt...");
            var personen = core.RecruitPersons(anzahl);
            Console.WriteLine("Personen wurden erfolgreich erstellt");

            // Personen in die DB einfügen
            core.InsertPeopleIntoDB(personen);
            Console.WriteLine("Personen wurden in die DB eingefügt");

            Console.WriteLine("------ Alle Personen aus der DB ------");

            var allePersonenAusDerDB = core.GetAllPeopleFromDB();
            foreach (Person p in allePersonenAusDerDB)
            {
                Console.WriteLine($"{p.FirstName} {p.LastName}, Age:{p.Age}, Balance:{p.Balance}");
            }

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
