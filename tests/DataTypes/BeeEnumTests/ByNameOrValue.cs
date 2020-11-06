using System;
using ByteBee.Framework.DataTypes.Enums;
using ByteBee.Framework.Tests.Stubbing.Data.Enums;
using FluentAssertions;
using NUnit.Framework;

namespace ByteBee.Framework.Tests.DataTypes.BeeEnumTests
{
    public partial class BeeEnumTest
    {
        [Test]
        public void ByName_NotFound_ListPossibleValues()
        {
            var act = this.Invoking(x => TaskPriority.ByName("test"));

            act.Should()
                .ThrowExactly<EnumValueNotFoundException>()
                .WithMessage("The value 'test' is not a valid entry for TaskPriority. Possible values are: Normal, Low, High, Blocker");
        }
        [Test]
        public void ByValue_NotFound_ListPossibleValues()
        {
            var act = this.Invoking(x => TaskPriority.ByValue(0));

            act.Should()
                .ThrowExactly<EnumValueNotFoundException>()
                .WithMessage("The value '0' is not a valid entry for TaskPriority. Possible values are: 1, 2, 3, 4");
        }

        [Test]
        public void ByNameOrValue_NotFound_ListPossibleValues()
        {
            var act = this.Invoking(x => TaskPriority.ByNameOrValue("test"));

            act.Should()
                .ThrowExactly<EnumValueNotFoundException>()
                .WithMessage("The value 'test' is not a valid entry for TaskPriority. Possible values are: Normal (1), Low (2), High (3), Blocker (4)");
        }

        [Test]
        public void ByNameOrValue_StringEmpty_ArgumentException()
        {
            var act = this.Invoking(x => TaskPriority.ByNameOrValue(string.Empty));

            act.Should()
                .ThrowExactly<EnumValueNotFoundException>("name was empty");
        }

        [Test]
        public void ByNameOrValue_ValueNotFound_EnumValueNotFoundException()
        {
            var act = this.Invoking(x => TaskPriority.ByNameOrValue("0"));

            act.Should()
                .ThrowExactly<EnumValueNotFoundException>("zero was not defined");
        }

        [Test]
        public void ByNameOrValue_NameNotFound_EnumValueNotFoundException()
        {
            var act = this.Invoking(x => TaskPriority.ByNameOrValue("very low"));

            act.Should()
                .ThrowExactly<EnumValueNotFoundException>("name was not defined");
        }

        [Test]
        public void ByNameOrValue_KnownName_NoError()
        {
            TaskPriority prio = TaskPriority.ByNameOrValue("normal");

            prio.Should().Be(TaskPriority.Normal, "normal was requested");
        }

        [Test]
        public void ByNameOrValue_KnownValue_NoError()
        {
            TaskPriority prio = TaskPriority.ByNameOrValue("1");

            prio.Should().Be(TaskPriority.Normal, "1 represents normal");
        }
    }
}