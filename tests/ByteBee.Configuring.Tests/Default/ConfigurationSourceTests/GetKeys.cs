using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace ByteBee.Framework.Configuring.Tests.Default.ConfigurationSourceTests
{
    public sealed partial class ConfigurationSourceTest
    {
        [Test]
        public void GetKeys_NoElements_EmptyResult()
        {
            IEnumerable<string> keys = _source.GetKeys("foo");

            keys.Should().BeEmpty("the config is empty");
        }

        [Test]
        public void GetKeys_NoMatchingSection_EmptyResult()
        {
            _source.Set("bar", "test", 1);

            IEnumerable<string> keys = _source.GetKeys("foo");

            keys.Should().BeEmpty("the there are no matching sections");
        }

        [Test]
        public void GetKeys_TwoElements_AllElementsReturned()
        {
            _source.Set("test", "foo", 1);
            _source.Set("test", "bar", 1);

            IEnumerable<string> keys = _source.GetKeys("test");

            keys.Should().NotBeEmpty("the there are matching sections")
                .And.Contain("foo", "foo was defined")
                .And.Contain("bar", "bar was defined");
        }

        [Test]
        public void GetKeys_TwoSections_RequestedSectionKeysReturned()
        {
            _source.Set("foobar", "test", 42);
            _source.Set("test", "foo", 1);
            _source.Set("test", "bar", 1);

            IEnumerable<string> keys = _source.GetKeys("test");

            keys.Should().NotBeEmpty("the there are matching sections")
                .And.HaveCount(2, "only two are relevant")
                .And.Contain("foo", "foo was defined")
                .And.Contain("bar", "bar was defined");
        }
    }
}