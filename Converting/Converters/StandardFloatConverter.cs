using System.Globalization;
using ByteBee.Framework.Converting.Abstractions;

namespace ByteBee.Framework.Converting.Converters
{
    internal sealed class StandardFloatConverter : ITypeConverter<float>
    {
        public float GetStandardValue()
        {
            return 0F;
        }

        public float Convert(object value)
        {
            if (value is float output)
            {
                return output;
            }

            return float.Parse(value.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture);
        }

        public bool TryConvert(object value, out float result)
        {
            if (value is float output)
            {
                result = output;
                return true;
            }

            return float.TryParse(value.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out result);
        }
    }
}