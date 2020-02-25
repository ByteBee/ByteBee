using System;
using ByteBee.Framework.Messaging.Abstractions.DataClasses;

namespace ByteBee.Framework.Messaging.Abstractions
{
    public interface IMessageBus
    {
        void Register<TMessage>(Action<TMessage> handler) where TMessage : IMessage;
        void Register<TMessage>(Action<TMessage> handler, Func<TMessage, bool> filter) where TMessage : IMessage;

        void Publish<TMessage>() where TMessage : IMessage;
        void Publish<TMessage>(object[] constructorArgs) where TMessage : IMessage;
        void Publish<TMessage>(TMessage message) where TMessage : IMessage;

        event Action<MessageBusErrorEventArgs> HandlerThrowsException;

        event Action<MessageBusErrorEventArgs> FilterThrowsException;
    }
}