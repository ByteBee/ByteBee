using System;

namespace ByteBee.Framework.Configuring.Contract.DataClasses
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class ConfigKeyAttribute : Attribute
    {
        public string Name { get; private set; }
        public bool IgnoreNull { get; set; }

        public ConfigKeyAttribute(string name)
        {
            Name = name;
        }
    }
}