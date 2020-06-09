using System;
using System.Runtime.Serialization;

namespace ByteBee.Framework.Configuring.Abstractions.Exceptions
{
    [Serializable]
    public sealed class SectionOrKeyNotFoundException : ConfigurationException
    {
        public SectionOrKeyNotFoundException(string section, string key)
            : this($"configuration section '{section}' or key '{key}' not found.")
        {
        }

        public SectionOrKeyNotFoundException(string message) : base(message)
        {
        }

        public SectionOrKeyNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }

        private SectionOrKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}