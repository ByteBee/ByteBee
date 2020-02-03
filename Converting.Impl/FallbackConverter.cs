namespace ByteBee.Framework.Converting
{
    public class FallbackConverter : ITypeConverter<string>
    {
        public object ConvertFrom(object value)
        {
            return value;
        }

        public bool TryConvertFrom(object value, out string result)
        {
            result = value.ToString();
            return true;
        }

        public bool TryConvertFrom(object value, out object result)
        {
            result = value;
            return true;
        }

        string ITypeConverter<string>.ConvertFrom(object value)
        {
            return value.ToString();
        }
    }
}