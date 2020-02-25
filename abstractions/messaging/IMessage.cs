using System;

namespace ByteBee.Framework.Messaging.Abstractions
{
    public interface IMessage
    {
        Guid Id { get; }
    }
}