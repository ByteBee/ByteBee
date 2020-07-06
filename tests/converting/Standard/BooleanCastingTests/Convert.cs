using System;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;

namespace ByteBee.Framework.Tests.Converting.Standard.BooleanCastingTests
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
        public void Convert_String_True()
        {
            bool output = _converter.Convert("true");

            output.Should().BeTrue("given parameter was true (but as string)");
        }

        [Test]
        public void Convert_String_False()
        {
            bool output = _converter.Convert("false");

            output.Should().BeFalse("given parameter was false (but as string)");
        }

        [Test]
        public void Convert_CaseInsesitive_False()
        {
            bool output = _converter.Convert("NoPe");

            output.Should().BeFalse("given parameter was false (but as string)");
        }

        [Test]
        public void Convert_CaseInsesitive_True()
        {
            bool output = _converter.Convert("Yes");

            output.Should().BeTrue("given parameter was true (but as string)");
        }

        [Test]
        public void Convert_Int_True()
        {
            bool output = _converter.Convert(1);

            output.Should().BeTrue("given parameter was true (but as int)");
        }

        [Test]
        public void Convert_Int_False()
        {
            bool output = _converter.Convert(0);

            output.Should().BeFalse("given parameter was false (but as int)");
        }

        [Test]
        public void Convert_True_True()
        {
            bool output = _converter.Convert(true);

            output.Should().BeTrue("given parameter was true");
        }

        [Test]
        public void Convert_False_False()
        {
            bool output = _converter.Convert(false);

            output.Should().BeFalse("given parameter was false");
        }

        [Test]
        public void Convert_Answer_True()
        {
            bool output = _converter.Convert("yes");

            output.Should().BeTrue("given parameter was true (but as answer)");
        }

        [Test]
        public void Convert_Answer_False()
        {
            bool output = _converter.Convert("no");

            output.Should().BeFalse("given parameter was false (but as answer)");
        }

        [Test]
        public void Convert_AnswerVariations_True()
        {
            using (new AssertionScope())
            {
                _converter.Convert("ja").Should().BeTrue("ja means false");
                _converter.Convert("yep").Should().BeTrue("yep means false");
            }
        }

        [Test]
        public void Convert_AnswerVariations_False()
        {
            using (new AssertionScope())
            {
                _converter.Convert("nein").Should().BeFalse("nein means false");
                _converter.Convert("nope").Should().BeFalse("nope means false");
            }
        }
    }
}