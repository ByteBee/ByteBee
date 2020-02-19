using System;
using ByteBee.Framework.Fake.BLL.TodoManager.Contract.Messages;
using FluentAssertions;
using NUnit.Framework;

namespace ByteBee.Messaging.Tests.Default.MessageBusTests
{
    public sealed partial class MessageBusTest
    {
        [Test]
        public void RegisterWithFilter_HandlerIsNull_ArgumentNullException()
        {
            Action<TodoMessage> actor = null;
            Func<TodoMessage, bool> filter = m => true;

            Action act = _bus.Invoking(bus => bus.Register(actor, filter));

            act.Should().ThrowExactly<ArgumentNullException>();
        }

        [Test]
        public void RegisterWithFilter_FilterIsNull_ArgumentNullException()
        {
            Action<TodoMessage> actor = m => Console.Write(m.Id);
            Func<TodoMessage, bool> filter = null;

            Action act = _bus.Invoking(bus => bus.Register(actor, filter));

            act.Should().ThrowExactly<ArgumentNullException>();
        }

        [Test]
        public void RegisterWithFilter_FilterIsFalse_ActorIgnoreThis()
        {
            bool sensorWasTriggered = false;
            Action<TodoMessage> actor = m => sensorWasTriggered = true;
            _bus.Register(actor, m => false);

            _bus.Publish<TodoMessage>();

            sensorWasTriggered.Should().BeFalse();
        }

        [Test]
        public void RegisterWithFilter_FilterIsTrue_ActorConsiderThis()
        {
            bool sensorWasTriggered = false;
            Action<TodoMessage> actor = m => sensorWasTriggered = true;
            _bus.Register(actor, m => true);

            _bus.Publish<TodoMessage>();

            sensorWasTriggered.Should().BeTrue();
        }
    }
}