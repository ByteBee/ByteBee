using System;
using ByteBee.Framework.Injecting.Contract;

namespace ByteBee.Framework.AppConstructing.Contract
{
    public interface IKernelConstructor
    {
        IBootstrapperConstructor AggregateKernel<TKernel>(params IBeeKernelModule[] modules) where TKernel : IBeeKernel;
        IBootstrapperConstructor AggregateKernel<TKernel>(Action<IBeeKernel> kernelCallback, params IBeeKernelModule[] modules) where TKernel : IBeeKernel;
    }
}