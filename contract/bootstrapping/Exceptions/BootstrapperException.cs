using System;
using System.Runtime.Serialization;

namespace ByteBee.Framework.Bootstrapping.Contract.Exceptions
{
    [Serializable]
    public class BootstrapperException : Exception
    {
        public BootstrapperException()
        {
        }

        public BootstrapperException(string message) : base(message)
        {
        }

        public BootstrapperException(string message, Exception inner) : base(message, inner)
        {
        }

        private BootstrapperException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}