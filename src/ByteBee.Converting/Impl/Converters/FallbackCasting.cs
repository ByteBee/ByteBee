using ByteBee.Converting.Contract;

namespace ByteBee.Converting.Impl.Converters
{
    public class FallbackCasting : ITypeConverter<string>
    {
        public string GetStandardValue()
        {
            throw new System.NotImplementedException();
        }

        public string Convert(object value)
        {
            throw new System.NotImplementedException();
        }

        public bool TryConvert(object value, out string result)
        {
            throw new System.NotImplementedException();
        }
    }
}