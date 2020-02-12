using System;
using System.Runtime.Serialization;

namespace ByteBee.Framework.Adapting.Contract.Exceptions
{
    [Serializable]
    public class AdaptationException : Exception
    {
        public AdaptationException()
        {
        }

        public AdaptationException(string message) : base(message)
        {
        }

        public AdaptationException(string message, Exception inner) : base(message, inner)
        {
        }

        protected AdaptationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
