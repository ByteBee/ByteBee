using System;
using System.Collections.Generic;
using ByteBee.Framework.Abstractions.AppConstructing;
using ByteBee.Framework.Abstractions.Injecting;

namespace ByteBee.Framework.AppConstructing
{
    public sealed partial class StandardAppConstructor
    {
        private IBeeKernel _kernel;

        public IAppConstructor AggregateKernel(IBeeKernel kernel)
        {
            _kernel = kernel ?? throw new ArgumentNullException(nameof(kernel));
            
            return this;
        }

        public IAppConstructor AggregateKernel(IBeeKernel kernel, IEnumerable<IBeeKernelModule> modules)
        {
            _kernel = kernel ?? throw new ArgumentNullException(nameof(kernel));

            foreach (IBeeKernelModule module in modules)
            {
                module.Load(_kernel);
            }

            return this;
        }

        public IAppConstructor AggregateKernel<TKernel>(IEnumerable<IBeeKernelModule> modules) where TKernel : IBeeKernel
        {
            return AggregateKernel<TKernel>(modules, null);
        }

        public IAppConstructor AggregateKernel<TKernel>(Action<IBeeKernel> kernelCallback) where TKernel : IBeeKernel
        {
            _kernel = Activator.CreateInstance<TKernel>();
            
            kernelCallback?.Invoke(_kernel);

            return this;
        }

        public IAppConstructor AggregateKernel<TKernel>(IEnumerable<IBeeKernelModule> modules, Action<IBeeKernel> kernelCallback) where TKernel : IBeeKernel
        {
            _kernel = Activator.CreateInstance<TKernel>();

            foreach (IBeeKernelModule module in modules)
            {
                module.Load(_kernel);
            }

            kernelCallback?.Invoke(_kernel);

            return this;
        }

        private void DisposeKernel()
        {
            _kernel.Dispose();
        }
    }
}