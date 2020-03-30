using ByteBee.Framework.Abstractions.Converting;

namespace ByteBee.Framework.Converting.Converters
{
    internal sealed class StandardStringConverter : ITypeConverter<string>
    {
        public string GetStandardValue()
        {
            return string.Empty;
        }

        public string Convert(object value)
        {
            return value.ToString();
        }

        public bool TryConvert(object value, out string result)
        {
            result = value.ToString();
            return true;
        }
    }
}