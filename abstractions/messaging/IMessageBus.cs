using System;
using ByteBee.Framework.Abstractions.Messaging.DataClasses;

namespace ByteBee.Framework.Abstractions.Messaging
{
    public interface IMessageBus : IDisposable
    {
        event Action<MessageBusErrorEventArgs> HandlerThrowsException;
        event Action<MessageBusErrorEventArgs> FilterThrowsException;
        bool BreakOnException { get; set; }

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