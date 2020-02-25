using System;
using System.Runtime.Serialization;

namespace ByteBee.Framework.Injecting.Abstractions.Exceptions
{
    [Serializable]
    public class InjectionException : Exception
    {
        public InjectionException()
        {
        }

        public InjectionException(string message) : base(message)
        {
        }

        public InjectionException(string message, Exception inner) : base(message, inner)
        {
        }

        protected InjectionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
