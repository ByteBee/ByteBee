using System;

namespace ByteBee.Framework.Configuring.Contract.DataClasses
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