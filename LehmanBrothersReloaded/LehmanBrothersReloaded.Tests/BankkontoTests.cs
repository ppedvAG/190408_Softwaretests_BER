using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LehmanBrothersReloaded.Tests
{
    [TestFixture]
    public class BankAccountTests
    {
        [Test]
        public void Bankaccount_new_account_has_0_balance()
        {
            var ba = new Bankaccount();
            Assert.Zero(ba.Balance);
        }
        [Test]
        [TestCase(100)]
        [TestCase(1000)]
        [TestCase(10000)]
        public void Bankaccount_new_account_gets_Balance_from_Constructor(decimal defaultBalance)
        {
            var ba = new Bankaccount(defaultBalance);

            Assert.AreEqual(defaultBalance, ba.Balance);
        }
        [Test]
        [TestCase(-100)]
        [TestCase(-1000)]
        [TestCase(-10000)]
        public void Bankaccount_new_account_gets_invalid_Balance_in_constructor_throws_ArgumentException(decimal invalidBalance)
        {
           Assert.Throws<ArgumentException>( () => new Bankaccount(invalidBalance));
        }

        [Test]
        public void Bankaccount_can_deposit()
        {
            var ba = new Bankaccount();

            ba.Deposit(5m);
            Assert.AreEqual(5m, ba.Balance);

            ba.Deposit(3m);
            Assert.AreEqual(8m, ba.Balance); // Test für Draufaddieren
        }

        // "ähhhhh was wenn der Kunde aber 0 einzahlt ?"
        // "ähhhhh was wenn der Kunde aber -20m einzahlt ?"
        // Wir sind jetzt genau noch in der Planungsphase und können die UnitTests dementsprechend anpassen

        [Test]
        public void Bankaccount_Deposit_0_does_not_change_Balance()
        {
            var ba = new Bankaccount();
            ba.Deposit(5m); // Startwert

            var oldValue = ba.Balance;
            ba.Deposit(0m);

            Assert.AreEqual(oldValue, ba.Balance);
        }

        [Test]
        public void Bankaccount_Deposit_negative_value_throws_ArgumentException()
        {
            var ba = new Bankaccount();
            Assert.Throws<ArgumentException>(() =>  ba.Deposit(-20m));
        }

        [Test]
        public void Bankaccount_can_Withdraw()
        {
            var ba = new Bankaccount(10m);

            ba.Withdraw(3m);
            Assert.AreEqual(7m, ba.Balance);

            ba.Withdraw(5m);
            Assert.AreEqual(2m, ba.Balance);
        }

        [Test]
        public void Bankaccount_Withdraws_more_than_balance_throws_InvalidOperationException()
        {
            var ba = new Bankaccount();
            Assert.Throws<InvalidOperationException>(() => ba.Withdraw(3m));
        }

        [Test]
        public void Bankaccount_Withdraw_negative_value_throws_ArgumentException()
        {
            var ba = new Bankaccount();
            Assert.Throws<ArgumentException>(() => ba.Withdraw(-20m));
        }

        // Zustand, den man eigentlich schon "Einchecken" kann => "Fahrplan" für die weitere Implementierung steht schon
    }
}
