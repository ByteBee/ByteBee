using System;
using ByteBee.Converting.Contract;

namespace ByteBee.Converting.Impl.Converters
{
    internal sealed class StandardBooleanConverter : ITypeConverter<bool>
    {
        public bool GetStandardValue()
        {
            return false;
        }

        public bool Convert(object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }

            switch (value)
            {
                case "true":
                    return true;
                case "false":
                    return false;
                default:
                    if (bool.TryParse(value.ToString(), out bool output))
                    {
                        return output;
                    }

                    throw new InvalidCastException();
                    //return (bool)_booleanConverter.ConvertFrom(value);
            }
        }

        public bool TryConvert(object value, out bool result)
        {
            throw new System.NotImplementedException();
        }
    }
}