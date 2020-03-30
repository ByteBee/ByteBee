using ByteBee.Framework.Abstractions.AppConstructing;

namespace ByteBee.Framework.AppConstructing
{
    public static class ConstructApp
    {
        public static IAppConstructor Default => new StandardAppConstructor();
    }
}