using System;
using FluentAssertions;
using NUnit.Framework;

namespace ByteBee.Framework.Converting.Tests.Default.BooleanCastingTests
{
    public sealed partial class BoolConverterTest
    {
        [Test]
        public void Convert_ObjIsNull_ArgumentNullException()
        {
            Action act = () => _converter.Convert(null);

            act.Should().ThrowExactly<ArgumentNullException>("the parameter was null");
        }

        [Test]
        public void Convert_TrueAsString_True()
        {
            const string Argument = "true";

            bool output = _converter.Convert(Argument);

            output.Should().BeTrue("given parameter was true (but as string)");
        }

        [Test]
        public void Convert_FalseAsString_False()
        {
            const string Argument = "false";

            bool output = _converter.Convert(Argument);

            output.Should().BeFalse("given parameter was false (but as string)");
        }
    }
}