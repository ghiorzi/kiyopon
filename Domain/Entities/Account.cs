using System;
using Domain.Abstractions;
using Domain.States;

namespace Domain.Entities
{

    public class Account
    {
        public decimal Balance { get; private set; }
        private IState _state;

        public Account()
            => Update(() => new Active());

        public Account Activate()
            => Update(() => _state.Activate());

        public Account Close()
            => Update(() => _state.Close());

        public Account Freeze()
            => Update(() => _state.Freeze());

        public Account Deposit(decimal amount)
            => Update(() => _state.Deposit(() => Balance += amount));

        public Account Withdraw(decimal amount)
            => Update(() => _state.Withdraw(() => Balance -= amount));

        private Account Update(Func<IState> onChange)
        {
            _state = onChange();

            return this;
        }
    }

}