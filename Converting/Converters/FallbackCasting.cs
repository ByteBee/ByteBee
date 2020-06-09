using ByteBee.Framework.Converting.Abstractions;

namespace ByteBee.Framework.Converting.Converters
{
    internal sealed class FallbackCasting : ITypeConverter<object>
    {
        public object GetStandardValue()
        {
            return null;
        }

        public object Convert(object value)
        {
            return value;
        }

        public bool TryConvert(object value, out object result)
        {
            result = value;
            return true;
        }
    }
}