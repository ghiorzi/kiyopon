namespace Domain.Models
{

    public struct Balance
    {
        private decimal _value;

        private Balance(decimal balance)
            => _value = balance;

        public static implicit operator Balance(decimal balance)
            => new Balance(balance);

        public static explicit operator decimal(Balance balance)
            => balance._value;

        public Balance Increase(Amount amount)
        {
            _value += (decimal)amount;

            return this;
        }

        public Balance Decrease(Amount amount)
        {
            _value -= (decimal) amount;

            return this;
        }

        public bool GreaterOrEqualTo(Amount amount)
            => amount.LessThanOrEqualTo(_value);
    }

}