using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_ONTHEFLY_CS_SQL
{
    public class Menus
    {
        public static void ShowThreeOptionsMenu
        (
            string title,
            string fstMenuTxt,
            string sndManuTxt,
            string trdMenuTxt,
            Func<string> fstFunc,
            Func<string> sndFunc,
            Func<string> trdFunc
        )
        {
            char op = ' ';
            string msg = "";
            List<String> optionsList = new() { fstMenuTxt, sndManuTxt, trdMenuTxt, "Voltar" };
            char[] options = new char[optionsList.Count];

            options[optionsList.Count - 1] = '0';
            for (int i = 0; i < optionsList.Count - 1; i++) options[i] = char.Parse((i + 1).ToString());
            while (op != '0')
            {
                Console.Clear();
                Console.WriteLine($"*********{title}*********");
                for (int i = 0; i < optionsList.Count; i++) Console.WriteLine($"{options[i]}. {optionsList[i]}");
                Console.Write("\n{0}{1}{2}", msg == "" ? "" : ">>> ", msg, msg == "" ? "" : "\n");
                op = Utils.ReadChar("Opção: ");
                Console.WriteLine("");
                if (!Utils.FindCharInArray(op, options)) msg = "Opção inválida! Digite novamente...";
                switch (op)
                {
                    case '1': msg = fstFunc();
                        break;
                    case '2': msg = sndFunc();
                        break;
                    case '3': msg = trdFunc();
                        break;
                    case '0': msg = "";
                        break;
                }
            }
        }
        public static void ShowFourOptionsMenu
        (
            string title,
            string fstMenuTxt,
            string sndManuTxt,
            string trdMenuTxt,
            string fthMenuTxt,
            Func<string> fstFunc,
            Func<string> sndFunc,
            Func<string> trdFunc,
            Func<string> fthFunc
        )
        {
            char op = ' ';
            string msg = "";
            List<String> optionsList = new() { fstMenuTxt, sndManuTxt, trdMenuTxt, fthMenuTxt, "Voltar" };
            char[] options = new char[optionsList.Count];

            options[optionsList.Count - 1] = '0';
            for (int i = 0; i < optionsList.Count - 1; i++) options[i] = char.Parse((i + 1).ToString());
            while (op != '0')
            {
                Console.Clear();
                Console.WriteLine($"*********{title}*********");
                for (int i = 0; i < optionsList.Count; i++) Console.WriteLine($"{options[i]}. {optionsList[i]}");
                Console.Write("\n{0}{1}{2}", msg == "" ? "" : ">>> ", msg, msg == "" ? "" : "\n");
                op = Utils.ReadChar("Opção: ");
                Console.WriteLine("");
                if (!Utils.FindCharInArray(op, options)) msg = "Opção inválida! Digite novamente...";
                switch (op)
                {
                    case '1':
                        msg = fstFunc();
                        break;
                    case '2':
                        msg = sndFunc();
                        break;
                    case '3':
                        msg = trdFunc();
                        break;
                    case '4':
                        msg = fthFunc();
                        break;
                    case '0':
                        msg = "";
                        break;
                }
            }
        }
        public static void ShowFiveOptionsMenu
        (
            string title,
            string fstMenuTxt,
            string sndManuTxt,
            string trdMenuTxt,
            string fthMenuTxt,
            string ffthMenuTxt,
            Func<string> fstFunc,
            Func<string> sndFunc,
            Func<string> trdFunc,
            Func<string> fthFunc,
            Func<string> ffthFunc
        )
        {
            char op = ' ';
            string msg = "";
            List<String> optionsList = new() { fstMenuTxt, sndManuTxt, trdMenuTxt, fthMenuTxt, ffthMenuTxt, "Voltar" };
            char[] options = new char[optionsList.Count];

            options[optionsList.Count - 1] = '0';
            for (int i = 0; i < optionsList.Count - 1; i++) options[i] = char.Parse((i + 1).ToString());
            while (op != '0')
            {
                Console.Clear();
                Console.WriteLine($"*********{title}*********");
                for (int i = 0; i < optionsList.Count; i++) Console.WriteLine($"{options[i]}. {optionsList[i]}");
                Console.Write("\n{0}{1}{2}", msg == "" ? "" : ">>> ", msg, msg == "" ? "" : "\n");
                op = Utils.ReadChar("Opção: ");
                Console.WriteLine("");
                if (!Utils.FindCharInArray(op, options)) msg = "Opção inválida! Digite novamente...";
                switch (op)
                {
                    case '1': msg = fstFunc();
                        break;
                    case '2': msg = sndFunc();
                        break;
                    case '3': msg = trdFunc();
                        break;
                    case '4': msg = fthFunc();
                        break;
                    case '5': msg = ffthFunc();
                        break;
                    case '0': msg = "";
                        break;
                }
            }
        }
        public static void ShowPrintMenu(string title, ref char op, string record, int listCount, ref int i, List<string> optionsList, char[] options, ref string msg)
        {
            Console.Clear();
            Console.WriteLine($"*********{title}*********");
            Console.WriteLine(record);
            Console.WriteLine($">>> Registro atual: {i + 1}    /    Qtde total de registros: {listCount}");
            Console.WriteLine("");
            for (int j = 0; j < optionsList.Count; j++) Console.WriteLine($"{options[j]}. {optionsList[j]}");
            Console.Write("\n{0}{1}{2}", msg == "" ? "" : ">>> ", msg, msg == "" ? "" : "\n");
            op = Utils.ReadChar("Opção: ");
            Console.WriteLine("");
            if (!Utils.FindCharInArray(op, options)) msg = "Opção inválida! Digite novamente...";
            switch (op)
            {
                case '1': i = 0;
                    break;
                case '2': if (i > 0) i--;
                    break;
                case '3': if (i < listCount - 1) i++;
                    break;
                case '4': i = listCount - 1;
                    break;
                case '0': break;
            }
        }
    }
}
