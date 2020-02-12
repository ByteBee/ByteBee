using System;
using System.Collections.Generic;
using ByteBee.Framework.Converting.Contract;
using ByteBee.Framework.Converting.Impl.Converters;

namespace ByteBee.Framework.Converting.Impl
{
    public sealed class StandardConverterFactory : IConverterFactory
    {
        private readonly Dictionary<Type, object> _customConverter = new Dictionary<Type, object>();

        public void RegisterCustomConverter<TResult>(ITypeConverter<TResult> customConverter)
        {
            _customConverter.Add(typeof(TResult), customConverter);
        }

        public ITypeConverter<TResult> Create<TResult>()
        {
            Type requestedType = typeof(TResult);

            if (_customConverter.ContainsKey(requestedType))
            {
                return _customConverter[requestedType] as ITypeConverter<TResult>;
            }

            switch (requestedType.Name)
            {
                case nameof(Int32): return new StandardIntegerConverter() as ITypeConverter<TResult>;
                case nameof(Boolean): return new StandardBooleanConverter() as ITypeConverter<TResult>;
                case nameof(Double): return new StandardDoubleConverter() as ITypeConverter<TResult>;
                case nameof(String): return new StandardStringConverter() as ITypeConverter<TResult>;
                case nameof(DateTime): return new StandardDateTimeConverter() as ITypeConverter<TResult>;
                case nameof(Decimal): return new StandardDecimalConverter() as ITypeConverter<TResult>;
                case nameof(Single): return new StandardFloatConverter() as ITypeConverter<TResult>;
                case nameof(Guid): return new StandardGuidConverter() as ITypeConverter<TResult>;
                case nameof(Int16): return new StandardShortConverter() as ITypeConverter<TResult>;
                case nameof(Int64): return new StandardLongConverter() as ITypeConverter<TResult>;
                case nameof(Uri): return new StandardUriConverter() as ITypeConverter<TResult>;
                default: return new FallbackCasting() as ITypeConverter<TResult>;
            }
        }
    }
}