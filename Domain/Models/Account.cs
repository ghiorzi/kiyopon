using System;
using Domain.Abstractions;
using Domain.States;

namespace Domain.Models
{

    public class Account
    {
        public Balance Balance { get; private set;}
        
        private IState _state;
        private Action<Amount> _deposit;
        private Action<Amount> _withdraw;

        public Account()
        {
            this._state = new Active();

            this._deposit = amount => Balance = Balance.Increase(amount);
            this._withdraw = amount => Balance = Balance.Decrease(amount);
        } 
        
        public Account Activate()
            => Update(() => _state.Activate());

        public bool CanWithdraw(Amount amount)
            => _state.CanWithdraw(() => amount.LessThanOrEqualTo(Balance.Value));

        public Account Close()
            => Update(() => _state.Close());

        public Account Freeze()
            => Update(() => _state.Freeze());

        public Account Deposit(Amount amount)
            => Update(() => _state.Deposit(() => _deposit(amount)));

        public Account Withdraw(Amount amount)
            => Update(() => _state.Withdraw(() => _withdraw(amount)));

        private Account Update(Func<IState> onChange)
        {
            _state = onChange();

            return this;
        }
    }

}