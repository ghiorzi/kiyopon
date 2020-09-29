using System;
using Domain.Abstractions;

namespace Domain.States
{

    internal class Frozen : IState
    {
        public IState Activate()
            => new Active();

        public bool CanWithdraw(Func<bool> onCanWithdraw)
            => onCanWithdraw();
            
        public IState Close()
            => new Closed();

        public IState Deposit(Action onDeposit)
        {
            onDeposit();

            return Activate();
        }

        public IState Freeze()
            => this;

        public IState Withdraw(Action onWithdraw)
        {
            onWithdraw();

            return Activate();
        }
    }

}