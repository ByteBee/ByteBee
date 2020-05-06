using System;
using ByteBee.Framework.Tests.Stubbing.LogicLayer.TodoManager.Abstractions.Messages;
using ByteBee.Framework.Tests.Stubbing.LogicLayer.TodoManager.Concrete;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;

namespace ByteBee.Framework.Tests.Messaging.Default.MessageBusTests
{
    public sealed partial class MessageBusTest
    {
        [Test]
        public void RegisterWithResolver_HandlerIsNull_ArgumentException()
        {
            Action<TodoMessageHandler, TodoMessage> actor = null;

            Action act = _bus.Invoking(b => b.Register(actor));
                
            act.Should()
                .ThrowExactly<ArgumentNullException>("sensor is null");
        }

        [Test]
        public void RegisterWithResolver_NoActorsOneAdd_OneActor()
        {
            _bus.Register<TodoMessageHandler, TodoMessage>((r, m) => r.Create(m));

            _bus.ActorCount
                .Should().Be(1);
        }

        [Test]
        public void RegisterWithResolver_OneActorRegistered_ActorWillActivated()
        {
            Action<TodoMessageHandler, TodoMessage> actor = (r, m) => r.Create(m);
            _bus.SetResolverCallback(x => new TodoMessageHandler());
            var message = new TodoMessage();
            
            _bus.Register(actor);
            _bus.Publish(message);

            using (new AssertionScope())
            {
                message.IsHandled.Should().BeTrue();
                message.HandleCount.Should().Be(1);
            }
        }
    }
}