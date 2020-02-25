using ByteBee.Framework.Configuring.Abstractions;

namespace ByteBee.Framework.Configuring
{
    public class InMemoryConfigStore : IConfigStore
    {
        private IConfigManager _source;

        public void Save(IConfigManager source)
        {
            _source = source;
        }

        public void Load(IConfigManager source)
        {
            source.Clear();

            foreach (string section in _source.GetSections())
            {
                foreach (string key in _source.GetKeys(section))
                {
                    var value = _source.Get<object>(section,key);
                    source.Set(section, key, value);
                }
            }
        }
    }
}