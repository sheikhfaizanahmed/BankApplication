using System;
using System.Collections.Generic;
using System.Text;

namespace BankApplication
{
    public class IndividualInvestmentAccount : InvestmentAccount
    {

        public override void Withdraw(float amount)
        {
            if (amount <= 500)
            {
                this.Balance -= amount;
            }
            else
            {
                throw new Exception("Cannot withdraw more than 500 dollars!");
            }
        }
    }
}
