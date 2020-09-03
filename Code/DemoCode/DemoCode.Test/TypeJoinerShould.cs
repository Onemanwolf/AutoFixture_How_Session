using Xunit;
using FluentAssertions;

namespace DemoCode.Test
{
    public class TypeJoinerShould
    {
       
        [Fact]
        public void TypeJoinerJoinTypeString()
        {
            var sut = new TypeJoiner<string>();

            var valueOne = "Tim";
            var valueTwo = "Oleson";
            var expected = valueOne + " " + valueTwo;

            sut.Join(valueOne, valueTwo);

            sut.Joined.Should().Be(expected);

        }
    }
}
