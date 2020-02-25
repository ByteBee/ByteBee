namespace ByteBee.Framework.Configuring.Abstractions
{
    public interface IConfigProvider
    {
        TConfig Get<TConfig>();
    }
}