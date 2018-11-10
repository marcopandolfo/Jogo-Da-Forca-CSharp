using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaForca
{
    static class Acentos
    {
        public static char[] VerificaVetor(this string texto)
        {
            char[] novaArray = new char[6];
            char[] acentosA = { 'A', 'Á', 'Ã', 'Â', 'À', 'Ä' };
            char[] acentosE = { 'E', 'É', 'Ê', 'È', 'Ë' };
            char[] acentosI = { 'I', 'Í', 'Î', 'Ì', 'Ï' };
            char[] acentosO = { 'O', 'Ó', 'Õ', 'Ô', 'Ò', 'Ö' };
            char[] acentosU = { 'U', 'Ú', 'Û', 'Ù', 'Ü' };

            switch(texto)
            {
                case "A": novaArray = acentosA.ToArray(); break;
                case "E": novaArray = acentosE.ToArray(); break;
                case "I": novaArray = acentosI.ToArray(); break;
                case "O": novaArray = acentosO.ToArray(); break;
                case "U": novaArray = acentosU.ToArray(); break;
            }

            return novaArray;
        }

        public static char VerificarLetra(this char texto, char[] acentos)
        {
            var letra = acentos.Where(a => a == texto);
            return letra.FirstOrDefault();
        }
    }
}
