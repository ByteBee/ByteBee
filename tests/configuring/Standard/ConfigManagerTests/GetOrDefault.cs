using FluentAssertions;
using NUnit.Framework;

namespace ByteBee.Framework.Tests.Configuring.Standard.ConfigManagerTests
{
    public sealed partial class ConfigManagerTest
    {
        [Test]
        public void GetOrDefault_StringNotFound_NullReturned()
        {
            string result = _config.GetOrDefault<string>("foo", "bar");

            result.Should().BeNull();
        }

        [Test]
        public void GetOrDefault_IntNotFound_NullReturned()
        {
            int result = _config.GetOrDefault<int>("foo", "bar");

            result.Should().Be(0);
        }

        [Test]
        public void GetOrDefault_BoolNotFound_NullReturned()
        {
            bool result = _config.GetOrDefault<bool>("foo", "bar");

            result.Should().BeFalse();
        }
    }
}