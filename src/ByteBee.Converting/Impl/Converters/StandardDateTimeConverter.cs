using System;
using ByteBee.Framework.Converting.Contract;

namespace ByteBee.Framework.Converting.Impl.Converters
{
    internal sealed class StandardDateTimeConverter : ITypeConverter<DateTime>
    {
        public DateTime GetStandardValue()
        {
            return new DateTime();
        }

        public DateTime Convert(object value)
        {
            if (value is DateTime output)
            {
                return output;
            }

            return DateTime.Parse(value.ToString());
        }

        public bool TryConvert(object value, out DateTime result)
        {
            if (value is DateTime output)
            {
                result = output;
                return true;
            }

            return DateTime.TryParse(value.ToString(), out result);
        }
    }
}