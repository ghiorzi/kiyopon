using Xunit;
using Domain.Models;

namespace Test
{
    public class FrozenDepositTest
    {
        [Fact]
        public void Should_Deposit_850_Dollars()
        {
            decimal balance =
                new Account()
                .Close() 
                .Freeze()
                .Deposit(100) // 100 then turns to activate 
                .Deposit(750) // 850
                .Balance;

            Assert.Equal(850, balance);
        }
    }
}
