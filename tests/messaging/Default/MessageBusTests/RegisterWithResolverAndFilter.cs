using System;
using ByteBee.Framework.Tests.Fake.BLL.TodoManager.Contract.Messages;
using ByteBee.Framework.Tests.Fake.BLL.TodoManager.Impl;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;

namespace ByteBee.Framework.Tests.Messaging.Default.MessageBusTests
{
    public sealed partial class MessageBusTest
    {
        [Test]
        public void RegisterWithResolverAndFilter_HandlerIsNull_ArgumentException()
        {
            Action<TodoMessageHandler, TodoMessage> actor = null;
            Func<TodoMessage, bool> filter = m => true;

            Action act = _bus.Invoking(b => b.Register(actor, filter));
                
            act.Should()
                .ThrowExactly<ArgumentNullException>("sensor is null");
        }

        [Test]
        public void RegisterWithResolverAndFilter_FilterIsNull_ArgumentException()
        {
            Action<TodoMessageHandler, TodoMessage> actor = (h, m) => h.Create(m);
            Func<TodoMessage, bool> filter = null;

            Action act = _bus.Invoking(b => b.Register(actor, filter));
            
            act.Should()
                .ThrowExactly<ArgumentNullException>("filter is null");
        }

        [Test]
        public void RegisterWithResolverAndFilter_NoActorsOneAdd_OneActor()
        {
            _bus.Register<TodoMessageHandler, TodoMessage>((r, m) => r.Create(m));

            _bus.ActorCount
                .Should().Be(1);
        }

        [Test]
        public void RegisterWithResolverAndFilter_FilterIsTrue_ActorWillBeActivated()
        {
            Action<TodoMessageHandler, TodoMessage> actor = (r, m) => r.Create(m);
            Func<TodoMessage, bool> filter = m => true;
            _bus.SetResolverCallback(x => new TodoMessageHandler());
            var message = new TodoMessage();
            
            _bus.Register(actor, filter);
            _bus.Publish(message);

            using (new AssertionScope())
            {
                message.IsHandled.Should().BeTrue();
                message.HandleCount.Should().Be(1);
            }
        }

        [Test]
        public void RegisterWithResolverAndFilter_FilterIsFalse_ActorWillBeIgnored()
        {
            Action<TodoMessageHandler, TodoMessage> actor = (r, m) => r.Create(m);
            Func<TodoMessage, bool> filter = m => false;
            _bus.SetResolverCallback(x => new TodoMessageHandler());
            var message = new TodoMessage();
            
            _bus.Register(actor, filter);
            _bus.Publish(message);

            using (new AssertionScope())
            {
                message.IsHandled.Should().BeFalse();
                message.HandleCount.Should().Be(0);
            }
        }
    }
}