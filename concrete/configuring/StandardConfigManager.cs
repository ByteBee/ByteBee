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
        private readonly IConfigStore _configStore;
        public int NumberOfEntries => _store.Count;

        private readonly IList<ConfigEntry> _store = new List<ConfigEntry>();
        private IConverterFactory _converterFactory;

        public StandardConfigManager(IConfigStore configStore)
        {
            _configStore = configStore;
            _converterFactory = new StandardConverterFactory();
        }

        public void SetConverterFactory(IConverterFactory castingFactory)
        {
            _converterFactory = castingFactory;
        }

        public IEnumerable<string> GetSections()
        {
            return _store.Select(e => e.Section).Distinct();
        }

        public IEnumerable<string> GetKeys(string section)
        {
            return _store.Where(e => e.Section == section)
                .Select(e => e.Key).Distinct();
        }

        public bool TryGet<TResult>(string section, string key, out TResult value)
        {
            ValidateSectionArg(section);
            ValidateKeyArg(key);

            bool isEntryDefined = _store.Any(e => FindEntry(e, section, key));

            if (isEntryDefined)
            {
                ConfigEntry entry = _store.Single(e => FindEntry(e, section, key));

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
            bool isEntryDefined = TryGet(section, key, out TResult obj);

            if (isEntryDefined == false)
            {
                return default(TResult);
            }

            return obj;
        }

        public void Set(string section, string key, object value)
        {
            ValidateSectionArg(section);
            ValidateKeyArg(key);

            bool isEntryDefined = _store.Any(e => FindEntry(e, section, key));
            if (isEntryDefined)
            {
                ConfigEntry entry = _store.Single(e => FindEntry(e, section, key));
                entry.Value = value;
            }
            else
            {
                var entry = new ConfigEntry(section, key, value);

                _store.Add(entry);
            }
        }

        public void Clear()
        {
            _store.Clear();
        }

        public void LoadFromStore()
        {
            _configStore.Load(this);
        }

        public void SaveToStore()
        {
            _configStore.Save(this);
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
    }
}