using FluentAssertions;
using NUnit.Framework;

namespace ByteBee.Framework.Tests.Configuring.Standard.ConfigManagerTests
{
    public sealed partial class ConfigManagerTest
    {
        [Test]
        public void GetOrFallback_StringNotFoundFooRequested_FooReturned()
        {
            const string Requested = "foo";
            string result = _config.GetOrFallback("foo", "bar", Requested);

            result.Should().Be(Requested);
        }

        [Test]
        public void GetOrFallback_IntNotFoundFourtyTwoRequested_FourtyTwoReturned()
        {
            const int Requested = 42;
            int result = _config.GetOrFallback("foo", "bar", Requested);

            result.Should().Be(Requested);
        }

        [Test]
        public void GetOrFallback_BoolNotFoundTrueRequested_TrueReturned()
        {
            const bool Requested = true;
            bool result = _config.GetOrFallback("foo", "bar", Requested);

            result.Should().BeTrue();
        }
    }
}