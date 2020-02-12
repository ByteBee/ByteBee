using System.Globalization;
using ByteBee.Converting.Contract;

namespace ByteBee.Converting.Impl.Converters
{
    internal sealed class StandardIntegerConverter : ITypeConverter<int>
    {
        public int GetStandardValue()
        {
            return 0;
        }

        public int Convert(object value)
        {
            if (value is int output)
            {
                return output;
            }

            return Convert(value.ToString());
        }

        public int Convert(string value)
        {
            return int.Parse(value, NumberStyles.Any, CultureInfo.InvariantCulture);
        }

        public bool TryConvert(object value, out int result)
        {
            if (value is int output)
            {
                result = output;
                return true;
            }

            return TryConvert(value.ToString(), out result);
        }

        public bool TryConvert(string value, out int result)
        {
            return int.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out result);
        }
    }
}