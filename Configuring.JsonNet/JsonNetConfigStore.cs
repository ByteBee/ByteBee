using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ByteBee.Framework.Adapting;
using ByteBee.Framework.Adapting.Abstractions;
using ByteBee.Framework.Configuring.Abstractions;
using ByteBee.Framework.Configuring.Abstractions.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ByteBee.Framework.Configuring.JsonNet
{
    public sealed class JsonNetConfigStore : IConfigStore
    {
        private readonly string _pathToConfigFile;
        private ISystemFile _file;

        private IConfigManager _configManager;

        public JsonNetConfigStore(string pathToConfigFile)
        {
            _pathToConfigFile = pathToConfigFile;
            _file = new SystemFileAdapter();
        }

        public void SetFileAdapter(ISystemFile fileAdapter)
        {
            _file = fileAdapter;
        }

        public void Initialize(IConfigManager configManager)
        {
            if (_configManager != null)
            {
                throw new ConfigurationException("config store must depend only on one configuration");
            }

            _configManager = configManager;
        }

        public void Save()
        {
            if (_configManager == null)
            {
                throw new ArgumentNullException(nameof(_configManager));
            }

            string[] sections = _configManager.GetSections().ToArray();

            var body = new JObject();

            for (int i = 0; i < sections.Length; i++)
            {
                string section = sections[i];
                var jsection = new JObject();
                body.Add(section, jsection);

                string[] keys = _configManager.GetKeys(section).ToArray();

                for (int j = 0; j < keys.Length; j++)
                {
                    string key = keys[j];
                    var value = _configManager.Get<object>(section, key);

                    JToken jkey = value == null ? new JRaw("null") : JToken.FromObject(value);

                    jsection.Add(key, jkey);
                }
            }

            string content = body.ToString(Formatting.Indented);

            _file.WriteAllText(_pathToConfigFile, content);
        }

        public void Load()
        {
            bool doesConfigIsMissing = _file.Exists(_pathToConfigFile) == false;
            if (doesConfigIsMissing)
            {
                throw new FileNotFoundException($"Configuration file '{_pathToConfigFile}' does not exists.");
            }

            string fileContent = _file.ReadAllText(_pathToConfigFile);

            bool doesConfigFileHaveAnyContent = string.IsNullOrWhiteSpace(fileContent);
            if (doesConfigFileHaveAnyContent)
            {
                throw new ConfigurationException("The configuration file was entirely empty");
            }

            _configManager.Clear();

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
                        _configManager.Set(section, key, value);
                    }
                }
            }
        }

        public void Dispose()
        {
            _configManager?.Dispose();
        }
    }
}