using System;
using ByteBee.Framework.Abstractions.Converting;

namespace ByteBee.Framework.Converting.Converters
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

            if (TryConvert(value, out bool output))
            {
                return output;
            }

            throw new InvalidCastException();
        }

        public bool TryConvert(object value, out bool result)
        {
            if (value == null)
            {
                result = false;
                return false;
            }

            if (value is bool output)
            {
                result = output;
                return true;
            }

            if (value is string)
            {
                value = value.ToString().ToLowerInvariant();
            }

            switch (value)
            {
                case 1:
                case "true":
                case "yes":
                case "yep":
                case "ja":
                    result = true;
                    return true;

                case 0:
                case "false":
                case "no":
                case "nope":
                case "nein":
                    result = false;
                    return true;
            }

            return bool.TryParse(value.ToString(), out result);
        }
    }
}