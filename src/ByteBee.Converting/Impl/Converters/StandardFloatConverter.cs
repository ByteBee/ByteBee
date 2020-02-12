using ByteBee.Converting.Contract;

namespace ByteBee.Converting.Impl.Converters
{
    internal sealed class StandardFloatConverter : ITypeConverter<float>
    {
        public float GetStandardValue()
        {
            return 0F;
        }

        public float Convert(object value)
        {
            throw new System.NotImplementedException();
        }

        public bool TryConvert(object value, out float result)
        {
            throw new System.NotImplementedException();
        }
    }
}