using System;

namespace ByteBee.Framework.Abstractions.Configuring.DataClasses
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class ConfigKeyAttribute : Attribute
    {
        public string Name { get; }
        public bool IgnoreNull { get; set; }

        public ConfigKeyAttribute(string name)
        {
            Name = name;
        }
    }
}