using Xunit;
using Domain.Models;

namespace Test
{
    public class IncreaseTest
    {
        [Fact]
        public void Should_Increase_Balance()
        {
            Balance balance = 100;
            
            balance = balance.Increase(100);

            Assert.Equal(200, (decimal) balance);
        }
    }
}
