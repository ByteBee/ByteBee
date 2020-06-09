using System;

namespace ByteBee.Framework.Configuring.Abstractions
{
    public interface IConfigStore : IDisposable
    {
        void Initialize(IConfigManager configManager);
        void Save();
        void Load();
    }
}