using System;
using System.Runtime.Serialization;

namespace ByteBee.Framework.Abstractions.Messaging.Exceptions
{
    [Serializable]
    public sealed class MissingResolverCallbackException : MessagingException
    {
        public MissingResolverCallbackException()
        {
        }

        public MissingResolverCallbackException(string message) : base(message)
        {
        }

        public MissingResolverCallbackException(string message, Exception inner) : base(message, inner)
        {
        }

        private MissingResolverCallbackException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}