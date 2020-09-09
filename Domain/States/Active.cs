using System;
using Domain.Abstractions;

namespace Domain.States 
{

    internal class Active : IState
    {
        public IState Activate()
            => this;

        public IState Close()
            => new Closed();

        public IState Deposit(Action onDeposit)
        {
            onDeposit();

            return this;
        }

        public IState Freeze()
            => new Frozen();

        public IState Withdraw(Action onWithdraw)
        {
            onWithdraw();

            return this;
        }
    }

}