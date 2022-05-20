using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocGenerator.Extension;
namespace DocGenerator
{
    [Verb("doc", true, HelpText = "Gera um conjunto de dados baseado na combinação de propriedades.")]
    public class Commands
    {
        [Option("forceCPF", Required = false, HelpText = "Forçar uso de CPF")]
        public bool forceCPF { get; set; }

        [Option("forceCNPJ", Required = false, HelpText = "Forçar uso de CNPJ")]
        public bool forceCNPJ { get; set; }

        [Option("cpfcnpj", Required = false, HelpText = "Forçar uso de um CPFCNPJ específico")]
        public string CPFCNPJ { get; set; }

        [Option("count", Required = false, HelpText = "Quantidade de imagens")]
        public int ImagesToGenerate { get; set; }

        [Option('c', "categoria", Required = false, HelpText = "Gerar log com campo CategoriaDocumento")]
        public string CategoriaDocumento { get; set; }

        [Option('b', "base64", Required = false, HelpText = "Gerar log com  Base64 da imagem")]
        public bool GenerateBase64 { get; set; }

        [Option('w', "width", Required = false, HelpText = "Largura")]
        public int Width { get; set; } = 100;

        [Option('h', "height", Required = false, HelpText = "Altura")]
        public int Height { get; set; } = 100;

    }
    
}
