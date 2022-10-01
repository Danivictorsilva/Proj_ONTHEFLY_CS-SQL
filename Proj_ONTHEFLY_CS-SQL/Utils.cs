using System;
using System.Globalization;

namespace Proj_ONTHEFLY_CS_SQL
{
    public class Utils
    {
        public static string ReadString(string text)
        {
            Console.Write(text);
            return Console.ReadLine();
        }
        public static int ReadInt(string text)
        {
            Console.Write(text);
            int i;
            while (!int.TryParse(Console.ReadLine(), out i))
                Console.Write("Digite um inteiro válido!\n{0}", text);
            return i;
        }
        public static char ReadChar(string text)
        {
            Console.Write(text);
            char c;
            while (!char.TryParse(Console.ReadLine(), out c))
                Console.Write("Digite um caractere válido!\n{0}", text);
            return c;
        }
        public static DateTime ReadDateTime(string text)
        {
            Console.Write(text);
            DateTime d;
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out d))
                Console.Write("Digite uma data válida!\n{0}", text);
            return d;
        }
        public static bool BuscarNoArray(string c, string[] list)
        {
            for (int i = 0; i < list.Length; i++)
                if (list[i] == c) return true;
            return false;
        }
        public static bool ValidCPF(ref string cPF, ref string msg)
        {
            string cpfString = cPF;
            int digVerificador, v1, v2, aux;
            int[] digitosCPF = new int[9];

            if (!long.TryParse(cpfString, out long cpfLong))
            {
                msg = "O CPF é inválido\n";
                return false;
            }
            digVerificador = (int)(cpfLong % 100);
            cpfLong /= 100;
            for (int i = 0; i < 9; i++)
            {
                aux = (int)(cpfLong % 10);
                digitosCPF[i] = aux;
                cpfLong /= 10;
            }
            for (int i = 0; i < digitosCPF.Length; i++)
            {
                if (i == digitosCPF.Length - 1)
                {
                    msg = "O CPF é inválido\n";
                    return false;
                }
                if (digitosCPF[i] != digitosCPF[i + 1]) break;
            }
            v1 = v2 = 0;
            for (int i = 0; i < 9; i++)
            {
                v1 += digitosCPF[i] * (9 - i);
                v2 += digitosCPF[i] * (8 - i);
            }
            v1 = (v1 % 11) % 10;
            v2 += v1 * 9;
            v2 = (v2 % 11) % 10;
            if (v1 * 10 + v2 == digVerificador) return true;
            else
            {
                msg = "O CPF é inválido\n";
                return false;
            }
        }
        public static bool ValidCNPJ(ref string cPF, ref string msg)
        {
            string cnpjString = cPF;
            int digVerificador, v1, v2, aux;
            int[] digitosCNPJ = new int[12];
            int[] auxVector = new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            if (!long.TryParse(cnpjString, out long cnpjLong))
            {
                msg = "O CNPJ é inválido\n";
                return false;
            }
            digVerificador = (int)(cnpjLong % 100);
            cnpjLong /= 100;
            for (int i = 0; i < 12; i++)
            {
                aux = (int)(cnpjLong % 10);
                digitosCNPJ[i] = aux;
                cnpjLong /= 10;
            }
            for (int i = 0; i < digitosCNPJ.Length; i++)
            {
                if (i == digitosCNPJ.Length - 1)
                {
                    msg = "O CNPJ é inválido\n";
                    return false;
                }
                if (digitosCNPJ[i] != digitosCNPJ[i + 1]) break;
            }
            v1 = v2 = 0;
            for (int i = 0; i < 12; i++)
            {
                v1 += digitosCNPJ[i] * (11 - auxVector[11 - i]);
                if (i < 11) v2 += digitosCNPJ[i] * (11 - auxVector[10 - i]);
            }
            v1 = (v1 % 11) % 10;
            v2 += digitosCNPJ[11] * 5 + v1 * 9;
            v2 = (v2 % 11) % 10;
            if (v1 * 10 + v2 == digVerificador) return true;
            else
            {
                msg = "O CNPJ é inválido\n";
                return false;
            }
        }

        public static string ReadTelefone(string text)
        {
            string TelString;
            long TelLong;
            Console.Write(text);
            TelString = Console.ReadLine();
            while (!long.TryParse(TelString, out TelLong))
            {
                Console.Write("Digite um Telefone válido!\n{0}", text);
                TelString = Console.ReadLine();
            }
            while (TelString.Length != 11)
            {
                Console.Write("Digite um Telefone válido!\n{0}", text);
                TelString = Console.ReadLine();
            }
            return TelString;
        }
        public static char ReadSexo(string text)
        {
            char s = Char.ToUpper(ReadChar(text));
            while (s != 'M' && s != 'F' && s != 'N')
            {
                Console.WriteLine("Entrada inválida! Digite novamente...");
                s = Char.ToUpper(ReadChar(text));
            }
            return s;
        }
    }
}

