using System;

namespace LehmanBrothersReloaded
{
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
