using System;

namespace LehmanBrothersReloaded
{
    public class Bankaccount
    {
        private decimal defaultBalance;

        public Bankaccount()
        {
        }

        public Bankaccount(decimal defaultBalance)
        {
            this.defaultBalance = defaultBalance;
        }

        public decimal Balance { get; set; }

        public void Deposit(decimal v)
        {
            throw new NotImplementedException();
        }

        public void Withdraw(decimal v)
        {
            throw new NotImplementedException();
        }
    }
}
