using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace Image2Text.Core.ImageTranformations
{
    public class ImageResize
    {

        public void Resize(Image originalImage, Bitmap outputBitmap, int outputWidth, int outputHeight)
        {
            //if (originalImage.Width == outputWidth && originalImage.Height == outputHeight)
            //    return;
            originalImage.Mutate(x => x.Resize(outputWidth, outputHeight));

            using (var g = Graphics.FromImage(outputBitmap))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(
                        originalImage,
                        new Rectangle(0, 0, outputWidth, outputHeight),
                        0,
                        0,
                        originalImage.Width,
                        originalImage.Height,
                        GraphicsUnit.Pixel
                );
            }
        }
    }
}
