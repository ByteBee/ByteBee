using System;
using ByteBee.Framework.Messaging.Abstractions.Exceptions;

namespace ByteBee.Framework.Messaging
{
    internal class Throw
    {
        public static void IfHandlerIsNull<TMessage>(Action<TMessage> handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }
        }

        public static void IfHandlerIsNull<TResolver, TMessage>(Action<TResolver, TMessage> handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }
        }

        public static void IfFilterIsNull<TMessage>(Func<TMessage, bool> filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }
        }

        public static void IfResolverCallbackIsNull(Func<Type, object> resolverCallback)
        {
            if (resolverCallback == null)
            {
                throw new ArgumentException(nameof(resolverCallback));
            }
        }

        public static void DuplicatedActorException(string message)
        {
            throw new DuplicatedActorException(message);
        }

        public static void MissingResolverCallbackException()
        {
            throw new MissingResolverCallbackException();
        }
    }
}