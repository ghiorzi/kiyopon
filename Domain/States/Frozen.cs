using System;
using Domain.Abstractions;

namespace Domain.States
{

    internal class Frozen : IState
    {
        public IState Activate()
            => new Active();

        public IState Close()
            => new Closed();

        public IState Deposit(Action onDeposit)
        {
            onDeposit();

            return new Active();
        }

        public IState Freeze()
            => this;

        public IState Withdraw(Action onWithdraw)
        {
            onWithdraw();

            return new Active();
        }
    }

}