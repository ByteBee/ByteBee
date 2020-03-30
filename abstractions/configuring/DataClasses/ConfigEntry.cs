namespace ByteBee.Framework.Abstractions.Configuring.DataClasses
{
    public sealed class ConfigEntry
    {
        public string Section { get; }
        public string Key { get; }
        public object Value { get; set; }

        public ConfigEntry(string section, string key, object value)
        {
            Section = section;
            Key = key;
            Value = value;
        }
    }
}