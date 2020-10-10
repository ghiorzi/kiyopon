using Xunit;
using Domain.Models;

namespace Test
{
    public class DecreaseTest
    {
        [Fact]
        public void Should_Decrease_Balance()
        {
            Balance balance = 100;
            
            balance = balance.Decrease(90);

            Assert.Equal(10, (decimal) balance);
        }
    }
}
