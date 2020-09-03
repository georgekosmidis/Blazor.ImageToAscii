using System;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Tga;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Image2Text.Core.ImageTranformations
{
    public class ImageResizer
    {
        public ImageResizer() { }

        public Image<Rgba32> Convert(Image<Rgba32> image, int width, int height)
        {
            if (image == null)
            {
                throw new ArgumentNullException(nameof(image));
            }
            if (width == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(width));
            }
            if (height == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(height));
            }

            image.Mutate(x => x.Resize(width, height));

            return image;
        }
    }
}
