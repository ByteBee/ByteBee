using System;

namespace ByteBee.Framework.Abstractions.Configuring
{
    public interface IConfigStore : IDisposable
    {
        void Initialize(IConfigManager configManager);
        void Save();
        void Load();
    }
}