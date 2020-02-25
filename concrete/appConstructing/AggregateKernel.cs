using System;
using ByteBee.Framework.AppConstructing.Contract;
using ByteBee.Framework.Injecting.Contract;

namespace ByteBee.Framework.AppConstructing.Impl
{
    public sealed partial class ConstructApp : IKernelConstructor
    {
        private IBeeKernel _kernel;

        public IBootstrapperConstructor AggregateKernel(IBeeKernel kernel, params IBeeKernelModule[] modules)
        {
            _kernel = kernel ?? throw new ArgumentNullException(nameof(kernel));

            foreach (IBeeKernelModule module in modules)
            {
                module.Load(_kernel);
            }

            return this;
        }

        public IBootstrapperConstructor AggregateKernel<TKernel>(params IBeeKernelModule[] modules) where TKernel : IBeeKernel
        {
            return AggregateKernel<TKernel>(null, modules);
        }

        public IBootstrapperConstructor AggregateKernel<TKernel>(Action<IBeeKernel> kernelCallback,
            params IBeeKernelModule[] modules) where TKernel : IBeeKernel
        {
            _kernel = Activator.CreateInstance<TKernel>();

            foreach (IBeeKernelModule module in modules)
            {
                module.Load(_kernel);
            }

            kernelCallback?.Invoke(_kernel);

            return this;
        }
    }
}