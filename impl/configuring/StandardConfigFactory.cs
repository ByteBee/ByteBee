using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ByteBee.Framework.Configuring.Contract;
using ByteBee.Framework.Configuring.Contract.DataClasses;

namespace ByteBee.Framework.Configuring.Impl
{
    public sealed class StandardConfigFactory : IConfigFactory
    {
        private readonly IConfigSource _source;

        public StandardConfigFactory(IConfigSource source)
        {
            _source = source;
        }

        public TConfig Get<TConfig>()
        {
            Type typeObject = typeof(TConfig);
            Type sourceType = typeof(IConfigSource);

            var config = Activator.CreateInstance<TConfig>();

            ConfigSectionAttribute sectionAttribute = typeObject
                .GetCustomAttributes(true)
                .OfType<ConfigSectionAttribute>()
                .FirstOrDefault();

            //IEnumerable<PropertyInfo> properties = typeObject.GetProperties()
            //    .Where(p => p.GetCustomAttributes(true).Any(a => a is ConfigKeyAttribute));

            MethodInfo getMethod = sourceType.GetMethod("GetOrDefault");

            if (getMethod == null)
            {
                throw new MissingMethodException("IConfigSource", "GetOrDefault");
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