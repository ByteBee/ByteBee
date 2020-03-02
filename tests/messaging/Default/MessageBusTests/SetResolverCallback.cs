using System;
using ByteBee.Framework.Messaging.Abstractions.Exceptions;
using ByteBee.Framework.Tests.Fake.BLL.TodoManager.Contract.Messages;
using ByteBee.Framework.Tests.Fake.BLL.TodoManager.Impl;
using FluentAssertions;
using NUnit.Framework;

namespace ByteBee.Framework.Tests.Messaging.Default.MessageBusTests
{
    public sealed partial class MessageBusTest
    {
        [Test]
        public void SetResolverCallback_NullAsCallback_ArgumentException()
        {
            Func<Type, object> resolver = null;

            Action act = _bus.Invoking(b => b.SetResolverCallback(resolver));

            act.Should()
                .ThrowExactly<ArgumentException>("resolver was null");
        }

        [Test]
        public void SetResolverCallback_NoCallbackButRequested_MissingResolverCallbackException()
        {
            _bus.Register<TodoMessageHandler, TodoMessage>((h, m) => h.Create(m));

            Action act = _bus.Invoking(b => b.Publish<TodoMessage>());

            act.Should()
                .ThrowExactly<MissingResolverCallbackException>();
        }
    }
}