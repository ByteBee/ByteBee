using System;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;

namespace ByteBee.Configurating.Tests.Default.ConfigurationSourceTests
{
    public sealed partial class ConfigurationSourceTest
    {
        [Test]
        public void TryGet_SectionIsNull_ArgumentNullException()
        {
            Action act = () => _source.TryGet(null, "foo", out int i);

            act.Should()
                .ThrowExactly<ArgumentNullException>("null is not allows as section name");
        }

        [Test]
        public void TryGet_SectionIsEmpty_ArgumentException()
        {
            Action act = () => _source.TryGet("", "foo", out int i);

            act.Should()
                .ThrowExactly<ArgumentException>("empty is not allows as section name");
        }

        [Test]
        public void TryGet_SectionIsWhitespace_ArgumentException()
        {
            Action act = () => _source.TryGet(" ", "foo", out int i);

            act.Should()
                .ThrowExactly<ArgumentException>("whitespace is not allows as section name");
        }

        [Test]
        public void TryGet_KeyIsNull_ArgumentNullException()
        {
            Action act = () => _source.TryGet("foo", null, out int i);

            act.Should()
                .ThrowExactly<ArgumentNullException>("null is not allows as key name");
        }

        [Test]
        public void TryGet_KeyIsEmpty_ArgumentException()
        {
            Action act = () => _source.TryGet("foo", "", out int i);

            act.Should()
                .ThrowExactly<ArgumentException>("empty is not allows as key name");
        }

        [Test]
        public void TryGet_KeyIsWhitespace_ArgumentException()
        {
            Action act = () => _source.TryGet("foo", " ", out int i);

            act.Should()
                .ThrowExactly<ArgumentException>("whitespace is not allows as key name");
        }

        [Test]
        public void TryGet_NoItems_DefaultEntry()
        {
            bool isDefined = _source.TryGet("foobar", "foo", out int i);

            using (new AssertionScope())
            {
                isDefined.Should().BeFalse("there is no such item.");
                i.Should().Be(0, "this is the default value of an int.");
            }
        }

        [Test]
        public void TryGet_ItemDefined_StringValue()
        {
            _source.Set("test", "foo", "helloWorld");

            bool isDefined = _source.TryGet("test", "foo", out string helloWorld);

            using (new AssertionScope())
            {
                isDefined.Should().BeTrue("i know it better!");
                helloWorld.Should().Be("helloWorld", "this string was configured");
            }
        }

        [Test]
        public void TryGet_ItemDefined_IntValue()
        {
            _source.Set("test", "foo", 42);

            bool isDefined = _source.TryGet("test", "foo", out int sinOfLife);

            using (new AssertionScope())
            {
                isDefined.Should().BeTrue("i know it better!");
                sinOfLife.Should().Be(42, "this int was configured");
            }
        }

        [Test]
        public void TryGet_ItemDefined_DoubleValue()
        {
            _source.Set("test", "foo", 3.141592);

            bool isDefined = _source.TryGet("test", "foo", out double pi);

            using (new AssertionScope())
            {
                isDefined.Should().BeTrue("i know it better!");
                pi.Should().Be(3.141592, "this int was configured");
            }
        }

        [Test]
        public void TryGet_ItemDefined_UriValue()
        {
            var url = new Uri("http://www.bytebee.de");
            _source.Set("test", "foo", url);

            bool isDefined = _source.TryGet("test", "foo", out Uri pureKnowledge);

            using (new AssertionScope())
            {
                isDefined.Should().BeTrue("i know it better!");
                pureKnowledge.Should().Be(url, "an uri was specified");
            }
        }

        [Test]
        public void TryGet_ItemDefinedTwice_CorrectValueReturned()
        {
            _source.Set("test", "bar", 1);
            _source.Set("test", "bar", 2);

            bool isDefined = _source.TryGet("test", "bar", out int intValue);

            using (new AssertionScope())
            {
                isDefined.Should().BeTrue("i know it better!");
                intValue.Should().Be(2, "2 was configured within the config");
            }
        }

        [Test]
        public void TryGet_TwoItemsDefined_CorrectValueReturned()
        {
            _source.Set("test", "foo", 1);
            _source.Set("test", "bar", 2);

            bool isDefined = _source.TryGet("test", "bar", out int intValue);

            using (new AssertionScope())
            {
                isDefined.Should().BeTrue("i know it better!");
                intValue.Should().Be(2, "2 was configured within the config");
            }
        }

        [Test]
        public void TryGet_ItemDefinedWrongTypeRequested_InvalidCastException()
        {
            _source.Set("test", "foo", 1);

            Action act = () => _source.TryGet("test", "foo", out string strValue);

            act.Should()
                .ThrowExactly<InvalidCastException>("this key was originally defined as an int");
        }
    }
}