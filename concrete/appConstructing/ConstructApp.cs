using ByteBee.Framework.AppConstructing.Abstractions;

namespace ByteBee.Framework.AppConstructing
{
    public static class ConstructApp
    {
        public static IAppConstructor Default => new StandardAppConstructor();
    }
}