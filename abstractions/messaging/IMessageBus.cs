using System;
using ByteBee.Framework.Messaging.Abstractions.DataClasses;

namespace ByteBee.Framework.Messaging.Abstractions
{
    public interface IMessageBus
    {
        event Action<MessageBusErrorEventArgs> HandlerThrowsException;
        event Action<MessageBusErrorEventArgs> FilterThrowsException;

        void Register<TMessage>(Action<TMessage> handler) where TMessage : IMessage;
        void Register<TMessage>(Action<TMessage> handler, Func<TMessage, bool> filter) where TMessage : IMessage;

        void SetResolverCallback(Func<Type, object> resolverCallback);
        void Register<TResolver, TMessage>(Action<TResolver, TMessage> handler) where TMessage : IMessage;
        void Register<TResolver, TMessage>(Action<TResolver, TMessage> handler, Func<TMessage, bool> filter) where TMessage : IMessage;

        void Publish<TMessage>() where TMessage : IMessage;
        void Publish<TMessage>(params object[] constructorArgs) where TMessage : IMessage;
        void Publish<TMessage>(TMessage message) where TMessage : IMessage;
    }
}