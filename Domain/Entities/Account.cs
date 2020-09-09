using System;
using Domain.Abstractions;
using Domain.States;

namespace Domain.Entities
{

    public class Account
    {
        private decimal _balance;
        private IState _state;

        public Account()
            => Update(() => new Active());

        public Account Close()
            => Update(() => _state.Close());

        public Account Freeze()
            => Update(() => _state.Freeze());

        public Account Deposit(decimal amount)
            => Update(() => _state.Deposit(() => _balance += amount));

        public Account Withdraw(decimal amount)
            => Update(() => _state.Withdraw(() => _balance -= amount));

        private Account Update(Func<IState> onChange)
        {
            _state = onChange();

            return this;
        }
    }

}