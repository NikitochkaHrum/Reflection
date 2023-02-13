using System;
using System.Drawing;

namespace PluginInterface
{
    public interface IPlugin
    {
        string Name { get; }
        string Author { get; }
        void Transform(Bitmap app);
    }
    public class VersionAttribute : Attribute
    {
        public int Major { get; private set; }
        public int Minor { get; private set; }
        public VersionAttribute(int major, int minor)
        {
            Major = major;
            Minor = minor;
        }
    }
}
