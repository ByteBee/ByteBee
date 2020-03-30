using System.IO;
using System.Text;
using ByteBee.Framework.Abstractions.Adapting;

namespace ByteBee.Framework.Adapting
{
    public sealed class SystemFileAdapter : ISystemFile
    {
        public bool Exists(string path)
        {
            return File.Exists(path);
        }

        public string ReadAllText(string path)
        {
            return File.ReadAllText(path);
        }

        public string ReadAllText(string path, Encoding encoding)
        {
            return File.ReadAllText(path, encoding);
        }

        public void WriteAllText(string path, string content)
        {
            File.WriteAllText(path, content);
        }

        public void WriteAllText(string path, string content, Encoding encoding)
        {
            File.WriteAllText(path, content, encoding);
        }
    }
}
