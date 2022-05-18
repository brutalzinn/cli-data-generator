using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using CommandLine;
using System.Linq;
using DocGenerator.Models;
using DocGenerator.Extension;
namespace DocGenerator
{
    internal class Program
    {
      
        static void Main(string[] args)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                var text = "--forceCNPJ --status 1,2,3 --base64";
                args = text.Split();
            }

            Parser.Default.ParseArguments<Commands>(args)
               .MapResult(
                 (Commands opts) => RunCommands(opts),
                 errs => 1);
        }

        static Bitmap GenerateBitmap(int width, int height)
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
            return bmp;

        }

        static int RunCommands(Commands opts)
        {
            //não dá pra colocar no modelo de commands ainda.
            opts.CPFCNPJ = opts.PegarCPFCNPJ();
            int width = 100, height = 100;
            List<ImageModel> images = new List<ImageModel>();
            var statusList = opts.Status?.Split(',').Select(s => Convert.ToInt32(s)).ToList() ?? new List<int>();

            for (var i = 1; i <= opts.ImagesToGenerate; i++)
            {
                Bitmap bmp = GenerateBitmap(width, height);
                if (opts.GenerateBase64)
                {
                    using (MemoryStream jpegStream = new MemoryStream())
                    {
                        bmp.Save(jpegStream, ImageFormat.Jpeg);
                        images.Add(new ImageModel(cpfcnpj: opts.CPFCNPJ, Convert.ToBase64String(jpegStream.ToArray()), 1));
                    }
                }
                bmp.Save($"imgs/teste_{i}.jpeg", ImageFormat.Jpeg);
            }
         
            for (var i = 0; i < statusList.Count; i++)
            {
                Bitmap bmp = GenerateBitmap(width, height);
                if (opts.GenerateBase64)
                {
                    using (MemoryStream jpegStream = new MemoryStream())
                    {
                        bmp.Save(jpegStream, ImageFormat.Jpeg);
                        images.Add(new ImageModel(cpfcnpj: opts.CPFCNPJ, Convert.ToBase64String(jpegStream.ToArray()), statusList[i]));
                    }

                }
                bmp.Save($"imgs/teste_status_{statusList[i]}.jpeg", ImageFormat.Jpeg);
            }
            

            Console.WriteLine(
            $"Documento: {opts.CPFCNPJ}" + 
            $"Quantidade: {opts.ImagesToGenerate + statusList.Count}" +
            $" Base64: {opts.GenerateBase64}");
            //}
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.WriteIndented = true;
            options.NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals;
            File.WriteAllText("teste.json", JsonSerializer.Serialize(images, options));


            return 0;
            
        }

 
    }
}
