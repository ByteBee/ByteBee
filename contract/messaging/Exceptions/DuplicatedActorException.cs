using System;
using System.Runtime.Serialization;

namespace ByteBee.Framework.Messaging.Contract.Exceptions
{
    [Serializable]
    public class DuplicatedActorException : MessagingException
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

        protected DuplicatedActorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}