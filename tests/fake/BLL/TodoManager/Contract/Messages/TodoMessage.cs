using System;
using ByteBee.Framework.Messaging.Abstractions;

namespace ByteBee.Framework.Tests.Fake.BLL.TodoManager.Contract.Messages
{
    public class TodoMessage : IMessage
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}