using System;
using System.Runtime.Serialization;

namespace ByteBee.Framework.Configuring.Contract.Exceptions
{
    [Serializable]
    public class ConfiguringException : Exception
    {
        public ConfiguringException()
        {
        }

        public ConfiguringException(string message) : base(message)
        {
        }

        public ConfiguringException(string message, Exception inner) : base(message, inner)
        {
        }

        protected ConfiguringException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
