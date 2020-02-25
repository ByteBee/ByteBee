using System;
using ByteBee.Framework.Messaging.Abstractions.Exceptions;
using ByteBee.Framework.Tests.Fake.BLL.TodoManager.Contract.Messages;
using FluentAssertions;
using NUnit.Framework;

namespace ByteBee.Framework.Tests.Messaging.Default.MessageBusTests
{
    public sealed partial class MessageBusTest
    {
        [Test]
        public void Register_HandlerIsNull_ArgumentNullException()
        {
            Action act = _bus.Invoking(b => b.Register<TodoMessage>(null));
                
            act.Should()
                .ThrowExactly<ArgumentNullException>("sensor is null");
        }

        [Test]
        public void Register_NoActorsOneAdd_OneActor()
        {
            Action<TodoMessage> actor = msg => Console.Write(msg.Id);

            _bus.Register(actor);

            _bus.ActorCount.Should().Be(1);
        }

        [Test]
        public void Register_NoActorsTwoAdds_TwoActors()
        {
            Action<TodoMessage> actor1 = msg => Console.Write(msg.Id);
            Action<TodoMessage> actor2 = msg => Console.WriteLine(msg.Id);
            _bus.Register(actor1);

            _bus.Register(actor2);

            _bus.ActorCount.Should().Be(2);
        }

        [Test]
        public void Register_ActorAddedTwice_DuplicatedActorException()
        {
            Action<TodoMessage> actor = msg => Console.Write(msg.Id);
            _bus.Register(actor);

            Action act = _bus.Invoking(bus => bus.Register(actor));

            act.Should()
                .ThrowExactly<DuplicatedActorException>();
        }
    }
}