using System;

namespace ChainOfReposibility
{
    // There is some task to do, but not every class/service (or handler, because thats how its called in this case) is able to perform necessary task.
    // You may not know what kind of task comes. You may be lazy and create solution that will simplfy code use for future programmers (haha).

    // Create an abstract class. It needs a "next handler" field, "set next" method, and "handle" method at least.
    // Then you create classes (handlers) that will implement abstract class mentioned above, and implement logic.
    // Handle method is meant to solve task, or give it to next handler, that is set by "set next" method and stored in "next handler" field.
    // When task is handled, chain is broken.

    abstract class Account
    {
        private Account mSuccessor;
        protected decimal mBalance;

        public void SetNext(Account account)
        {
            mSuccessor = account;
        }

        public void Pay(decimal amountTopay)
        {
            if (CanPay(amountTopay))
            {
                Console.WriteLine("Paid {0:c} using {1}.", amountTopay, this.GetType().Name);
            }
            else if (this.mSuccessor != null)
            {
                Console.WriteLine("Cannot pay using {0}. Proceeding..", this.GetType().Name);
                mSuccessor.Pay(amountTopay);
            }
            else
            {
                throw new Exception("None of the accounts have enough balance");
            }
        }
        private bool CanPay(decimal amount)
        {
            return mBalance >= amount ? true : false;
        }
    }

    class Bank : Account
    {
        public Bank(decimal balance)
        {
            this.mBalance = balance;
        }
    }

    class Paypal : Account
    {
        public Paypal(decimal balance)
        {
            this.mBalance = balance;
        }
    }

    class Bitcoin : Account
    {
        public Bitcoin(decimal balance)
        {
            this.mBalance = balance;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Let's prepare a chain like below
            //      $bank->$paypal->$bitcoin
            //
            // First priority bank
            //      If bank can't pay then paypal
            //      If paypal can't pay then bit coin
            var bank = new Bank(100);          // Bank with balance 100
            var paypal = new Paypal(200);      // Paypal with balance 200
            var bitcoin = new Bitcoin(300);    // Bitcoin with balance 300

            bank.SetNext(paypal);
            paypal.SetNext(bitcoin);

            // Let's try to pay using the first priority i.e. bank
            bank.Pay(259);
            // Output will be
            // ==============
            // Cannot pay using bank. Proceeding ..
            // Cannot pay using paypal. Proceeding ..:
            // Paid 259 using Bitcoin!
        }
    }
}
