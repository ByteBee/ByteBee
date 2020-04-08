using FluentAssertions;
using NUnit.Framework;

namespace ByteBee.Framework.Tests.Configuring.Standard.ConfigManagerTests
{
    public sealed partial class ConfigManagerTest
    {
        [Test]
        public void Clear_NoEntries_NoEntries()
        {
            _config.Clear();

            _config.NumberOfEntries
                .Should().Be(0, "it was cleared");
        }

        [Test]
        public void Clear_ThreeEntries_NoEntries()
        {
            _config.Set("test", "foo", 1);
            _config.Set("test", "bar", 2);
            _config.Set("test", "baz", 3);

            _config.Clear();

            _config.NumberOfEntries
                .Should().Be(0, "it was cleared");
        }
    }
}