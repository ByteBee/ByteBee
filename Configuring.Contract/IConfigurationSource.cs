﻿using System.Collections.Generic;

namespace ByteBee.Framework.Configuring.Contract
{
    public interface IConfigurationSource
    {
        IEnumerable<string> GetSections();
        IEnumerable<string> GetKeys(string section);

        bool TryGet<TResult>(string section, string key, out TResult value);
        TResult Get<TResult>(string section, string key);
        void Set(string section, string key, object value);

        void Clear();
    }
}