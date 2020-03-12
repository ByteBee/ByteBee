using System;
using System.Runtime.Serialization;

namespace ByteBee.Framework.AppConstructing.Abstractions.Exceptions
{
    [Serializable]
    public class AppConstructingException : Exception
    {
        public AppConstructingException()
        {
        }

        public AppConstructingException(string message) : base(message)
        {
        }

        public AppConstructingException(string message, Exception inner) : base(message, inner)
        {
        }

        protected AppConstructingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}