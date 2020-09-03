using System;
using System.Diagnostics;
using System.IO;
using Image2Text.Core;
using Image2Text.Core.ByteTransformations;
using Image2Text.Core.ImageTranformations;

namespace I2A.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var imagePath = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "Samples" + Path.DirectorySeparatorChar + "dotbot.jpg";
            var percentage = 0.05f;

            var convertFactory = new ConverterFactory(
                new ImageConverter(
                    new ImageBytes(),
                    new ImageGrayscale(),
                    new ImageResizer()
                ),
                new BytesConverter()
            );
            var text = convertFactory.Convert(imagePath, percentage, DefaultRamps.DefaultRamp);

            var tmp = Path.GetTempFileName() + ".txt";
            File.WriteAllLines(tmp, text);

            //
            var process = new Process();
            process.StartInfo = new ProcessStartInfo()
            {
                UseShellExecute = true,
                FileName = tmp
            };

            process.Start();
            process.WaitForExit();

        }
    }
}
