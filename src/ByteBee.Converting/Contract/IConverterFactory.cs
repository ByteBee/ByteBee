namespace ByteBee.Converting.Contract
{
    public interface IConverterFactory
    {
        void RegisterCustomConverter<TResult>(ITypeConverter<TResult> customConverter);
        ITypeConverter<TResult> Create<TResult>();
    }
}