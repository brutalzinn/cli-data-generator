using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocGenerator.Extension;
namespace DocGenerator
{
    [Verb("Comandos", true, HelpText = "Gera um conjunto de imagens.")]
    public class Commands
    {
        [Option("forceCPF", Required = false, HelpText = "Gerar imagem")]
        public bool forceCPF { get; set; }

        [Option("forceCNPJ", Required = false, HelpText = "Gerar imagem")]
        public bool forceCNPJ { get; set; }

        [Option("cpfcnpj", Required = false, HelpText = "Gerar imagem")]
        public string CPFCNPJ { get; set; }

        [Option("count", Required = false, HelpText = "Gerar imagem")]
        public int ImagesToGenerate { get; set; }

        [Option('s', "status", Required = false, HelpText = "Gerar status")]
        public string Status { get; set; }

        [Option('b', "base64", Required = false, HelpText = "Gerar JSON base64")]
        public bool GenerateBase64 { get; set; }
    }
}
