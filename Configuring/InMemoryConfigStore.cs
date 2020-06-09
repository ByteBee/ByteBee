using ByteBee.Framework.Configuring.Abstractions;

namespace ByteBee.Framework.Configuring
{
    public sealed class InMemoryConfigStore : IConfigStore
    {
        private IConfigManager _source;
        
        public void Initialize(IConfigManager configManager)
        {
            _source = configManager;
        }

        public void Save()
        {
        }

        public void Load()
        {
        }

        public void Dispose()
        {
            _source?.Dispose();
        }
    }
}