using System;
using ByteBee.Framework.Abstractions.Messaging;

namespace ByteBee.Framework.Tests.Fake.BLL.TodoManager.Contract.Messages
{
    public class TodoMessage : IMessage
    {
        public Guid Id { get; } = Guid.NewGuid();
        public bool IsHandled { get; set; }
        public int HandleCount { get; set; }
    }
}