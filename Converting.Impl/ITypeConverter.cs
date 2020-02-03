namespace ByteBee.Framework.Converting
{
    public interface ITypeConverter
    {
    }

    public interface ITypeConverter<TResult> : ITypeConverter
    {
        TResult ConvertFrom(object value);
        bool TryConvertFrom(object value, out TResult result);
    }
}