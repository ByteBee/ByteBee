using System;
using System.Runtime.Serialization;

namespace ByteBee.Framework.Abstractions.Converting.Exceptions
{
    [Serializable]
    public class ConverterException : Exception
    {
        public ConverterException()
        {
        }

        public ConverterException(string message) : base(message)
        {
        }

        public ConverterException(string message, Exception inner) : base(message, inner)
        {
        }

        protected ConverterException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
