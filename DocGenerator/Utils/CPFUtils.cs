using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocGenerator.Utils
{
	//retirado de https://marcoluglio.github.io/br/inscricaoestadualcpfcnpj/

	public static class CPFUtils
	{
		public static string GerarCpf()
		{
			int soma = 0;
			int resto = 0;
			int[] multiplicadores = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			string semente;

			var random = new Random();

			do
			{
				semente = random.Next(1, 999999999).ToString().PadLeft(9, '0');
			} while (
				semente == "000000000"
				|| semente == "111111111"
				|| semente == "222222222"
				|| semente == "333333333"
				|| semente == "444444444"
				|| semente == "555555555"
				|| semente == "666666666"
				|| semente == "777777777"
				|| semente == "888888888"
				|| semente == "999999999"
			);

			for (int i = 1; i < multiplicadores.Count(); i++)
			{
				soma += int.Parse(semente[i - 1].ToString()) * multiplicadores[i];
			}

			resto = soma % 11;
			if (resto < 2)
			{
				resto = 0;
			}
			else
			{
				resto = 11 - resto;
			}

			semente += resto;
			soma = 0;

			for (int i = 0; i < multiplicadores.Count(); i++)
			{
				soma += int.Parse(semente[i].ToString()) * multiplicadores[i];
			}

			resto = soma % 11;
			if (resto < 2)
			{
				resto = 0;
			}
			else
			{
				resto = 11 - resto;
			}

			semente = semente + resto;

			return semente;
		}
	}
}
