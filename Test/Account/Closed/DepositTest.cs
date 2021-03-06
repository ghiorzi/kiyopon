using Xunit;
using Domain.Models;

namespace Test
{
    public class ClosedDepositTest
    {
        [Fact]
        public void Should_Not_Deposit()
        {
            decimal balance =
                new Account()
                .Deposit(400) // 400
                .Close()
                .Deposit(1000) // do nothing
                .Deposit(500) // do nothing
                .Deposit(750) // do nothing
                .Balance
                .Value;

            Assert.Equal(400, balance);
        }
    }
}
