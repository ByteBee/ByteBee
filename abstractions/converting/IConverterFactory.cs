
namespace ByteBee.Framework.Abstractions.Converting
{
    public interface IConverterFactory
    {
        void RegisterCustomConverter<TResult>(ITypeConverter<TResult> customConverter);
        ITypeConverter<TResult> Create<TResult>();
    }
}