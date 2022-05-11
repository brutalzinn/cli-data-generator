using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using CommandLine;

namespace DocGenerator
{
    internal class Program
    {
        public class ImageOptions
        {
            [Option('i', "img", Required = true, HelpText = "Gerar imagem")]
            public int ImagesToGenerate { get; set; }

            [Option('b', "base64", Required = false, HelpText = "Gerar JSON base64")]
            public bool GenerateBase64 { get; set; }
        }

        public class ImagesBase64
        {
            public string Base64 { get; set; }
            public string Nome { get; set; }

            public ImagesBase64(string base64, string nome)
            {
                Base64 = base64;
                Nome = nome;
            }
        }

        static void Main(string[] teste)
        {
            var text = "--img 10";
            var args = text.Split();

            Parser.Default.ParseArguments<ImageOptions>(args)
            .WithParsed(RunOptions)
           .WithNotParsed(HandleParseError);
        }
        static void RunOptions(ImageOptions opts)
        {
            int width = 100, height = 100;

            Console.WriteLine($"Imagens para gerar {opts.ImagesToGenerate} {opts.GenerateBase64}");

            List<ImagesBase64> images = new List<ImagesBase64>();

            for (var i = 1; i <= opts.ImagesToGenerate; i++)
            {
                Bitmap bmp = new Bitmap(width, height);

                Random rand = new Random();

                int r = rand.Next(0, 255);
                int g = rand.Next(0, 255);
                int b = rand.Next(0, 255);
                int a = rand.Next(0, 255);
                
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                    }
                }

                if (opts.GenerateBase64)
                {
                    using (MemoryStream jpegStream = new MemoryStream())
                    {
                        bmp.Save(jpegStream, ImageFormat.Jpeg);
                        images.Add(new ImagesBase64(Convert.ToBase64String(jpegStream.ToArray()), $"teste_{i}"));
                    }
                    JsonSerializerOptions options = new JsonSerializerOptions();
                    options.WriteIndented = true; 
                    options.NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals;
                    File.WriteAllText("teste.json", JsonSerializer.Serialize(images, options));
                }

                bmp.Save($"imgs/teste_{i}.jpeg", ImageFormat.Jpeg);

            }
        }

        static void HandleParseError(IEnumerable<Error> errs)
        {
            //handle errors
        }
    }
}
