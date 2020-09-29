using Xunit;
using Domain.Models;

namespace Test
{
    public class AccountTest
    {
        [Fact]
        public void Should_Deposit_4000_Dollars_When_Frozen_Or_Active()
        {
            decimal balance =
                new Account()
                .Deposit(1000) // 1000
                .Deposit(300) // 1300
                .Close()
                .Deposit(700) // do nothing
                .Deposit(5000) // do nothing
                .Freeze()
                .Deposit(2000) // 3300 then turns to activate 
                .Deposit(700) // 4000
                .Close()
                .Deposit(500) // do nothing
                .Balance;

            Assert.Equal(4000, balance);
        }

        [Fact]
        public void Should_Withdraw_1800_Dollars_When_Frozen_Or_Active()
        {
            decimal balance =
                new Account()
                .Deposit(2000) // 2000
                .Close()
                .Withdraw(700) // do nothing
                .Withdraw(5000) // do nothing
                .Freeze()
                .Withdraw(800) // 1200 then turns to activate 
                .Withdraw(200) // 1000
                .Close()
                .Withdraw(500) // do nothing
                .Withdraw(700) // do nothing
                .Activate()
                .Withdraw(800) // 200
                .Balance;

            Assert.Equal(200, balance);
        }
    }
}
