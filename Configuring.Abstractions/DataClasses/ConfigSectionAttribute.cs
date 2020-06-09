using System;

namespace ByteBee.Framework.Configuring.Abstractions.DataClasses
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