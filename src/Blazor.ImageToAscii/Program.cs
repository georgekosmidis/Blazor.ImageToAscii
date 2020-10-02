using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Tewr.Blazor.FileReader;
using Image2Text.Core.ImageTranformations;
using Image2Text.Core.ByteTransformations;
using Image2Text.Core;

namespace Blazor.ImageToAscii
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped<ImageBytes>();
            builder.Services.AddScoped<ImageGrayscale>();
            builder.Services.AddScoped<ImageResizer>();
            builder.Services.AddScoped<ImageConverter>();
            builder.Services.AddScoped<BytesConverter>();
            builder.Services.AddScoped<ConverterFactory>();
            
            builder.Services.AddFileReaderService(options => options.UseWasmSharedBuffer = true);

            await builder.Build().RunAsync();
        }
    }
}
