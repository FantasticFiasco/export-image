using System.IO;
using System.Reflection;

namespace ExportImage
{
    public static class ApplicationPath
    {
        static ApplicationPath()
        {
            var assembly = Assembly.GetExecutingAssembly();

            InstallationDirectory = Path.GetDirectoryName(assembly.Location);
        }

        public static string InstallationDirectory { get; }
    }
}
