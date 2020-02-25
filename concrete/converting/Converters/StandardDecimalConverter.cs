using System.Globalization;
using ByteBee.Framework.Converting.Contract;

namespace ByteBee.Framework.Converting.Impl.Converters
{
    internal sealed class StandardDecimalConverter : ITypeConverter<decimal>
    {
        public decimal GetStandardValue()
        {
            return 0M;
        }

        public decimal Convert(object value)
        {
            if (value is decimal output)
            {
                return output;
            }

            return decimal.Parse(value.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture);
        }

        public bool TryConvert(object value, out decimal result)
        {
            if (value is decimal output)
            {
                result = output;
                return true;
            }

            return decimal.TryParse(value.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out result);
        }
    }
}