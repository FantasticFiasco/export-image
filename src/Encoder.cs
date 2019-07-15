using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;

namespace ExportImage
{
    public class Encoder
    {
        private readonly JpegEncoder encoder;

        public Encoder(int quality)
        {
            encoder = new JpegEncoder
            {
                Quality = quality
            };
        }

        public void SaveImage(string inputPath, string outputPath)
        {
            using (var image = Image.Load(inputPath))
            using (var output = File.Create(outputPath))
            {
                image.SaveAsJpeg(output, encoder);
            }
        }
    }
}
