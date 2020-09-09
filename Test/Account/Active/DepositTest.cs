using Xunit;
using Domain.Entities;

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
                .Balance;

            Assert.Equal(1500, balance);
        }
    }
}
