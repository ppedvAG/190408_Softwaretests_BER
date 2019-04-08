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
             * Wenn die Datentypen unterschiedlich sind -> return false
             * Wenn der Parameter "null" ist -> ArgumentNullException
             * Wenn die Referenzen gleich sind -> return true
             *   --> Wenn die Werte gleich sind -> return true
             */ 
        }
    }
}
