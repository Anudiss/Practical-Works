using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_Works.PracticalWorks
{
    class Classes2
    {

        public static void Task1()
        {
            List<BankAccount> accounts = new();

        }

        public static void Task2()
        {

        }

    }

    class BankAccount
    {
        public ulong Id { get; }
        public double Balance { get; private set; }

        private static ulong ID = 4000000000000000000;

        public BankAccount()
        {
            Id = ID++;
        }

        public void TakeOut(double amount)
        {
            if (Balance < amount)
                return;
            Balance -= amount;
        }

        public void PutOn(double amount) => Balance += amount;
    }
}
