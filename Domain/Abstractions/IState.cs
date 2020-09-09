using System;

namespace Domain.Abstractions
{

    internal interface IState
    {
        IState Activate();
        IState Close();
        IState Deposit(Action onDeposit);
        IState Freeze();
        IState Withdraw(Action onWithdraw);
    }

}