using System;
using System.Runtime.Serialization;

namespace ByteBee.Framework.Abstractions.DataTypes.Exceptions
{
    [Serializable]
    public class DataTypeException : Exception
    {
        public DataTypeException() 
        {
        }
  
        public DataTypeException(string message) : base(message) 
        {
        }
  
        public DataTypeException(string message, Exception inner) : base(message, inner) 
        {
        }
  
        protected DataTypeException(SerializationInfo info, StreamingContext context) : base(info, context) 
        {
        }
    }
}