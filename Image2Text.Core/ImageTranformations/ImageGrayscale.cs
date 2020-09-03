using System;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Tga;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Image2Text.Core.ImageTranformations
{
    public class ImageGrayscale
    {
        public ImageGrayscale() { }

        public Image<Rgba32> Convert(Image<Rgba32> image)
        {
            if (image == null)
            {
                throw new ArgumentNullException(nameof(image));
            }

            image.Mutate(x => x.Grayscale());

            return image;
        }
    }
}
