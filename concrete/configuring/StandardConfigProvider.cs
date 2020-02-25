using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ByteBee.Framework.Configuring.Abstractions;
using ByteBee.Framework.Configuring.Abstractions.DataClasses;

namespace ByteBee.Framework.Configuring
{
    public sealed class StandardConfigProvider : IConfigProvider
    {
        private readonly IConfigManager _source;

        public StandardConfigProvider(IConfigManager source)
        {
            _source = source;
        }

        public TConfig Get<TConfig>()
        {
            Type typeObject = typeof(TConfig);
            Type sourceType = typeof(IConfigManager);

            var config = Activator.CreateInstance<TConfig>();

            ConfigSectionAttribute sectionAttribute = typeObject
                .GetCustomAttributes(true)
                .OfType<ConfigSectionAttribute>()
                .FirstOrDefault();

            MethodInfo getMethod = sourceType.GetMethod("GetOrDefault");

            if (getMethod == null)
            {
                throw new MissingMethodException("IConfigManager", "GetOrDefault");
            }

            IEnumerable<PropertyInfo> properties = typeObject.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                ConfigKeyAttribute keyAttribute = property.GetCustomAttributes(true)
                    .OfType<ConfigKeyAttribute>().FirstOrDefault();

                string section = sectionAttribute?.Name ?? typeObject.Name;
                string key = keyAttribute?.Name ?? property.Name;

                Type propType = property.PropertyType;

                MethodInfo generic = getMethod.MakeGenericMethod(propType);
                object value = generic.Invoke(_source, new object[] {section, key});

                property.SetValue(config, value);
            }

            return config;
        }
    }
}