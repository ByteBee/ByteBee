using System;

namespace ByteBee.Framework.Abstractions.Messaging
{
    public interface IMessage
    {
        Guid Id { get; }
    }
}