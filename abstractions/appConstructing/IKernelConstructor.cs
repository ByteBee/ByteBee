using System;
using ByteBee.Framework.Injecting.Abstractions;

namespace ByteBee.Framework.AppConstructing.Abstractions
{
    public interface IKernelConstructor
    {
        IBootstrapperConstructor AggregateKernel(IBeeKernel kernel, params IBeeKernelModule[] modules);
        IBootstrapperConstructor AggregateKernel<TKernel>(params IBeeKernelModule[] modules) where TKernel : IBeeKernel;
        IBootstrapperConstructor AggregateKernel<TKernel>(Action<IBeeKernel> kernelCallback, params IBeeKernelModule[] modules) where TKernel : IBeeKernel;
    }
}