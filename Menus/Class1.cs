using Proj_ONTHEFLY_CS_SQL;
using System;
using System.Collections.Generic;
using System.Data;

namespace Menus
{
    public class MenuTemplateWithFiveRows
    {
        public static void Show(
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
            Func<string> ffthFunc)
        {
            //Declaracoes
            char op = ' ';
            string msg = "";
            List<String> optionsList = new()
            {
                fstMenuTxt,
                sndManuTxt,
                trdMenuTxt,
                fthMenuTxt,
                ffthMenuTxt,
                "Voltar"
            };
            char[] options = new char[optionsList.Count];

            //Programa Principal
            options[optionsList.Count - 1] = '0';
            for (int i = 0; i < optionsList.Count - 1; i++) options[i] = char.Parse((i + 1).ToString());
            while (op != '0')
            {
                Console.Clear();
                Console.WriteLine($"*********{title}*********");
                for (int i = 0; i < optionsList.Count; i++) Console.WriteLine($"{options[i]}. {optionsList[i]}");
                Console.Write("\n{0}{1}{2}", msg == "" ? "" : ">>> ", msg, msg == "" ? "" : "\n");
                op = Utils.ReadChar("Opção: ");
                if (!Utils.BuscarNoArray2(op, options))
                {
                    msg = "Opção invalida! Digite novamente...";
                    continue;
                }
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
                    case '5':
                        msg = ffthFunc();
                        break;
                    case '0':
                        msg = "";
                        break;
                }
            }
        }
    }
}
