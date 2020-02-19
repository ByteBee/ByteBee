using System;
using ByteBee.Framework.Messaging.Contract;

namespace ByteBee.Framework.Fake.BLL.TodoManager.Contract.Messages
{
    public class TodoMessage : IMessage
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}