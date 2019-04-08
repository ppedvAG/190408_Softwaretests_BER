using System;

namespace LehmanBrothersReloaded
{
    public enum Wealth { Zero,Poor,Ok,Rich,FilthyRich}
    public class Bankaccount
    {
        public Bankaccount()
        {
        }

        public Bankaccount(decimal defaultBalance)
        {
            if (defaultBalance < 0)
                throw new ArgumentException();
            this.Balance = defaultBalance;
        }

        public decimal Balance { get; set; }

        public Wealth Wealth
        {
            get
            {
                switch (Balance) // Pattern Matching C# 7
                {
                    case 0:
                        return Wealth.Zero;
                    case decimal b when b < 100:
                        return Wealth.Poor;
                    case decimal b when b < 1000:
                        return Wealth.Ok;
                    case decimal b when b < 10000:
                        return Wealth.Rich;
                    case decimal b when b < 1000000:
                        return Wealth.FilthyRich;
                    default:
                        return Wealth.Poor;
                    // Es wurden absichtlich nicht alle Varianten eingebaut !!!
                }
            }
        }


        public void Deposit(decimal v)
        {
            if (v < 0)
                throw new ArgumentException();
            Balance += v;
        }

        public void Withdraw(decimal v)
        {
            if (v < 0)
                throw new ArgumentException();
            if (Balance - v < 0)
                throw new InvalidOperationException();
            Balance -= v;
        }
    }
}
