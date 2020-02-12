using ByteBee.Converting.Contract;

namespace ByteBee.Converting.Impl.Converters
{
    internal sealed class StandardShortConverter : ITypeConverter<short>
    {
        public short GetStandardValue()
        {
            return 0;
        }

        public short Convert(object value)
        {
            throw new System.NotImplementedException();
        }

        public bool TryConvert(object value, out short result)
        {
            throw new System.NotImplementedException();
        }
    }
}