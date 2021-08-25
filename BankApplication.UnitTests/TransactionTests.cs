using System;
using Xunit;

namespace BankApplication.UnitTests
{
    public class TransactionTests
    {
        [Fact]
        public void Deposit_CheckingAccount_ReturnTrue()
        {
            CheckingAccount checkingAccount = new CheckingAccount();

            Transaction transaction = new Transaction();

            var result = transaction.Deposit(500, checkingAccount);

            Assert.True(result);
        }

        [Fact]
        public void Deposit_IndividualAccount_ReturnTrue()
        {
            IndividualInvestmentAccount account = new IndividualInvestmentAccount();

            Transaction transaction = new Transaction();

            var result = transaction.Deposit(500, account);

            Assert.True(result);
        }

        [Fact]
        public void Deposit_CorporateAccount_ReturnTrue()
        {
            CorporateInvestmentAccount account = new CorporateInvestmentAccount();

            Transaction transaction = new Transaction();

            var result = transaction.Deposit(500, account);

            Assert.True(result);
        }

        [Fact]
        public void Withdraw_CheckingAccount_ReturnTrue()
        {
            CheckingAccount checkingAccount = new CheckingAccount();

            Transaction transaction = new Transaction();

            var result = transaction.Withdraw(500, checkingAccount);

            Assert.True(result);
        }

        [Fact]
        public void Withdraw_IndividualAccount_ReturnTrue()
        {
            IndividualInvestmentAccount account = new IndividualInvestmentAccount();

            Transaction transaction = new Transaction();

            var result = transaction.Withdraw(500, account);

            Assert.True(result);
        }

        [Fact]
        public void Withdraw_MoreThan500FromIndividualAccount_ReturnFalse()
        {
            IndividualInvestmentAccount account = new IndividualInvestmentAccount();

            Transaction transaction = new Transaction();

            var result = transaction.Withdraw(501, account);

            Assert.False(result);
        }

        [Fact]
        public void Withdraw_CorporateAccount_ReturnTrue()
        {
            CorporateInvestmentAccount account = new CorporateInvestmentAccount();

            Transaction transaction = new Transaction();

            var result = transaction.Withdraw(500, account);

            Assert.True(result);
        }

        [Fact]
        public void Transfer_CorporateAccountToIndividualAccount_ReturnTrue()
        {
            IndividualInvestmentAccount individualAccount = new IndividualInvestmentAccount();
            CorporateInvestmentAccount corporateAccount = new CorporateInvestmentAccount();

            Transaction transaction = new Transaction();


            //Both accounts should have 0 balance
            Assert.Equal(0, corporateAccount.GetBalance());
            Assert.Equal(0, individualAccount.GetBalance());

            // first deposit 20 into both accounts
            transaction.Deposit(20, corporateAccount);
            transaction.Deposit(20, individualAccount);

            //transfer 10 from corporate to individual account
            var transferResult = transaction.Transfer(10, corporateAccount, individualAccount);
            Assert.True(transferResult);


            //Corporate balance should be 10
            Assert.Equal(10, corporateAccount.GetBalance());

            //Individual balance should be 30
            Assert.Equal(30, individualAccount.GetBalance());
        }

        [Fact]
        public void Transfer_CorporateAccountToCheckingAccount_ReturnTrue()
        {
            CheckingAccount checkingAccount = new CheckingAccount();
            CorporateInvestmentAccount corporateAccount = new CorporateInvestmentAccount();

            Transaction transaction = new Transaction();


            //Both accounts should have 0 balance
            Assert.Equal(0, corporateAccount.GetBalance());
            Assert.Equal(0, checkingAccount.GetBalance());

            // first deposit 20 into both accounts
            transaction.Deposit(20, corporateAccount);
            transaction.Deposit(20, checkingAccount);

            //transfer 10 from corporate to checking account
            var transferResult = transaction.Transfer(10, corporateAccount, checkingAccount);
            Assert.True(transferResult);


            //Corporate balance should be 10
            Assert.Equal(10, corporateAccount.GetBalance());

            //Individual balance should be 30
            Assert.Equal(30, checkingAccount.GetBalance());
        }

        [Fact]
        public void Transfer_CheckingAccountToIndividualAccount_ReturnTrue()
        {
            IndividualInvestmentAccount individualAccount = new IndividualInvestmentAccount();
            CheckingAccount checkingAccount = new CheckingAccount();

            Transaction transaction = new Transaction();


            //Both accounts should have 0 balance
            Assert.Equal(0, checkingAccount.GetBalance());
            Assert.Equal(0, individualAccount.GetBalance());

            // first deposit 20 into both accounts
            transaction.Deposit(20, checkingAccount);
            transaction.Deposit(20, individualAccount);

            //transfer 10 from checking to individual account
            var transferResult = transaction.Transfer(10, checkingAccount, individualAccount);
            Assert.True(transferResult);


            //checking balance should be 10
            Assert.Equal(10, checkingAccount.GetBalance());

            //Individual balance should be 30
            Assert.Equal(30, individualAccount.GetBalance());
        }

        [Fact]
        public void Transfer_CheckingAccountToCorporateAccount_ReturnTrue()
        {
            CorporateInvestmentAccount corporateAccount = new CorporateInvestmentAccount();
            CheckingAccount checkingAccount = new CheckingAccount();

            Transaction transaction = new Transaction();


            //Both accounts should have 0 balance
            Assert.Equal(0, checkingAccount.GetBalance());
            Assert.Equal(0, corporateAccount.GetBalance());

            // first deposit 20 into both accounts
            transaction.Deposit(20, checkingAccount);
            transaction.Deposit(20, corporateAccount);

            //transfer 10 from checking to corporate account
            var transferResult = transaction.Transfer(10, checkingAccount, corporateAccount);
            Assert.True(transferResult);


            //checking balance should be 10
            Assert.Equal(10, checkingAccount.GetBalance());

            //Corporate balance should be 30
            Assert.Equal(30, corporateAccount.GetBalance());
        }


    }
}
