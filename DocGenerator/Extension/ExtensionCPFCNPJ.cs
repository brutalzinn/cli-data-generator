using DocGenerator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocGenerator.Extension
{
    public static class ExtensionCPFCNPJ
    {
        public static string PegarCPFCNPJ(this Commands opts)
        {
            if (string.IsNullOrEmpty(opts.CPFCNPJ))
            {
                var randomCPFCNPJ = new Random().Next(0, 100);
                if (opts.forceCPF)
                {
                    opts.CPFCNPJ = CPFUtils.GerarCpf();
                }
                else if (opts.forceCNPJ)
                {
                    opts.CPFCNPJ = CNPJUtils.GerarCnpj();
                }
                else if (randomCPFCNPJ >= 50)
                {
                    opts.CPFCNPJ = CPFUtils.GerarCpf();
                }
                else
                {
                    opts.CPFCNPJ = CNPJUtils.GerarCnpj();
                }
            } 
            return opts.CPFCNPJ;
            
        }
    }
}
