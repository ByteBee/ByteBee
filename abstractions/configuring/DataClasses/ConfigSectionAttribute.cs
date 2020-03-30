using System;

namespace ByteBee.Framework.Abstractions.Configuring.DataClasses
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ConfigSectionAttribute : Attribute
    {
        public string Name { get; }

        public ConfigSectionAttribute(string name)
        {
            Name = name;
        }
    }
}