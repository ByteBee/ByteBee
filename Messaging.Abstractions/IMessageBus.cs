using System;
using ByteBee.Framework.Messaging.Abstractions.DataClasses;

namespace ByteBee.Framework.Messaging.Abstractions
{
    public interface IMessageBus : IDisposable
    {
        event Action<MessageBusErrorEventArgs> HandlerThrowsException;
        event Action<MessageBusErrorEventArgs> FilterThrowsException;
        bool BreakOnException { get; set; }

        void Register<TMessage>(Action<TMessage> handler);
        void Register<TMessage>(Action<TMessage> handler, Func<TMessage, bool> filter);

        void SetResolverCallback(Func<Type, object> resolverCallback);
        void Register<TResolver, TMessage>(Action<TResolver, TMessage> handler);
        void Register<TResolver, TMessage>(Action<TResolver, TMessage> handler, Func<TMessage, bool> filter);

        void Publish<TMessage>();
        void Publish<TMessage>(params object[] constructorArgs);
        void Publish<TMessage>(TMessage message);
    }
}