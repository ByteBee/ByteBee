using System;
using ByteBee.Framework.Adapting.Contract;
using ByteBee.Framework.Adapting.Impl;
using ByteBee.Framework.Configuring.Contract;

namespace ByteBee.Framework.Configuring.Impl.Ini
{
    public class IniConfigurationStore : IConfigurationStore
    {
        private readonly string _pathToConfigFile;
        private ISystemFile _file;

        public IniConfigurationStore(string pathToConfigFile)
        {
            _pathToConfigFile = pathToConfigFile;
            _file = new SystemFileAdapter();
        }

        public void SetFileAdapter(ISystemFile fileAdapter)
        {
            _file = fileAdapter;
        }

        public void Save(IConfigurationSource source)
        {
            throw new NotImplementedException();
        }

        public IConfigurationSource Load()
        {
            throw new NotImplementedException();
        }
    }
}