using ByteBee.Converting.Contract;

namespace ByteBee.Converting.Impl.Converters
{
    internal sealed class StandardDecimalConverter : ITypeConverter<decimal>
    {
        public decimal GetStandardValue()
        {
            return 0M;
        }

        public decimal Convert(object value)
        {
            throw new System.NotImplementedException();
        }

        public bool TryConvert(object value, out decimal result)
        {
            throw new System.NotImplementedException();
        }
    }
}