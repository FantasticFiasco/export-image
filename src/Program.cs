using System;
using System.IO;

namespace ExportImage
{
    class Program
    {
        static void Main(string[] imagePaths)
        {
            Console.WriteLine($"Exporting {imagePaths.Length} images...");

            var settings = Settings.Load();
            var encoder = new Encoder(settings.Quality);

            for (var index = 0; index < imagePaths.Length; index++)
            {
                var imagePath = imagePaths[index];
                var (exportDirectoryPath, exportImagePath) = GetExportPaths(imagePath);

                EnsureDirectoryExists(exportDirectoryPath);

                using (var input = File.OpenRead(imagePath))
                using (var output = File.Create(exportImagePath))
                {
                    Console.WriteLine($"{index + 1}/{imagePaths.Length}\t-> {exportImagePath}");

                    encoder.SaveImage(input, output);
                }
            }

            Console.WriteLine("Done!");
        }

        private static (string, string) GetExportPaths(string imagePath)
        {
            var directoryPath = Path.GetDirectoryName(imagePath);
            var name = Path.GetFileName(imagePath);

            var exportDirectoryPath = Path.Combine(directoryPath, "Exported");
            var exportImagePath = Path.Combine(exportDirectoryPath, name);

            return (exportDirectoryPath, exportImagePath);
        }

        private static void EnsureDirectoryExists(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }
    }
}
