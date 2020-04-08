using FluentAssertions;
using NUnit.Framework;

namespace ByteBee.Framework.Tests.Configuring.Standard.ConfigManagerTests
{
    public sealed partial class ConfigManagerTest
    {
        [Test]
        public void GetOrFallbackFunc_StringNotFoundFooRequested_FooReturned()
        {
            const string Requested = "foo";
            string result = _config.GetOrFallback("foo", "bar", () => Requested);

            result.Should().Be(Requested);
        }

        [Test]
        public void GetOrFallbackFunc_IntNotFoundFourtyTwoRequested_FourtyTwoReturned()
        {
            const int Requested = 42;
            int result = _config.GetOrFallback("foo", "bar", () => Requested);

            result.Should().Be(Requested);
        }

        [Test]
        public void GetOrFallbackFunc_BoolNotFoundTrueRequested_TrueReturned()
        {
            const bool Requested = true;
            bool result = _config.GetOrFallback("foo", "bar", () => Requested);

            result.Should().BeTrue();
        }
    }
}