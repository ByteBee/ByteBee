using System;

namespace ByteBee.Framework.Configuring.Abstractions.DataClasses
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