using System.Globalization;
using ByteBee.Framework.Converting.Abstractions;

namespace ByteBee.Framework.Converting.Converters
{
    internal sealed class StandardShortConverter : ITypeConverter<short>
    {
        public short GetStandardValue()
        {
            return 0;
        }

        public short Convert(object value)
        {
            if (value is short output)
            {
                return output;
            }

            return short.Parse(value.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture);
        }

        public bool TryConvert(object value, out short result)
        {
            if (value is short output)
            {
                result = output;
                return true;
            }

            return short.TryParse(value.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out result);
        }
    }
}