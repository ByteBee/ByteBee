using System.Globalization;

namespace ByteBee.Framework.Converting
{
    public sealed class Int32Converter : ITypeConverter<int>
    {
        public int ConvertFrom(object value)
        {
            if (value is int output)
            {
                return output;
            }

            return int.Parse(value.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture);
        }

        public bool TryConvertFrom(object value, out int result)
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