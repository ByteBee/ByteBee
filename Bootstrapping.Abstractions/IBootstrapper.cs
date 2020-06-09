using System;

namespace ByteBee.Framework.Bootstrapping.Abstractions
{
    public interface IBootstrapper : IDisposable
    {
        void ActivateAll();
        void DeactivateAll();
    }
}