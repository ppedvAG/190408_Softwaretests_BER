using System;
using System.Collections.Generic;
using System.Text;

namespace MeineLib
{
    public class Person
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public byte Alter { get; set; }
        public decimal Kontostand { get; set; }

        public override bool Equals(object obj)
        {
            // Bedingungen:
            /*
             * X - Wenn die Datentypen unterschiedlich sind -> return false 
             * X - Wenn der Parameter "null" ist -> ArgumentNullException
             * X - Wenn die Referenzen gleich sind -> return true
             * x - --> Wenn die Werte gleich sind -> return true
             */
            if (obj is null) // Seit C# 7 ebenfalls möglich
                throw new ArgumentNullException();
            if (!(obj is Person))
                return false;

            if (this == obj) // Referenzgleich
                return true;

            // Wertevergleich
            var person2 = (Person)obj;
            if (this.Vorname == person2.Vorname &&
                this.Nachname == person2.Nachname &&
                this.Alter == person2.Alter &&
                this.Kontostand == person2.Kontostand)
                return true;
            else
                return false;
        }
    }
}
