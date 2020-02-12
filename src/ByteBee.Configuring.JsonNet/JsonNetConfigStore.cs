using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ByteBee.Framework.Adapting.Contract;
using ByteBee.Framework.Adapting.Impl;
using ByteBee.Framework.Configuring.Contract;
using ByteBee.Framework.Configuring.Contract.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ByteBee.Framework.Configuring.Impl.JsonNet
{
    public sealed class JsonNetConfigStore : IConfigStore
    {
        private readonly string _pathToConfigFile;
        private ISystemFile _file;

        public JsonNetConfigStore(string pathToConfigFile)
        {
            _pathToConfigFile = pathToConfigFile;
            _file = new SystemFileAdapter();
        }

        public void SetFileAdapter(ISystemFile fileAdapter)
        {
            _file = fileAdapter;
        }

        public void Save(IConfigSource source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            string[] sections = source.GetSections().ToArray();

            var body = new JObject();

            for (int i = 0; i < sections.Length; i++)
            {
                string section = sections[i];
                var jsection = new JObject();
                body.Add(section, jsection);

                string[] keys = source.GetKeys(section).ToArray();

                for (int j = 0; j < keys.Length; j++)
                {
                    string key = keys[j];
                    var value = source.Get<object>(section, key);

                    JToken jkey = value == null ? new JRaw("null") : JToken.FromObject(value);

                    jsection.Add(key, jkey);
                }
            }

            string content = body.ToString(Formatting.Indented);

            _file.WriteAllText(_pathToConfigFile, content);
        }

        public IConfigSource Load()
        {
            if (_file.Exists(_pathToConfigFile) == false)
            {
                throw new FileNotFoundException($"Configuration file '{_pathToConfigFile}' does not exists.");
            }

            string fileContent = _file.ReadAllText(_pathToConfigFile);

            if (string.IsNullOrWhiteSpace(fileContent))
            {
                throw new ConfiguringException("The configuration file was entirely empty");
            }

            IConfigSource source = new StandardConfigSource();

            JObject json = JObject.Parse(fileContent);

            foreach (KeyValuePair<string, JToken> currentSection in json)
            {
                string section = currentSection.Key;

                foreach (JToken currentKey in currentSection.Value)
                {
                    if (currentKey is JProperty prop)
                    {
                        string key = prop.Name;
                        string value = prop.Value.ToString();
                        source.Set(section, key, value);
                    }
                }
            }

            return source;
        }
    }
}