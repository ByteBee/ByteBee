using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ByteBee.Framework.DataTypes.Enums;

namespace ByteBee.Framework.DataTypes
{
    public abstract class BeeEnum<TEnum, TValue> where TEnum : BeeEnum<TEnum, TValue>
    {
        private static readonly Lazy<TEnum[]> _allMembersLazy = new Lazy<TEnum[]>(() =>
        {
            Type t = typeof(TEnum);
            const BindingFlags PublicStatic = BindingFlags.Public | BindingFlags.Static;

            IEnumerable<TEnum> ofProp = t.GetProperties(PublicStatic)
                .Where(p => t.IsAssignableFrom(p.PropertyType))
                .Select(i => (TEnum)i.GetValue(null));

            IEnumerable<TEnum> ofField = t.GetFields(PublicStatic)
                .Where(f => t.IsAssignableFrom(f.FieldType))
                .Select(i => (TEnum)i.GetValue(null));

            return ofProp.Union(ofField).OrderBy(e => e.Value).ToArray();
        });

        public static TEnum[] GetAll()
        {
            return _allMembersLazy.Value;
        }

        public string Name { get; }
        public TValue Value { get; }

        protected BeeEnum(TValue value, string name)
        {
            Name = name;
            Value = value;
        }

        public static TEnum ByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(nameof(name));
            }

            TEnum result = GetAll().SingleOrDefault(item => string.Equals(item.Name, name, StringComparison.OrdinalIgnoreCase));
            if (result == null)
            {
                throw new EnumValueNotFoundException($"No {typeof(TEnum).Name} with name \"{name}\" found.");
            }

            return result;
        }

        public static TEnum ByValue(TValue value)
        {
            TEnum result = GetAll().SingleOrDefault(item => EqualityComparer<TValue>.Default.Equals(item.Value, value));
            if (result == null)
            {
                throw new EnumValueNotFoundException($"No {typeof(TEnum).Name} with value {value} found.");
            }

            return result;
        }

        public static TEnum ByNameOrValue(string nameOrValue)
        {
            if (string.IsNullOrWhiteSpace(nameOrValue))
            {
                throw new ArgumentException(nameOrValue);
            }

            TEnum[] values = GetAll();

            TEnum output = values.SingleOrDefault(item =>
            {
                bool foundByName = string.Equals(item.Name, nameOrValue, StringComparison.OrdinalIgnoreCase);
                bool foundByValue = string.Equals(item.Value.ToString(), nameOrValue, StringComparison.OrdinalIgnoreCase);
                bool doesElementMatch = foundByName || foundByValue;

                return doesElementMatch;
            });

            if (output == null)
            {
                throw new EnumValueNotFoundException($"No {typeof(TEnum).Name} with name or value {nameOrValue} found.");
            }

            return output;
        }

        public static TEnum ByValue(TValue value, TEnum defaultValue)
        {
            TEnum result = GetAll().SingleOrDefault(item => EqualityComparer<TValue>.Default.Equals(item.Value, value)) ??
                           defaultValue;
            return result;
        }

        public override string ToString()
        {
            return $"{Name} ({Value})";
        }

        public static implicit operator TValue(BeeEnum<TEnum, TValue> @enum)
        {
            return @enum.Value;
        }

        public static explicit operator BeeEnum<TEnum, TValue>(TValue value)
        {
            return ByValue(value);
        }
    }
}