using System;
using System.Collections.Generic;

namespace ByteBee.Framework.Converting
{
    public static class ConverterFactory
    {
        public static ITypeConverter<TResult> Create<TResult>()
        {
            var allConverters = new Dictionary<Type, ITypeConverter>
            {
                {typeof(int), new Int32Converter()}
            };

            Type requestedType = typeof(TResult);
            ITypeConverter output;

            if (allConverters.ContainsKey(requestedType))
            {
                output = allConverters[requestedType];
            }
            else
            {
                output = new FallbackConverter();
            }

            return (ITypeConverter<TResult>)output;
        }
    }
}