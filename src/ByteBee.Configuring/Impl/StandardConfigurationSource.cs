using System;
using System.Collections.Generic;
using System.Linq;
using ByteBee.Framework.Configuring.Contract;
using ByteBee.Framework.Configuring.Contract.DataClasses;
using ByteBee.Framework.Configuring.Contract.Exceptions;
using ByteBee.Framework.Converting.Contract;
using ByteBee.Framework.Converting.Impl;

namespace ByteBee.Framework.Configuring.Impl
{
    public sealed class StandardConfigurationSource : IConfigurationSource
    {
        public int NumberOfEntries => _store.Count;

        private readonly IList<ConfigEntry> _store = new List<ConfigEntry>();
        private IConverterFactory _converterFactory;

        public StandardConfigurationSource()
        {
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
                value = default;
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