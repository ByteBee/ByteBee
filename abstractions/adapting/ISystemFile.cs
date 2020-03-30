using System.IO;
using System.Text;

namespace ByteBee.Framework.Abstractions.Adapting
{
    public interface ISystemFile
    {
        /// <inheritdoc cref="File.Exists(string)"/>
        bool Exists(string path);

        /// <inheritdoc cref="File.ReadAllText(string)"/>
        string ReadAllText(string path);

        /// <inheritdoc cref="File.ReadAllText(string,Encoding)"/>
        string ReadAllText(string path, Encoding encoding);

        /// <inheritdoc cref="File.WriteAllText(string,string)"/>
        void WriteAllText(string path, string content);

        /// <inheritdoc cref="File.WriteAllText(string,string,Encoding)"/>
        void WriteAllText(string path, string content, Encoding encoding);
    }
}
