using ByteBee.Converting.Contract;

namespace ByteBee.Converting.Impl.Converters
{
    internal sealed class StandardLongConverter : ITypeConverter<long>
    {
        public long GetStandardValue()
        {
            return 0L;
        }

        public long Convert(object value)
        {
            throw new System.NotImplementedException();
        }

        public bool TryConvert(object value, out long result)
        {
            throw new System.NotImplementedException();
        }
    }
}