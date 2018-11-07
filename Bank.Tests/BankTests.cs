using Xunit;
using SamsWebBank.Models;

namespace Bank.Tests
{
    public class BankTests
    {
        [Fact]
        public void PassingTest()
        {
            ErrorViewModel ev = new ErrorViewModel
            {
                RequestId = "100"
            };

            Assert.Equal("100", ev.RequestId);
        }

        [Fact]
        public void FailingTest()
        {
            Assert.Equal(5, Add(2, 3));
        }

        int Add(int x, int y)
        {
            return x + y;
        }
    }
}
