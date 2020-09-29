using Xunit;
using Domain.Models;

namespace Test
{
    public class ClosedWithdrawTest
    {
        [Fact]
        public void Should_Not_Withdraw()
        {
            decimal balance =
                new Account()
                .Deposit(50) // 50
                .Close()
                .Withdraw(1000) // do nothing
                .Withdraw(300) // do nothing
                .Balance;

            Assert.Equal(50, balance);
        }
    }
}
