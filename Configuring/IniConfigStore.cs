using System;
using ByteBee.Framework.Abstractions.Configuring;

namespace ByteBee.Framework.Configuring
{
    internal class IniConfigStore : IConfigStore
    {
        private readonly string _pathToConfigFile;
        //private ISystemFile _file;

        public IniConfigStore(string pathToConfigFile)
        {
            _pathToConfigFile = pathToConfigFile;
            //_file = new SystemFileAdapter();
        }

        //public void SetFileAdapter(ISystemFile fileAdapter)
        //{
        //    _file = fileAdapter;
        //}

        public void Initialize(IConfigManager configManager)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Load()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }
    }
}