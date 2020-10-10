using Pandemonium;

namespace Domain.Models
{

    public readonly struct Amount
    {

        public readonly decimal Value 
            => _value; 

        private readonly decimal _value;

        private Amount(decimal amount)
            => _value = amount;
        
        public static implicit operator Amount(decimal amount) 
            => new Amount(amount);
        
        public static explicit operator decimal(Amount amount) 
            => amount._value;

        public bool LessThanOrEqualTo(decimal value)
            => _value.LessThanOrEqualTo(value);
    } 

}