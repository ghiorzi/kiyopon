namespace Domain.Models
{

    public readonly struct Balance
    {
        public readonly decimal Value { get; }

        private Balance(decimal balance)
            => Value = balance;

        public static implicit operator Balance(decimal balance)
            => new Balance(balance);

        public static explicit operator decimal(Balance balance)
            => balance.Value;

        public Balance Increase(Amount amount)
            => new Balance(Value + amount.Value);

        public Balance Decrease(Amount amount)
            => new Balance(Value - amount.Value);

        public bool GreaterOrEqualTo(Amount amount)
            => amount.LessThanOrEqualTo(Value);
    }

}