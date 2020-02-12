namespace ByteBee.Framework.Configuring.Contract
{
    public interface IConfigStore
    {
        void Save(IConfigSource source);
        IConfigSource Load();
    }
}