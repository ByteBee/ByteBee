using System;
using ByteBee.Framework.Configuring.Contract;

namespace ByteBee.Framework.Configuring.Implementation
{
    public class StandardConfigurationProvider : IConfigurationProvider
    {
        public object Get(Type type)
        {
            throw new NotImplementedException();
        }

        public TConfig Get<TConfig>()
        {
            throw new NotImplementedException();
        }
    }
}