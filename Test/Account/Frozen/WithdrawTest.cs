using Xunit;
using Domain.Entities;

namespace Test
{
    public class FrozenWithdrawTest
    {
        [Fact]
        public void Should_Withdraw_200_Dollars()
        {
            decimal balance =
                new Account()
                .Deposit(400)
                .Close()
                .Freeze()
                .Withdraw(30) // 370 then turns to activate
                .Withdraw(170) // 200
                .Balance;

            Assert.Equal(200, balance);
        }
    }
}
