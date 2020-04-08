using System;
using ByteBee.Framework.Abstractions.Converting;
using FluentAssertions;
using FluentAssertions.Execution;
using Moq;
using NUnit.Framework;

namespace ByteBee.Framework.Tests.Configuring.Standard.ConfigManagerTests
{
    public sealed partial class ConfigManagerTest
    {
        [Test]
        public void TryGet_SectionIsNull_ArgumentNullException()
        {
            Action act = () => _config.TryGet(null, "foo", out int _);

            act.Should()
                .ThrowExactly<ArgumentNullException>("null is not allows as section name");
        }

        [Test]
        public void TryGet_SectionIsEmpty_ArgumentException()
        {
            Action act = () => _config.TryGet("", "foo", out int _);

            act.Should()
                .ThrowExactly<ArgumentException>("empty is not allows as section name");
        }

        [Test]
        public void TryGet_SectionIsWhitespace_ArgumentException()
        {
            Action act = () => _config.TryGet(" ", "foo", out int _);

            act.Should()
                .ThrowExactly<ArgumentException>("whitespace is not allows as section name");
        }

        [Test]
        public void TryGet_KeyIsNull_ArgumentNullException()
        {
            Action act = () => _config.TryGet("foo", null, out int _);

            act.Should()
                .ThrowExactly<ArgumentNullException>("null is not allows as key name");
        }

        [Test]
        public void TryGet_KeyIsEmpty_ArgumentException()
        {
            Action act = () => _config.TryGet("foo", "", out int _);

            act.Should()
                .ThrowExactly<ArgumentException>("empty is not allows as key name");
        }

        [Test]
        public void TryGet_KeyIsWhitespace_ArgumentException()
        {
            Action act = () => _config.TryGet("foo", " ", out int _);

            act.Should()
                .ThrowExactly<ArgumentException>("whitespace is not allows as key name");
        }

        [Test]
        public void TryGet_NoItems_DefaultEntry()
        {
            bool isDefined = _config.TryGet("foobar", "foo", out int i);

            using (new AssertionScope())
            {
                isDefined.Should().BeFalse("there is no such item.");
                i.Should().Be(0, "this is the default value of an int.");
            }
        }

        [Test]
        public void TryGet_ItemDefined_StringValue()
        {
            var mock = new Mock<ITypeConverter<string>>();
            mock.Setup(c => c.Convert(It.IsAny<string>())).Returns("helloWorld");
            _converter.RegisterCustomConverter(mock.Object);
            _config.Set("test", "foo", "helloWorld");

            bool isDefined = _config.TryGet("test", "foo", out string helloWorld);

            using (new AssertionScope())
            {
                isDefined.Should().BeTrue("i know it better!");
                helloWorld.Should().Be("helloWorld", "this string was configured");
            }
        }

        [Test]
        public void TryGet_ItemDefined_IntValue()
        {
            var mock = new Mock<ITypeConverter<int>>();
            mock.Setup(c => c.Convert(It.IsAny<int>())).Returns(42);
            _converter.RegisterCustomConverter(mock.Object);
            _config.Set("test", "foo", 42);

            bool isDefined = _config.TryGet("test", "foo", out int sinOfLife);

            using (new AssertionScope())
            {
                isDefined.Should().BeTrue("i know it better!");
                sinOfLife.Should().Be(42, "this int was configured");
            }
        }

        [Test]
        public void TryGet_ItemDefined_DoubleValue()
        {
            var mock = new Mock<ITypeConverter<double>>();
            mock.Setup(c => c.Convert(It.IsAny<double>())).Returns(3.141592);
            _converter.RegisterCustomConverter(mock.Object);
            _config.Set("test", "foo", 3.141592);

            bool isDefined = _config.TryGet("test", "foo", out double pi);

            using (new AssertionScope())
            {
                isDefined.Should().BeTrue("i know it better!");
                pi.Should().Be(3.141592, "this double was configured");
            }
        }

        [Test]
        public void TryGet_ItemDefined_UriValue()
        {
            var url = new Uri("https://www.bytebee.de");
            var mock = new Mock<ITypeConverter<Uri>>();
            mock.Setup(c => c.Convert(It.IsAny<Uri>())).Returns(url);
            _converter.RegisterCustomConverter(mock.Object);
            
            _config.Set("test", "foo", url);

            bool isDefined = _config.TryGet("test", "foo", out Uri pureKnowledge);

            using (new AssertionScope())
            {
                isDefined.Should().BeTrue("i know it better!");
                pureKnowledge.Should().Be(url, "an uri was specified");
            }
        }

        [Test]
        public void TryGet_ItemDefinedTwice_CorrectValueReturned()
        {
            _config.Set("test", "bar", 1);
            _config.Set("test", "bar", 2);

            bool isDefined = _config.TryGet("test", "bar", out int intValue);

            using (new AssertionScope())
            {
                isDefined.Should().BeTrue("i know it better!");
                intValue.Should().Be(2, "2 was configured within the config");
            }
        }

        [Test]
        public void TryGet_TwoItemsDefined_CorrectValueReturned()
        {
            _config.Set("test", "foo", 1);
            _config.Set("test", "bar", 2);

            bool isDefined = _config.TryGet("test", "bar", out int intValue);

            using (new AssertionScope())
            {
                isDefined.Should().BeTrue("i know it better!");
                intValue.Should().Be(2, "2 was configured within the config");
            }
        }

        [Test]
        public void TryGet_RetrieveObjectAsString_NoErrors()
        {
            _config.Set("test", "foo", "bar");

            bool isDefined = _config.TryGet<object>("test", "foo", out object value);

            using (new AssertionScope())
            {
                isDefined.Should().BeTrue();
                value.Should().Be("bar");
            }
        }
    }
}