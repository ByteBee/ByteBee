using System;
using ByteBee.Converting.Contract;

namespace ByteBee.Converting.Impl.Converters
{
    internal sealed class StandardDateTimeConverter : ITypeConverter<DateTime>
    {
        public DateTime GetStandardValue()
        {
            return new DateTime();
        }

        public DateTime Convert(object value)
        {
            throw new NotImplementedException();
        }

        public bool TryConvert(object value, out DateTime result)
        {
            throw new NotImplementedException();
        }
    }
}