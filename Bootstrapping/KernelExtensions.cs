using System;
using ByteBee.Framework.Abstractions.Bootstrapping;
using ByteBee.Framework.Abstractions.Configuring;
using ByteBee.Framework.Abstractions.Injecting;

namespace ByteBee.Framework.Bootstrapping
{
    public static class KernelExtensions
    {
        public static void RegisterComponent<TComponent>(this IBeeKernel kernel) where TComponent : IComponentActivator
        {
            Type abstractionType = typeof(IComponentActivator);
            Type concreteType = typeof(TComponent);
            kernel.Register(abstractionType, concreteType);
        }

        public static void RegisterConfig<TConfig>(this IBeeKernel kernel)
        {
            kernel.RegisterToMethod(ctx =>
            {
                var configProvider = ctx.Resolve<IConfigProvider>();
                return configProvider.Get<TConfig>();
            });
        }
    }
}