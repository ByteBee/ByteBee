using System;
using System.Runtime.Serialization;

namespace ByteBee.Framework.Messaging.Abstractions.Exceptions
{
    [Serializable]
    public sealed class DuplicatedActorException : MessagingException
    {
        public DuplicatedActorException()
        {
        }

        public DuplicatedActorException(string message) : base(message)
        {
        }

        public DuplicatedActorException(string message, Exception inner) : base(message, inner)
        {
        }

        private DuplicatedActorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}