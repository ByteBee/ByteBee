namespace ByteBee.Framework.Configuring.Abstractions
{
    public interface IConfigObjectProvider
    {
        TConfig Get<TConfig>();
    }
}