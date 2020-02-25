namespace ByteBee.Framework.Configuring.Contract
{
    public interface IConfigObjectProvider
    {
        TConfig Get<TConfig>();
    }
}