using System;
using ByteBee.Framework.Messaging;
using ByteBee.Framework.Messaging.Abstractions.DataClasses;
using ByteBee.Framework.Tests.Fake.BLL.TodoManager.Contract.Messages;
using FluentAssertions;
using FluentAssertions.Events;
using FluentAssertions.Execution;
using NUnit.Framework;

namespace ByteBee.Framework.Tests.Messaging.Default.MessageBusTests
{
    public sealed partial class MessageBusTest
    {
        [Test]
        public void PublishGeneric_SensorHasNoActors_NothingHappens()
        {
            _bus.Invoking(bus => bus.Publish<TodoMessage>())
                .Should().NotThrow("this is a normal use-case");
        }

        [Test]
        public void PublishGeneric_SensorHasOneActors_ActorWillBeActivated()
        {
            bool sensorHasBeenActivated = false;
            _bus.Register<TodoMessage>(m => sensorHasBeenActivated = true);

            _bus.Publish<TodoMessage>();

            sensorHasBeenActivated.Should().BeTrue();
        }

        [Test]
        public void PublishGeneric_SensorHasTwoActors_BothActorsWillBeActivated()
        {
            bool sensor1Activated = false;
            bool sensor2Activated = false;
            _bus.Register<TodoMessage>(m => sensor1Activated = true);
            _bus.Register<TodoMessage>(m => sensor2Activated = true);

            _bus.Publish<TodoMessage>();

            using (new AssertionScope())
            {
                sensor1Activated.Should().BeTrue();
                sensor2Activated.Should().BeTrue();
            }
        }

        [Test]
        public void PublishGeneric_RegisterOrderOneTwoThree_ActivationOrderMatters()
        {
            string message = string.Empty;
            _bus.Register<TodoMessage>(m => message += "One");
            _bus.Register<TodoMessage>(m => message += "Two");
            _bus.Register<TodoMessage>(m => message += "Three");

            _bus.Publish<TodoMessage>();

            message.Should().Be("OneTwoThree");
        }

        [Test]
        public void PublishGeneric_FirstActorThrowsException_SecondActorExecutes()
        {
            bool sensorWasActivated = false;
            _bus.Register<TodoMessage>(m => throw new Exception());
            _bus.Register<TodoMessage>(m => sensorWasActivated = true);

            _bus.Publish<TodoMessage>();

            sensorWasActivated.Should().BeTrue();
        }

        [Test]
        public void PublishGeneric_FirstActorsFilterThrowsException_SecondActorExecutes()
        {
            bool sensorWasActivated = false;
            _bus.Register<TodoMessage>(m => Console.Write(m.Id), m => throw new Exception());
            _bus.Register<TodoMessage>(m => sensorWasActivated = true);

            _bus.Publish<TodoMessage>();

            sensorWasActivated.Should().BeTrue();
        }

        [Test]
        public void PublishGeneric_ActorThrowsAndSwallowAnException_ExceptionEventShouldBeFired()
        {
            _bus.Register<TodoMessage>(m => throw new Exception());

            using (IMonitor<StandardMessageBus> subject = _bus.Monitor())
            {
                _bus.Publish<TodoMessage>();

                subject.Should()
                    .Raise("HandlerThrowsException")
                    .WithArgs<MessageBusErrorEventArgs>(args =>
                        args.Message.GetType() == typeof(TodoMessage) &&
                        args.Exception != null
                    );
            }
        }

        [Test]
        public void PublicGeneric_ActorThrowsAnException_ExceptionWillBeForwarded()
        {
            _bus.BreakOnException = true;
            _bus.Register<TodoMessage>(m => throw new ArgumentException("foobar"));

            _bus.Invoking(bus => bus.Publish<TodoMessage>())
                .Should()
                .ThrowExactly<ArgumentException>()
                .WithMessage("*foobar*")
                .And.StackTrace.Should().NotBeEmpty();
        }

        [Test]
        public void PublishGeneric_FilterThrowsAnException_ExceptionEventShouldBeFired()
        {
            _bus.Register<TodoMessage>(m => Console.Write(m.Id), m => throw new Exception());

            using (IMonitor<StandardMessageBus> subject = _bus.Monitor())
            {
                _bus.Publish<TodoMessage>();

                subject.Should()
                    .Raise("FilterThrowsException")
                    .WithArgs<MessageBusErrorEventArgs>(args =>
                        args.Message.GetType() == typeof(TodoMessage) &&
                        args.Exception != null
                    );
            }
        }
    }
}