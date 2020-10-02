using Image2Text.Core.ImageTranformations;
using System;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Advanced;
using static SixLabors.ImageSharp.Advanced.AdvancedImageExtensions;
using System.IO;
using SixLabors.ImageSharp.PixelFormats;
using Image2Text.Core.ByteTransformations;

namespace Image2Text.Core
{
    public class ConverterFactory
    {
        private ImageConverter _imageConverter;
        private BytesConverter _bytesConverter;

        public ConverterFactory(ImageConverter imageConverter, BytesConverter bytesConverter)
        {
            _imageConverter = imageConverter;
            _bytesConverter = bytesConverter;
        }

        public string[] Convert(Stream stream, float outputWidth, string ramp)
        {
            using (var image = Image.Load<Rgba32>(stream))
            {
                return Convert(image, outputWidth, ramp);
            }
        }

        public string[] Convert(string imagePath, float outputWidth, string ramp)
        {
                using (var image = Image.Load<Rgba32>(imagePath))
                {
                    return Convert(image, outputWidth, ramp);
                }
        }

        public string[] Convert(byte[] bytes, float outputWidth, string ramp)
        {
            using (var image = Image.Load<Rgba32>(bytes))
            {
                return Convert(image, outputWidth, ramp);
            }
        }

        public string[] Convert(Image<Rgba32> image, float percentage, string ramp)
        {
            if (ramp == null)
            {
                throw new ArgumentNullException(nameof(ramp));
            }

            var bytes = _imageConverter.Convert(image, (int)(image.Width * percentage), (int)(image.Height * percentage));
            var text = _bytesConverter.Convert(bytes, ramp);

            return text;
        }
    }
}
