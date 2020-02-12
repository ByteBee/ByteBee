namespace ByteBee.Framework.Configuring.Contract
{
    public interface IConfigFactory
    {
        TConfig Get<TConfig>();
    }
}