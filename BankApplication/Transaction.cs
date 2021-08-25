using System;
using System.Collections.Generic;
using System.Text;

namespace BankApplication
{
    public class Transaction
    {
        public bool Deposit(float Amount, Account account)
        {
            try
            {
                account.Deposit(Amount);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Withdraw(float Amount, Account account)
        {
            try
            {
                account.Withdraw(Amount);
                return true;
            }

            catch
            {
                return false;
            }
            
        }

        public bool Transfer(float Amount, Account sendingAccount, Account receivingAccount)
        {
            try
            {
                sendingAccount.Withdraw(Amount);
                receivingAccount.Deposit(Amount);

                return true;
            }

            catch
            {
                return false;
            }
            
        }
    }
}
