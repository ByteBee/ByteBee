using ByteBee.Framework.Injecting.Abstractions;

namespace ByteBee.Framework.Tests.Stubbing.CrossCuttingLayer.MadLib
{
    public static class Aggregator
    {
        public static readonly IKernelModule[] Modules = new IKernelModule[]
        {
            new InfrastructureModule(),

            new LogicModule(),
        };
    }
}