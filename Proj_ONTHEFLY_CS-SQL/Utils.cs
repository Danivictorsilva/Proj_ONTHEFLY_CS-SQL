using System;

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
            while (!DateTime.TryParse(Console.ReadLine(), out d))
                Console.Write("Digite uma data válida!\n{0}", text);
            return d;
        }
        public static bool BuscarNoArray(string c, string[] list)
        {
            for (int i = 0; i < list.Length; i++)
                if (list[i] == c) return true;
            return false;
        }
        public static string ReadCPF(string text)
        {
            string cpfString;
            long cpfLong;
            int digVerificador, v1, v2, aux;
            int[] digitosCPF = new int[9];
            bool digitosIguais;

            while (true)
            {
                Console.Write(text);
                cpfString = Console.ReadLine();
                while (!long.TryParse(cpfString, out cpfLong))
                {
                    Console.Write("Digite um CPF válido!\n{0}", text);
                    cpfString = Console.ReadLine();
                }
                digVerificador = (int)(cpfLong % 100);
                cpfLong /= 100;
                for (int i = 0; i < 9; i++)
                {
                    aux = (int)cpfLong % 10;
                    digitosCPF[i] = aux;
                    cpfLong /= 10;
                }
                digitosIguais = false;
                for (int i = 0; i < digitosCPF.Length; i++)
                {
                    if (i == digitosCPF.Length - 1)
                    {
                        Console.WriteLine("O CPF não segue as regras de validação da Receita Federal!");
                        digitosIguais = true;
                        break;
                    }
                    if (digitosCPF[i] != digitosCPF[i + 1]) break;
                }
                if (digitosIguais) continue;
                v1 = v2 = 0;
                for (int i = 0; i < 9; i++)
                {
                    v1 += digitosCPF[i] * (9 - i);
                    v2 += digitosCPF[i] * (8 - i);
                }
                v1 = (v1 % 11) % 10;
                v2 += v1 * 9;
                v2 = (v2 % 11) % 10;
                if (v1 * 10 + v2 == digVerificador) return cpfString;
                else Console.WriteLine("O CPF não segue as regras de validação da Receita Federal!");
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
            while (s != 'M' && s != 'F')
            {
                Console.WriteLine("Entrada inválida! Digite novamente...");
                s = Char.ToUpper(ReadChar(text));
            }
            return s;
        }
    }
}

