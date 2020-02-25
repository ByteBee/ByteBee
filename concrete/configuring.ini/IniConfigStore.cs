using System;
using ByteBee.Framework.Adapting.Contract;
using ByteBee.Framework.Adapting.Impl;
using ByteBee.Framework.Configuring.Contract;

namespace ByteBee.Framework.Configuring.Impl.Ini
{
    public class IniConfigStore : IConfigStore
    {
        private readonly string _pathToConfigFile;
        private ISystemFile _file;

        public IniConfigStore(string pathToConfigFile)
        {
            _pathToConfigFile = pathToConfigFile;
            _file = new SystemFileAdapter();
        }

        public void SetFileAdapter(ISystemFile fileAdapter)
        {
            _file = fileAdapter;
        }

        public void Save(IConfiguration source)
        {
            throw new NotImplementedException();
        }

        public void Load(IConfiguration source)
        {
            throw new NotImplementedException();
        }
    }
}