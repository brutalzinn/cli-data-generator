using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocGenerator.Utils
{
	//retirado de https://marcoluglio.github.io/br/inscricaoestadualcpfcnpj/
	public static class CNPJUtils
    {
		public static string GerarCnpj()
		{

			int soma = 0;
			int resto = 0;
			int[] multiplicadores = new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			string raiz;
			string sufixo;

			var random = new Random();

			do
			{
				raiz = random.Next(1, 99999999).ToString().PadLeft(8, '0');
				sufixo = random.Next(1, 9999).ToString().PadLeft(4, '0');
			} while (
				(raiz == "00000000" && sufixo == "0000")
				|| (raiz == "11111111" && sufixo == "1111")
				|| (raiz == "22222222" && sufixo == "2222")
				|| (raiz == "33333333" && sufixo == "3333")
				|| (raiz == "44444444" && sufixo == "4444")
				|| (raiz == "55555555" && sufixo == "5555")
				|| (raiz == "66666666" && sufixo == "6666")
				|| (raiz == "77777777" && sufixo == "7777")
				|| (raiz == "88888888" && sufixo == "8888")
				|| (raiz == "99999999" && sufixo == "9999")
			);

			string semente = raiz + sufixo;

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

			semente += resto;

			return semente;

		}
	}
}
