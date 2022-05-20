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
using DocGenerator.Utils;

namespace DocGenerator
{
    internal class Program
    {
      
        static void Main(string[] args)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                var text = "doc -width 1920 --height 1080 --count 1";// "doc --forceCNPJ --status 1,2,3 --base64";
                args = text.Split();
            }

            Parser.Default.ParseArguments<Commands>(args)
               .MapResult(
                 (Commands opts) => RunCommands(opts),
                 errs => 1);
        }

       

        static int RunCommands(Commands opts)
        {
            //não dá pra colocar no modelo de commands ainda.
            opts.CPFCNPJ = opts.PegarCPFCNPJ();
            int width = opts.Width, height = opts.Height;
            List<ImageModel> images = new List<ImageModel>();
            var statusList = opts.CategoriaDocumento?.Split(',').Select(s => Convert.ToInt32(s)).ToList() ?? new List<int>();

            for (var i = 1; i <= opts.ImagesToGenerate; i++)
            {
                Bitmap bmp = BitmapUtils.GenerateBitmap(width, height);
                if (opts.GenerateBase64)
                {
                    images.Add(new ImageModel(cpfcnpj: opts.CPFCNPJ, bmp.BitmapToBase64(), 1));
                }

                bmp.SaveBitmap($"imgs/teste_{i}.jpeg", ImageFormat.Jpeg);
            
            }
         
            for (var i = 0; i < statusList.Count; i++)
            {
                Bitmap bmp = BitmapUtils.GenerateBitmap(width, height);
                if (opts.GenerateBase64)
                {
                    images.Add(new ImageModel(cpfcnpj: opts.CPFCNPJ, bmp.BitmapToBase64(), statusList[i]));
                }

                bmp.SaveBitmap($"imgs/teste_status_{statusList[i]}.jpeg", ImageFormat.Jpeg);         
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
