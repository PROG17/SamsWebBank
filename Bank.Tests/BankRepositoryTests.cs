using Xunit;
using SamsWebBank.Models;

namespace Bank.Tests
{
   
    public class BankRepositoryTests
    {
        private BankRepository GetBankRepository()
        {
            BankRepository.Reset(); 
            return BankRepository.Instance;
        }

        [Theory]
        [InlineData(1, 100, 9900)]
        [InlineData(5, 10000, 90000)]
        [InlineData(6, 12000, 0)]
        public void Withdraw_WithValidArguments_UpdatesAccountWithCorrectSalary(int accountNumber, decimal amount, decimal expectedSalary)
        {
            var bankRepository = GetBankRepository();

            var resultStatus = bankRepository.Withdraw(accountNumber, amount);

            Assert.Equal("success", resultStatus);
            Assert.Equal(expectedSalary, bankRepository.Accounts[accountNumber].Salary);
        }

        [Theory]
        [InlineData(1, 100, 10100)]
        [InlineData(5, 10000, 110000)]
        [InlineData(6, 12000, 24000)]
        public void Deposit_WithValidArguments_UpdatesAccountWithCorrectSalary(int accountNumber, decimal amount, decimal expectedSalary)
        {
            var bankRepository = GetBankRepository();

            var resultStatus = bankRepository.Deposit(accountNumber, amount);

            Assert.Equal("success", resultStatus);
            Assert.Equal(expectedSalary, bankRepository.Accounts[accountNumber].Salary);
        }


        [Theory]
        [InlineData(7, 100, "Kontonumret finns inte.")]
        [InlineData(5, -1, "Beloppet kan inte vara negativt")]
        [InlineData(6, 12001, "Det finns inte tillräckligt med pengar på kontot.")]
        [InlineData(1, 10001, "Det finns inte tillräckligt med pengar på kontot.")]
        public void Withdraw_WithInvalidArguments_ReturnsErrorMessage(int accountNumber, decimal amount, string expectedErrorMessage)
        {
            var bankRepository = GetBankRepository();

            var resultStatus = bankRepository.Withdraw(accountNumber, amount);

            Assert.Equal(expectedErrorMessage, resultStatus);
        }


        [Theory]
        [InlineData(1,2, 11000, "Det finns inte tillräckligt med pengar på kontot.")]
        [InlineData(2,1, 21000, "Det finns inte tillräckligt med pengar på kontot.")]
        [InlineData(1, 1222, 199, "Mottagarens kontonummer finns inte.")]
        [InlineData(1222, 1, 2000, "Avsändarens kontonummer finns inte.")]
        [InlineData(1, 1, 2000, "Du kan måste ange två unika konton")]
        public void Transfer_WithInvalidArguments_ReturnsErrorMessage(int fromAccount, int toAccount, decimal amount, string expectedErrorMessage)
        {
            var bankRepository = GetBankRepository();

            var resultStatus = bankRepository.Transfer(fromAccount, toAccount, amount);

            Assert.Equal(expectedErrorMessage, resultStatus);
        }

        [Theory]
        [InlineData(1, 2, 100, "success")]
        [InlineData(2, 1, 200, "success")]
        [InlineData(1, 3, 199, "success")]
        [InlineData(4, 6, 2000, "success")]
        public void Transfer_WithValidArguments(int fromAccount, int toAccount, decimal amount, string expectedMessage)
        {
            var bankRepository = GetBankRepository();

            var previousBalanceSender = bankRepository.Accounts[fromAccount].Salary;
            var previousBalanceRetriever = bankRepository.Accounts[toAccount].Salary;

            var resultStatus = bankRepository.Transfer(fromAccount, toAccount, amount);
            Assert.True(bankRepository.Accounts[fromAccount].Salary + amount == previousBalanceSender);
            Assert.True(bankRepository.Accounts[toAccount].Salary - amount == previousBalanceRetriever);
            Assert.Equal(resultStatus, expectedMessage);
        }




    }
}
