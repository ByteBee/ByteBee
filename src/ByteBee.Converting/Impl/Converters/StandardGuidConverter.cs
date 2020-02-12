using System;
using ByteBee.Converting.Contract;

namespace ByteBee.Converting.Impl.Converters
{
    internal sealed class StandardGuidConverter : ITypeConverter<Guid>
    {
        public Guid GetStandardValue()
        {
            return new Guid();
        }

        public Guid Convert(object value)
        {
            throw new NotImplementedException();
        }

        public bool TryConvert(object value, out Guid result)
        {
            throw new NotImplementedException();
        }
    }
}