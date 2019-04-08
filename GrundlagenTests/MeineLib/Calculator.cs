using System;

namespace MeineLib
{
    public class Calculator
    {
        public int Sum(int a, int b)
        {
            checked // Prüft auf Arithmetische Über/Unterläufe
            {
                return a + b;
            }
        }
    }
}
