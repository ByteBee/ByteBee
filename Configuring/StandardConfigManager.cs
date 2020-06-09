using System;
using System.Collections.Generic;
using System.Linq;
using ByteBee.Framework.Configuring.Abstractions;
using ByteBee.Framework.Configuring.Abstractions.DataClasses;
using ByteBee.Framework.Configuring.Abstractions.Exceptions;
using ByteBee.Framework.Converting;
using ByteBee.Framework.Converting.Abstractions;

namespace ByteBee.Framework.Configuring
{
    public sealed class StandardConfigManager : IConfigManager
    {
        public int NumberOfEntries => _entries.Count;

        private readonly IList<ConfigEntry> _entries = new List<ConfigEntry>();
        private IConverterFactory _converterFactory;

        public IConfigStore Store { get; }

        public StandardConfigManager(IConfigStore configStore)
        {
            Store = configStore;
            Store.Initialize(this);

            _converterFactory = new StandardConverterFactory();
        }

        public void SetConverterFactory(IConverterFactory castingFactory)
        {
            _converterFactory = castingFactory;
        }

        public IEnumerable<string> GetSections()
        {
            return _entries.Select(e => e.Section).Distinct();
        }

        public IEnumerable<string> GetKeys(string section)
        {
            return _entries.Where(e => e.Section == section)
                .Select(e => e.Key).Distinct();
        }

        public bool TryGet<TResult>(string section, string key, out TResult value)
        {
            ValidateSectionArg(section);
            ValidateKeyArg(key);

            bool isEntryDefined = _entries.Any(e => FindEntry(e, section, key));

            if (isEntryDefined)
            {
                ConfigEntry entry = _entries.Single(e => FindEntry(e, section, key));

                ITypeConverter<TResult> converter = _converterFactory.Create<TResult>();

                value = converter.Convert(entry.Value);
            }
            else
            {
                value = default(TResult);
            }

            return isEntryDefined;
        }

        public TResult Get<TResult>(string section, string key)
        {
            bool isEntryDefined = TryGet(section, key, out TResult obj);

            if (isEntryDefined == false)
            {
                throw new SectionOrKeyNotFoundException(section, key);
            }

            return obj;
        }

        public TResult GetOrDefault<TResult>(string section, string key)
        {
            return GetOrFallback(section, key, () => default(TResult));
        }

        public TResult GetOrFallback<TResult>(string section, string key, TResult fallback)
        {
            return GetOrFallback(section, key, () => fallback);
        }

        public TResult GetOrFallback<TResult>(string section, string key, Func<TResult> fallback)
        {
            bool isEntryDefined = TryGet(section, key, out TResult obj);

            if (isEntryDefined == false)
            {
                return fallback();
            }

            return obj;
        }

        public void Set(string section, string key, object value)
        {
            ValidateSectionArg(section);
            ValidateKeyArg(key);

            bool isEntryDefined = _entries.Any(e => FindEntry(e, section, key));
            if (isEntryDefined)
            {
                ConfigEntry entry = _entries.Single(e => FindEntry(e, section, key));
                entry.Value = value;
            }
            else
            {
                var entry = new ConfigEntry(section, key, value);

                _entries.Add(entry);
            }
        }

        public void Clear()
        {
            _entries.Clear();
        }

        private bool FindEntry(ConfigEntry entry, string section, string key)
        {
            return entry.Section == section && entry.Key == key;
        }

        private void ValidateSectionArg(string section)
        {
            if (section == null)
            {
                throw new ArgumentNullException(nameof(section));
            }

            if (string.IsNullOrWhiteSpace(section))
            {
                throw new ArgumentException(nameof(section));
            }
        }

        private void ValidateKeyArg(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException(nameof(key));
            }
        }

        public void Dispose()
        {
            Clear();
        }
    }
}