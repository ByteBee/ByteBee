using System;

namespace ByteBee.Framework.Messaging.Contract
{
    public interface IMessage
    {
        Guid Id { get; }
    }
}