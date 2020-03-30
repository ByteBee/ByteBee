namespace ByteBee.Framework.Abstractions.Configuring
{
    public interface IConfigProvider
    {
        TConfig Get<TConfig>();
    }
}