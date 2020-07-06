using System.Collections.Generic;
using ByteBee.Framework.Bootstrapping.Abstractions;

namespace ByteBee.Framework.Bootstrapping
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class StandardBootstrapper : IBootstrapper
    {
        private readonly List<IComponentActivator> _activators;

        public StandardBootstrapper(List<IComponentActivator> activators)
        {
            _activators = activators;
        }

        public void ActivateAll()
        {
            _activators.ForEach(b => b.Activate());
        }

        public void DeactivateAll()
        {
            _activators.ForEach(b => b.Deactivate());
        }

        public void Dispose()
        {
            _activators.Clear();
        }
    }
}