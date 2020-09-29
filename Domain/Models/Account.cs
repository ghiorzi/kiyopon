using System;
using Domain.Abstractions;
using Domain.States;

namespace Domain.Models
{

    public class Account
    {
        // .NET 5 problem with decimal
        //public Balance Balance { get; private set; }
        public decimal Balance { get; private set; }
        
        private IState _state;

        public Account()
            => Update(() => new Active());

        public Account Activate()
            => Update(() => _state.Activate());

        public bool CanWithdraw(decimal amount)
            => _state.CanWithdraw(() => amount <= Balance);

        public Account Close()
            => Update(() => _state.Close());

        public Account Freeze()
            => Update(() => _state.Freeze());

        /*
        .NET 5 decimal problem
        public Account Deposit(Amount amount)
            => Update(() => _state.Deposit(() => Balance.Increase(amount)));

        public Account Withdraw(Amount amount)
            => Update(() => _state.Withdraw(() => Balance.Decrease(amount)));

        */
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