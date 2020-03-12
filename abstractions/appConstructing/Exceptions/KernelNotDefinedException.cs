using System;
using System.Runtime.Serialization;

namespace ByteBee.Framework.AppConstructing.Abstractions.Exceptions
{
    [Serializable]
    public sealed class KernelNotDefinedException : AppConstructingException
    {
        public KernelNotDefinedException()
        {
        }

        public KernelNotDefinedException(string message) : base(message)
        {
        }

        public KernelNotDefinedException(string message, Exception inner) : base(message, inner)
        {
        }

        private KernelNotDefinedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}