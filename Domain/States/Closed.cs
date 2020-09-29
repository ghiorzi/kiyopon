using System;
using Domain.Abstractions;

namespace Domain.States
{

    internal class Closed : IState
    {
        public IState Activate()
            => new Active();

        public bool CanWithdraw(Func<bool> onCanWithdraw)
            => false;

        public IState Close()
            => this;

        public IState Deposit(Action onDeposit)
            => this;

        public IState Freeze()
            => new Frozen();

        public IState Withdraw(Action onWithdraw)
            => this;
    }

}