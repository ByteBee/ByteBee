using System;
using ByteBee.Framework.Converting.Contract;

namespace ByteBee.Framework.Converting.Impl.Converters
{
    internal sealed class StandardUriConverter : ITypeConverter<Uri>
    {
        public Uri GetStandardValue()
        {
            return new Uri("");
        }

        public Uri Convert(object value)
        {
            throw new NotImplementedException();
        }

        public bool TryConvert(object value, out Uri result)
        {
            throw new NotImplementedException();
        }
    }
}