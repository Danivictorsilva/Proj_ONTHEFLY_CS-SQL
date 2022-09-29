using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;

namespace Proj_ONTHEFLY_CS_SQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declaracoes
            string op = "-1";
            string msg = "";
            List<String> optionsList = new()
            {
                "Modulo de Cadastro",
                "Modulo de Registro de Voos e Passagens",
                "Modulo de Venda de Passagens",
                "Sair do Programa"
            };
            string[] options = new string[optionsList.Count];

            //Programa Principal
            options[optionsList.Count - 1] = "0";
            for (int i = 0; i < optionsList.Count - 1; i++) options[i] = (i + 1).ToString();
            while (op != "0")
            {
                Console.Clear();
                Console.WriteLine("*********TELA INICIAL*********");
                for (int i = 0; i < optionsList.Count; i++) Console.WriteLine($"{options[i]}. {optionsList[i]}");
                Console.Write("\n{0}{1}{2}", msg == "" ? "" : ">>> ", msg, msg == "" ? "" : "\n");
                op = Utils.ReadString("Opcao: ");
                if (!Utils.BuscarNoArray(op, options))
                {
                    msg = "Opcao invalida! Digite novamente...";
                    continue;
                }
                switch (op)
                {
                    case "1":
                        Modulo_Cadastro();
                        msg = "";
                        break;
                    case "2":
                        Modulo_ResgistroVoo();
                        msg = "";
                        break;
                    case "3":
                        Modulo_VendaPassagem();
                        msg = "";
                        break;
                    case "0":
                        msg = "";
                        break;
                }
            }
        }

        private static void Modulo_Cadastro()
        {
            //Declaracoes
            string op = "-1";
            string msg = "";
            List<String> optionsList = new()
            {
                "Modulo de Cadastro de Passageiro",
                "Modulo de Cadastro de CompanhiaAerea",
                "Modulo de Cadastro de Aeronave",
                "Modulo de Cadastro de Restritos",
                "Modulo de Cadastro de Bloqueados",
                "Modulo de Cadastro de Destinos",
                "Voltar"
            };
            string[] options = new string[optionsList.Count];

            //Programa Principal
            options[optionsList.Count - 1] = "0";
            for (int i = 0; i < optionsList.Count - 1; i++) options[i] = (i + 1).ToString();
            while (op != "0")
            {
                Console.Clear();
                Console.WriteLine("*********MODULO DE CADASTROS*********");
                for (int i = 0; i < optionsList.Count; i++) Console.WriteLine($"{options[i]}. {optionsList[i]}");
                Console.Write("\n{0}{1}{2}", msg == "" ? "" : ">>> ", msg, msg == "" ? "" : "\n");
                op = Utils.ReadString("Opcao: ");
                if (!Utils.BuscarNoArray(op, options))
                {
                    msg = "Opcao invalida! Digite novamente...";
                    continue;
                }
                switch (op)
                {
                    case "1":
                        Modulo_Cadastro_Passageiro();
                        msg = "";
                        break;
                    case "2":
                        Modulo_Cadastro_CompanhiaAerea();
                        msg = "";
                        break;
                    case "3":
                        Modulo_Cadastro_Aeronave();
                        msg = "";
                        break;
                    case "4":
                        Modulo_Cadastro_Restritos();
                        msg = "";
                        break;
                    case "5":
                        Modulo_Cadastro_Bloqueados();
                        msg = "";
                        break;
                    case "6":
                        Modulo_Cadastro_Destino();
                        msg = "";
                        break;
                    case "0":
                        msg = "";
                        break;
                }
            }
        }
        #region SUBMODULOS CADASTRO
        private static void Modulo_Cadastro_Passageiro()
        {
            //Declaracoes
            string op = "-1";
            string msg = "";
            List<String> optionsList = new()
            {
                "Cadastrar Novo",
                "Localizar Registro",
                "Editar Registro",
                "Alterar Situacao",
                "Visualizar Registros",
                "Voltar"
            };
            string[] options = new string[optionsList.Count];

            //Programa Principal
            options[optionsList.Count - 1] = "0";
            for (int i = 0; i < optionsList.Count - 1; i++) options[i] = (i + 1).ToString();
            while (op != "0")
            {
                Console.Clear();
                Console.WriteLine("*********MODULO DE CADASTRO DE PASSAGEIRO*********");
                for (int i = 0; i < optionsList.Count; i++) Console.WriteLine($"{options[i]}. {optionsList[i]}");
                Console.Write("\n{0}{1}{2}", msg == "" ? "" : ">>> ", msg, msg == "" ? "" : "\n");
                op = Utils.ReadString("Opcao: ");
                if (!Utils.BuscarNoArray(op, options))
                {
                    msg = "Opcao invalida! Digite novamente...";
                    continue;
                }
                switch (op)
                {
                    case "1":
                        msg = "";
                        break;
                    case "2":
                        msg = "";
                        break;
                    case "3":
                        msg = "";
                        break;
                    case "4":
                        msg = "";
                        break;
                    case "5":
                        msg = "";
                        break;
                    case "0":
                        msg = "";
                        break;
                }
            }
        }
        #region FUNCOES CADASTRO PASSAGEIRO
        #endregion

        private static void Modulo_Cadastro_CompanhiaAerea()
        {
            throw new NotImplementedException();
        }

        private static void Modulo_Cadastro_Aeronave()
        {
            throw new NotImplementedException();
        }

        private static void Modulo_Cadastro_Restritos()
        {
            throw new NotImplementedException();
        }

        private static void Modulo_Cadastro_Bloqueados()
        {
            throw new NotImplementedException();
        }
 
        private static void Modulo_Cadastro_Destino()
        {
            throw new NotImplementedException();
        }
        #endregion

        private static void Modulo_ResgistroVoo()
        {
            //Declaracoes
            string op = "-1";
            string msg = "";
            List<String> optionsList = new()
            {
                "Cadastrar Novo",
                "Localizar Registro",
                "Editar Registro",
                "Alterar Situacao",
                "Visualizar Registros",
                "Voltar"
            };
            string[] options = new string[optionsList.Count];

            //Programa Principal
            options[optionsList.Count - 1] = "0";
            for (int i = 0; i < optionsList.Count - 1; i++) options[i] = (i + 1).ToString();
            while (op != "0")
            {
                Console.Clear();
                Console.WriteLine("*********MODULO DE REGISTROS DE VOO*********");
                for (int i = 0; i < optionsList.Count; i++) Console.WriteLine($"{options[i]}. {optionsList[i]}");
                Console.Write("\n{0}{1}{2}", msg == "" ? "" : ">>> ", msg, msg == "" ? "" : "\n");
                op = Utils.ReadString("Opcao: ");
                if (!Utils.BuscarNoArray(op, options))
                {
                    msg = "Opcao invalida! Digite novamente...";
                    continue;
                }
                switch (op)
                {
                    case "1":
                        msg = "";
                        break;
                    case "2":
                        msg = "";
                        break;
                    case "3":
                        msg = "";
                        break;
                    case "4":
                        msg = "";
                        break;
                    case "5":
                        msg = "";
                        break;
                    case "0":
                        msg = "";
                        break;
                }
            }
        }

        private static void Modulo_VendaPassagem()
        {
            //Declaracoes
            string op = "-1";
            string msg = "";
            List<String> optionsList = new()
            {
                "Cadastrar Nova Venda",
                "Localizar Registro de Venda",
                "Visualizar Registros de Venda",
                "Visualizar Proximos Voos Para Um Destino",
                "Localizar Um Voo",
                "Visualizar Registros de Voos",
                "Voltar"
            };
            string[] options = new string[optionsList.Count];

            //Programa Principal
            options[optionsList.Count - 1] = "0";
            for (int i = 0; i < optionsList.Count - 1; i++) options[i] = (i + 1).ToString();
            while (op != "0")
            {
                Console.Clear();
                Console.WriteLine("*********MODULO DE VENDA DE PASSAGEM*********");
                for (int i = 0; i < optionsList.Count; i++) Console.WriteLine($"{options[i]}. {optionsList[i]}");
                Console.Write("\n{0}{1}{2}", msg == "" ? "" : ">>> ", msg, msg == "" ? "" : "\n");
                op = Utils.ReadString("Opcao: ");
                if (!Utils.BuscarNoArray(op, options))
                {
                    msg = "Opcao invalida! Digite novamente...";
                    continue;
                }
                switch (op)
                {
                    case "1":
                        msg = "";
                        break;
                    case "2":
                        msg = "";
                        break;
                    case "3":
                        msg = "";
                        break;
                    case "4":
                        msg = "";
                        break;
                    case "5":
                        msg = "";
                        break;
                    case "6":
                        msg = "";
                        break;
                    case "0":
                        msg = "";
                        break;
                }
            }
        }
    }
}