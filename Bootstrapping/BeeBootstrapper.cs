using System.Collections.Generic;
using ByteBee.Framework.Bootstrapping.Abstractions;

namespace ByteBee.Framework.Bootstrapping
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class BeeBootstrapper : IBootstrapper
    {
        private readonly List<IComponentActivator> _lifecycles;

        public BeeBootstrapper(List<IComponentActivator> lifecycles)
        {
            _lifecycles = lifecycles;
        }

        public void ActivateAll()
        {
            _lifecycles.ForEach(b => b.Activate());
        }

        public void DeactivateAll()
        {
            _lifecycles.ForEach(b => b.Deactivate());
        }

        public void Dispose()
        {
            _lifecycles.Clear();
        }
    }
}