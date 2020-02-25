using System;
using ByteBee.Framework.Configuring.Abstractions;

namespace ByteBee.Framework.Configuring
{
    public class IniConfigStore : IConfigStore
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

        public void Save(IConfigManager source)
        {
            throw new NotImplementedException();
        }

        public void Load(IConfigManager source)
        {
            throw new NotImplementedException();
        }
    }
}