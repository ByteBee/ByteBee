using System.Globalization;
using ByteBee.Framework.Converting.Abstractions;

namespace ByteBee.Framework.Converting.Converters
{
    internal sealed class StandardDoubleConverter : ITypeConverter<double>
    {
        public double GetStandardValue()
        {
            return 0D;
        }

        public double Convert(object value)
        {
            if (value is double output)
            {
                return output;
            }

            return double.Parse(value.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture);
        }

        public bool TryConvert(object value, out double result)
        {
            if (value is double output)
            {
                result = output;
                return true;
            }

            return double.TryParse(value.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out result);
        }
    }
}