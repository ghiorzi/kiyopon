using Xunit;
using Domain.Models;

namespace Test
{
    public class ActiveDepositTest
    {
        [Fact]
        public void Should_Deposit_1500_Dollars()
        {
            decimal balance =
                new Account()
                .Deposit(1000)
                .Deposit(500)
                .Balance
                .Value;

            Assert.Equal(1500, balance);
        }
    }
}
