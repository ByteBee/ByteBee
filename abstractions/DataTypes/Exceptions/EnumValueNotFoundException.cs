using System;
using System.Runtime.Serialization;

namespace ByteBee.Framework.Abstractions.DataTypes.Exceptions
{
    [Serializable]
    public sealed class EnumValueNotFoundException : DataTypeException
    {
        public EnumValueNotFoundException() 
        {
        }
  
        public EnumValueNotFoundException(string message) : base(message) 
        {
        }
  
        public EnumValueNotFoundException(string message, Exception inner) : base(message, inner) 
        {
        }

        private EnumValueNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) 
        {
        }
    }
}