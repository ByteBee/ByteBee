using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace ByteBee.Framework.Tests.Configuring.Default.ConfigManagerTests
{
    public sealed partial class ConfigManagerTest
    {
        [Test]
        public void GetKeys_NoElements_EmptyResult()
        {
            IEnumerable<string> keys = _config.GetKeys("foo");

            keys.Should().BeEmpty("the config is empty");
        }

        [Test]
        public void GetKeys_NoMatchingSection_EmptyResult()
        {
            _config.Set("bar", "test", 1);

            IEnumerable<string> keys = _config.GetKeys("foo");

            keys.Should().BeEmpty("the there are no matching sections");
        }

        [Test]
        public void GetKeys_TwoElements_AllElementsReturned()
        {
            _config.Set("test", "foo", 1);
            _config.Set("test", "bar", 1);

            IEnumerable<string> keys = _config.GetKeys("test");

            keys.Should().NotBeEmpty("the there are matching sections")
                .And.Contain("foo", "foo was defined")
                .And.Contain("bar", "bar was defined");
        }

        [Test]
        public void GetKeys_TwoSections_RequestedSectionKeysReturned()
        {
            _config.Set("foobar", "test", 42);
            _config.Set("test", "foo", 1);
            _config.Set("test", "bar", 1);

            IEnumerable<string> keys = _config.GetKeys("test");

            keys.Should().NotBeEmpty("the there are matching sections")
                .And.HaveCount(2, "only two are relevant")
                .And.Contain("foo", "foo was defined")
                .And.Contain("bar", "bar was defined");
        }
    }
}