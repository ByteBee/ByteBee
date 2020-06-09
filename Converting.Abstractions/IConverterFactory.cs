
namespace ByteBee.Framework.Converting.Abstractions
{
    public interface IConverterFactory
    {
        void RegisterCustomConverter<TResult>(ITypeConverter<TResult> customConverter);
        ITypeConverter<TResult> Create<TResult>();
    }
}