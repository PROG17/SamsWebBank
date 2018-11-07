using Xunit;
using SamsWebBank.Models;

namespace Bank.Tests
{
    public class BankRepositoryTests
    {
        [Theory]
        [InlineData(1, 100, 9900)]
        [InlineData(5, 10000, 90000)]
        [InlineData(6, 12000, 0)]
        public void Withdraw_WithValidArguments_UpdatesAccountWithCorrectSalary(int accountNumber, decimal amount, decimal expectedSalary)
        {
            var bankRepository = new BankRepository();

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
            var bankRepository = new BankRepository();

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
            var bankRepository = new BankRepository();

            var resultStatus = bankRepository.Withdraw(accountNumber, amount);

            Assert.Equal(expectedErrorMessage, resultStatus);
        }




    }
}
