using System.Globalization;
using ByteBee.Framework.Converting.Abstractions;

namespace ByteBee.Framework.Converting.Converters
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

            return int.Parse(value.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture);
        }

        public bool TryConvert(object value, out int result)
        {
            if (value is int output)
            {
                result = output;
                return true;
            }

            return int.TryParse(value.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out result);
        }
    }
}