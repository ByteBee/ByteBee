using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ByteBee.Framework.DataTypes.Enums;

namespace ByteBee.Framework.DataTypes
{
    public abstract class BeeEnum<TEnum, TValue> : IEquatable<BeeEnum<TEnum, TValue>> where TEnum : BeeEnum<TEnum, TValue>
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
            TEnum result = GetAll().SingleOrDefault(item => string.Equals(item.Name, name, StringComparison.OrdinalIgnoreCase));
            if (result == null)
            {
                var possibleValues = GetAll().Select(e => e.Name)
                    .Aggregate((a, b) => $"{a}, {b}");

                throw new EnumValueNotFoundException($"The value '{name}' is not a valid entry for {typeof(TEnum).Name}. Possible values are: {possibleValues}");
            }

            return result;
        }

        public static TEnum ByValue(TValue value)
        {
            TEnum result = GetAll().SingleOrDefault(item => EqualityComparer<TValue>.Default.Equals(item.Value, value));
            if (result == null)
            {
                var possibleValues = GetAll().Select(e => e.Value.ToString())
                    .Aggregate((a, b) => $"{a}, {b}");

                throw new EnumValueNotFoundException($"The value '{value}' is not a valid entry for {typeof(TEnum).Name}. Possible values are: {possibleValues}");
            }

            return result;
        }

        public static TEnum ByNameOrValue(string nameOrValue)
        {
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
                var possibleValues = GetAll().Select(e => $"{e.Name} ({e.Value})")
                    .Aggregate((a, b) => $"{a}, {b}");

                throw new EnumValueNotFoundException($"The value '{nameOrValue}' is not a valid entry for {typeof(TEnum).Name}. Possible values are: {possibleValues}");
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

        public bool Equals(BeeEnum<TEnum, TValue> other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(Name, other.Name, StringComparison.InvariantCultureIgnoreCase) && EqualityComparer<TValue>.Default.Equals(Value, other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((BeeEnum<TEnum, TValue>) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(Name) : 0) * 397) ^ EqualityComparer<TValue>.Default.GetHashCode(Value);
            }
        }

        public static bool operator ==(BeeEnum<TEnum, TValue> left, BeeEnum<TEnum, TValue> right)
            => Equals(left, right);

        public static bool operator !=(BeeEnum<TEnum, TValue> left, BeeEnum<TEnum, TValue> right)
            => !Equals(left, right);
    }
}