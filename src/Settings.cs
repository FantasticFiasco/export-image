using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ExportImage
{
    public class Settings
    {
        private const string FileName = "ExportImage.Settings.yml";

        /// <summary>
        /// Gets or sets the image quality index, which must be between 0 and 100 (compression from
        /// max to min).
        /// </summary>
        public int Quality { get; set;  }

        /// <summary>
        /// Gets or sets a value indicating whether the export process should be prevented termination.
        /// </summary>
        public bool PreventTermination { get; set; }

        public static Settings Load()
        {
            var settings = File.ReadAllText(Path.Combine(ApplicationPath.InstallationDirectory, FileName));

            return new DeserializerBuilder()
                .WithNamingConvention(new CamelCaseNamingConvention())
                .Build()
                .Deserialize<Settings>(settings);
        }
    }
}
