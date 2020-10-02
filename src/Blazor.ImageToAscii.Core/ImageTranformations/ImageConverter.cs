using System;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Tga;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Image2Text.Core.ImageTranformations
{
    public class ImageConverter
    {
        private ImageBytes _imageBytes;
        private ImageGrayscale _imageGrayscale;
        private ImageResizer _imageResizer;

        public ImageConverter(ImageBytes imageBytes, ImageGrayscale imageGrayscale, ImageResizer imageResizer)
        {
            _imageBytes = imageBytes;
            _imageGrayscale = imageGrayscale;
            _imageResizer = imageResizer;
        }

        public byte[][] Convert(Image<Rgba32> image, int width, int height)
        {
            if (image == null)
            {
                throw new ArgumentNullException(nameof(image));
            }

            image = _imageResizer.Convert(image, width, height);
            image = _imageGrayscale.Convert(image);
            return _imageBytes.GetPixelAverageRgb(image);
        }
    }
}
