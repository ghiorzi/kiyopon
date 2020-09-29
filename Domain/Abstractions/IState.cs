using System;

namespace Domain.Abstractions
{

    internal interface IState
    {
        IState Activate();
        bool CanWithdraw(Func<bool> onCanWithdraw);
        IState Close();
        IState Deposit(Action onDeposit);
        IState Freeze();
        IState Withdraw(Action onWithdraw);
    }

}