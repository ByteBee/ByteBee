using FluentAssertions;
using NUnit.Framework;

namespace ByteBee.Framework.Tests.Converting.Default.Int16CastingTests
{
    public sealed partial class Int16CastingTest
    {
        [Test]
        public void GetStandardValue_ZeroAsShort()
        {
            short value = _converter.GetStandardValue();

            value.Should().Be(0, "0 is the default value of short")
                .And.BeOfType(typeof(short));
        }
    }
}