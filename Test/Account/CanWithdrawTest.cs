using Xunit;
using Domain.Models;

namespace Test
{
    public class CanWithdrawTest
    {
        [Fact]
        public void Should_Be_Able_To_Withdraw_Given_An_Active_Account()
        {
            bool canWithdraw =
                new Account()
                .Deposit(1000) // 1000
                .CanWithdraw(999);

            Assert.True(canWithdraw);
        }

        [Fact]
        public void Should_Be_Able_To_Withdraw_Given_A_Frozen_Account()
        {
            bool canWithdraw =
                new Account()
                .Deposit(1000) // 1000
                .Freeze()
                .CanWithdraw(999);

            Assert.True(canWithdraw);
        }

        [Fact]
        public void Should_Not_Be_Able_To_Withdraw_Given_A_Closed_Account()
        {
            bool canWithdraw =
                new Account()
                .Deposit(1000) // 1000
                .Close()
                .CanWithdraw(999);

            Assert.False(canWithdraw);
        }

        [Fact]
        public void Should_Be_Able_To_Withdraw_When_Amount_Is_Greater_Than_Balance()
        {
            bool canWithdraw =
                new Account()
                .Deposit(1000) // 1000
                .CanWithdraw(1001);

            Assert.False(canWithdraw);
        }
    }
}
