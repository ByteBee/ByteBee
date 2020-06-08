using System;
using System.Collections.Generic;

namespace ByteBee.Framework.Abstractions.Configuring
{
    public interface IConfigManager : IDisposable
    {
        IConfigStore Store { get; }
        IEnumerable<string> GetSections();
        IEnumerable<string> GetKeys(string section);

        bool TryGet<TResult>(string section, string key, out TResult value);
        TResult Get<TResult>(string section, string key);
        TResult GetOrDefault<TResult>(string section, string key);
        TResult GetOrFallback<TResult>(string section, string key, TResult fallback);
        TResult GetOrFallback<TResult>(string section, string key, Func<TResult> fallback);
        void Set(string section, string key, object value);

        void Clear();
    }
}