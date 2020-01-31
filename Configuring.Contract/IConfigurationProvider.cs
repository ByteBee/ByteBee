using System;

namespace ByteBee.Framework.Configuring.Contract
{
    public interface IConfigurationProvider
    {
        object Get(Type type);
        TConfig Get<TConfig>();
    }
}