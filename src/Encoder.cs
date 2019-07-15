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

        public void SaveImage(Stream input, Stream output)
        {
            using (var image = Image.Load(input))
            {
                image.SaveAsJpeg(output, encoder);
            }
        }
    }
}
