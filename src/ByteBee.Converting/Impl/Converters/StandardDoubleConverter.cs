using ByteBee.Converting.Contract;

namespace ByteBee.Converting.Impl.Converters
{
    internal sealed class StandardDoubleConverter : ITypeConverter<double>
    {
        public double GetStandardValue()
        {
            return 0D;
        }

        public double Convert(object value)
        {
            throw new System.NotImplementedException();
        }

        public bool TryConvert(object value, out double result)
        {
            throw new System.NotImplementedException();
        }
    }
}