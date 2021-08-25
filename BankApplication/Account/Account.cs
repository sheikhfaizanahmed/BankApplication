using System;
using System.Collections.Generic;
using System.Text;

namespace BankApplication
{
    public abstract class Account
    {
        //Containment
        public AccountOwner Owner { get; set; }

        protected float Balance { get; set; }

        public virtual float GetBalance()
        {
            return Balance;
        }

        public virtual void Deposit(float Amount)
        {
            Balance += Amount;
        }

        public virtual void Withdraw(float Amount)
        {
            Balance -= Amount;
        }

        public Account()
        {
            Owner = new AccountOwner();
        }
    }
}
