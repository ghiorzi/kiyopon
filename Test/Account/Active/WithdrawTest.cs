using Xunit;
using Domain.Models;

namespace Test
{
    public class ActiveWithdrawTest
    {
        [Fact]
        public void Should_Withdraw_5000_Dollars()
        {
            decimal balance =
                new Account() // 0
                .Deposit(5100) // 5100
                .Withdraw(4000) // 1100
                .Withdraw(500) // 600
                .Withdraw(250) // 350
                .Withdraw(250) // 100
                .Balance;

            Assert.Equal(100, balance);
        }
    }
}
