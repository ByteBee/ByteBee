using System.Globalization;
using ByteBee.Framework.Converting.Contract;

namespace ByteBee.Framework.Converting.Impl.Converters
{
    internal sealed class StandardLongConverter : ITypeConverter<long>
    {
        public long GetStandardValue()
        {
            return 0L;
        }

        public long Convert(object value)
        {
            if (value is long output)
            {
                return output;
            }

            return long.Parse(value.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture);
        }

        public bool TryConvert(object value, out long result)
        {
            if (value is long output)
            {
                result = output;
                return true;
            }

            return long.TryParse(value.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out result);
        }
    }
}