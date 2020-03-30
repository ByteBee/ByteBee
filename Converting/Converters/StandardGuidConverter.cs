using System;
using ByteBee.Framework.Abstractions.Converting;

namespace ByteBee.Framework.Converting.Converters
{
    internal sealed class StandardGuidConverter : ITypeConverter<Guid>
    {
        public Guid GetStandardValue()
        {
            return new Guid();
        }

        public Guid Convert(object value)
        {
            if (value is Guid output)
            {
                return output;
            }

            return Guid.Parse(value.ToString());
        }

        public bool TryConvert(object value, out Guid result)
        {
            if (value is Guid output)
            {
                result = output;
                return true;
            }

            return Guid.TryParse(value.ToString(), out result);
        }
    }
}