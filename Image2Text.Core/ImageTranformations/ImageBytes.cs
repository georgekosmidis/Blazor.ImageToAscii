using System;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Advanced;
using static SixLabors.ImageSharp.Advanced.AdvancedImageExtensions;
using SixLabors.ImageSharp.Processing;

namespace Image2Text.Core.ImageTranformations
{
    public class ImageBytes
    {
        public byte[][] GetPixelAverageRgb(Image<Rgba32> image)
        {
            if (image == null)
            {
                throw new ArgumentNullException(nameof(image));
            }

            var result = new byte[image.Height][];
            for (int i = 0; i < image.Height; i++)
            {
                result[i] = new byte[image.Width];
            }

            for (int y = 0; y < image.Height; y++)
            {
                var pixelRowSpan = image.GetPixelRowSpan(y);
                for (int x = 0; x < image.Width; x++)
                {
                    if (pixelRowSpan[x].A <= 5)
                        result[y][x] = 255;
                    else
                        result[y][x] = (byte)(((int)pixelRowSpan[x].R + (int)pixelRowSpan[x].G + (int)pixelRowSpan[x].B) / 3);
                }
            }

            return result;
        }
    }
}
