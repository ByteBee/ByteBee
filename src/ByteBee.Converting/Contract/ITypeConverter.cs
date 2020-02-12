namespace ByteBee.Framework.Converting.Contract
{
    public interface ITypeConverter<TResult>
    {
        TResult GetStandardValue();
        TResult Convert(object value);
        bool TryConvert(object value, out TResult result);
    }
}