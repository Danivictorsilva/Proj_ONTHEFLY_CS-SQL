using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Proj_ONTHEFLY_CS_SQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menus.ShowThreeOptionsMenu
            (
                "TELA INICIAL",
                "Modulo de Cadastro",
                "Modulo de Registro de Voos e Passagens",
                "Modulo de Venda de Passagens",
                Modulo_Cadastro,
                Modulo_RegistroVoo,
                Modulo_VendaPassagem
            );
        }

        private static string Modulo_Cadastro()
        {
            Menus.ShowFiveOptionsMenu
            (
                "MODULO DE CADASTRO",
                "Cadastro de Passageiro",
                "Cadastro de Companhia Aérea",
                "Cadastro de Aeronave",
                "Cadastro de Restritos",
                "Cadastro de Bloqueados",
                Modulo_Cadastro_Passageiro,
                Modulo_Cadastro_CompanhiaAerea,
                Modulo_Cadastro_Aeronave,
                Modulo_Cadastro_Restritos,
                Modulo_Cadastro_Bloqueados
            );
            return "";
        }
        // SUBMODULO CADASTRO PASSAGEIRO **************************************************************
        private static string Modulo_Cadastro_Passageiro()
        {
            Menus.ShowFiveOptionsMenu
            (
                "MODULO DE CADASTRO DE PASSAGEIRO",
                "Cadastrar Novo",
                "Localizar Registro",
                "Editar Registro",
                "Inativar Registro",
                "Visualizar Registros Ativos",
                Modulo_Cadastro_Passageiro_New,
                Modulo_Cadastro_Passageiro_Find,
                Modulo_Cadastro_Passageiro_Edit,
                Modulo_Cadastro_Passageiro_Idle,
                Modulo_Cadastro_Passageiro_Print
            );
            return "";
        }
        //FUNCOES CADASTRO PASSAGEIRO
        private static string Modulo_Cadastro_Passageiro_New()
        {
            string cPF;
            string msg = "";

            cPF = Utils.ReadString("Digite o CPF do passageiro (sem pontos ou traços): ");
            if (!Utils.ValidCPF(ref cPF, ref msg)) return msg;
            Passageiro passageiro =
            new
            (
                cPF,
                Utils.ReadString("Digite o Nome do passageiro: ").ToUpper(),
                Utils.ReadDateTime("Digite a Data de Nascimento do passageiro (DD/MM/YYYY): "),
                Utils.ReadSexo("Digite o Sexo do passageiro\nM - Masculino\nF - Feminino\nN - Não deseja informar\nOpção: "),
                DateTime.Today,
                DateTime.Today,
                'A'
            );
            try
            {
                DataAcces.InsertPassageiro(passageiro);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                return $"O banco de dados retornou o seguinte erro: {e.Message}";
            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }
            return "Inserção realizada com sucesso!";
        }
        private static string Modulo_Cadastro_Passageiro_Find()
        {
            List<Passageiro> listaDePassageiros;
            string cPF;

            try
            {
                listaDePassageiros = DataAcces.GetPassageiro();
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                return $"O banco de dados retornou o seguinte erro: {e.Message}";
            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }

            cPF = Utils.ReadString("Digite o CPF do passageiro (sem pontos ou traços): ");
            foreach (Passageiro passageiro in listaDePassageiros)
            {
                if (passageiro.CPF == cPF) return $"\n{passageiro}\n";
            }
            return "Este CPF não consta na base de dados!";
        }
        private static string Modulo_Cadastro_Passageiro_Edit()
        {
            List<Passageiro> listaDePassageiros;
            string cPF;
            Passageiro passageiro;

            try
            {
                listaDePassageiros = DataAcces.GetPassageiro();
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                return $"O banco de dados retornou o seguinte erro: {e.Message}";
            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }

            cPF = Utils.ReadString("Digite o CPF do passageiro (sem pontos ou traços): ");
            if (Passageiro.FindKey(listaDePassageiros, cPF))
            {
                passageiro =
                new
                (
                    cPF,
                    Utils.ReadString("Digite o novo Nome do passageiro: ").ToUpper(),
                    Utils.ReadDateTime("Digite a nova Data de Nascimento do passageiro (DD/MM/YYYY): "),
                    char.ToUpper(Utils.ReadChar("Digite o novo Sexo do passageiro\nM - Masculino\nF - Feminino\nN - Não deseja informar\nOpção: "))
                );
                try
                {
                    DataAcces.UpdatePassageiro(passageiro);
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    return $"O banco de dados retornou o seguinte erro: {e.Message}";
                }
                catch (Exception e)
                {
                    return $"Error: {e.Message}";
                }
                return "Edição realizada com sucesso!";
            }
            return "Este CPF não consta na base de dados!";
        }
        private static string Modulo_Cadastro_Passageiro_Idle()
        {
            List<Passageiro> listaDePassageiros;
            string cPF;

            try
            {
                listaDePassageiros = DataAcces.GetPassageiro();
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                return $"O banco de dados retornou o seguinte erro: {e.Message}";
            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }

            cPF = Utils.ReadString("Digite o CPF do passageiro (sem pontos ou traços): ");
            if (Passageiro.FindKey(listaDePassageiros, cPF))
            {
                try
                {
                    DataAcces.UpdateFlipStatusPassageiro(new Passageiro(cPF, 'I'));
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    return $"O banco de dados retornou o seguinte erro: {e.Message}";
                }
                catch (Exception e)
                {
                    return $"Error: {e.Message}";
                }
                return "Passageiro inativado com sucesso!";
            }
            return "Este CPF não consta na base de dados!";
        }
        private static string Modulo_Cadastro_Passageiro_Print()
        {
            char op = ' ';
            string msg = "";
            int i = 0;
            List<Passageiro> listaDePassageiros;
            int listLenght;
            List<String> optionsList = new() { "Ir para o início", "Anterior", "Próximo", "Ir para o último", "Voltar" };
            char[] options = new char[optionsList.Count];
            options[optionsList.Count - 1] = '0';
            for (int j = 0; j < optionsList.Count - 1; j++) options[j] = char.Parse((j + 1).ToString());

            try
            {
                listaDePassageiros = DataAcces.GetPassageiro();
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                return $"O banco de dados retornou o seguinte erro: {e.Message}";
            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }

            listLenght = listaDePassageiros.Count;
            while (op != '0') 
                Menus.ShowPrintMenu("REGISTROS DE PASSAGEIROS", ref op, listaDePassageiros[i].ToString(), listLenght, ref i, optionsList, options, ref msg);
            
            return "";
        }
        
        // SUBMODULO CADASTRO COMPANHIA AEREA **************************************************************
        private static string Modulo_Cadastro_CompanhiaAerea()
        {
            Menus.ShowFiveOptionsMenu
            (
                "MODULO DE CADASTRO DE COMPANHIA AÉREA",
                "Cadastrar Novo",
                "Localizar Registro",
                "Editar Registro",
                "Inativar Registro",
                "Visualizar Registros Ativos",
                Modulo_Cadastro_CompanhiaAerea_New,
                Modulo_Cadastro_CompanhiaAerea_Find,
                Modulo_Cadastro_CompanhiaAerea_Edit,
                Modulo_Cadastro_CompanhiaAerea_Idle,
                Modulo_Cadastro_CompanhiaAerea_Print
            );
            return "";
        }
        private static string Modulo_Cadastro_CompanhiaAerea_New()
        {
            string cNPJ;
            string msg = "";

            cNPJ = Utils.ReadString("Digite o CNPJ da companhia aérea (sem pontos ou traços): ");
            if (!Utils.ValidCNPJ(ref cNPJ, ref msg)) return msg;
            CompanhiaAerea companhiaAerea =
            new
            (
                cNPJ,
                Utils.ReadString("Digite a Razão Social da companhia aérea (máximo de 50 dígitos): ").ToUpper(),
                Utils.ReadDateTime("Digite a Data de Abertura da companhia aérea (DD/MM/YYYY): "),
                DateTime.Today,
                DateTime.Today,
                'A'
            );
            if ((DateTime.Today - companhiaAerea.DataAbertura).Days < 180)
                return "Não é permitido cadastrar empresas com menos de 180 dias de operação!";
            try
            {
                DataAcces.InsertCompanhiaAerea(companhiaAerea);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                return $"O banco de dados retornou o seguinte erro: {e.Message}";
            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }
            return "Inserção realizada com sucesso!";
        }
        private static string Modulo_Cadastro_CompanhiaAerea_Find()
        {
            List<CompanhiaAerea> listaDeCompanhiaAereas;
            string cNPJ;

            try
            {
                listaDeCompanhiaAereas = DataAcces.GetCompanhiaAerea();
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                return $"O banco de dados retornou o seguinte erro: {e.Message}";
            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }

            cNPJ = Utils.ReadString("Digite o CNPJ da companhia aérea (sem pontos ou traços): ");
            foreach (CompanhiaAerea companhiaAerea in listaDeCompanhiaAereas)
            {
                if (companhiaAerea.CNPJ == cNPJ) return $"\n{companhiaAerea}\n";
            }
            return "Este CNPJ não consta na base de dados!";
        }
        private static string Modulo_Cadastro_CompanhiaAerea_Edit()
        {
            List<CompanhiaAerea> listaDeCompanhiaAereas;
            string cNPJ;
            CompanhiaAerea companhiaAerea;

            try
            {
                listaDeCompanhiaAereas = DataAcces.GetCompanhiaAerea();
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                return $"O banco de dados retornou o seguinte erro: {e.Message}";
            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }

            cNPJ = Utils.ReadString("Digite o CNPJ da companhia aérea (sem pontos ou traços): ");
            if (CompanhiaAerea.FindKey(listaDeCompanhiaAereas, cNPJ))
            {
                companhiaAerea =
                new
                (
                    cNPJ,
                    Utils.ReadString("Digite a nova Razão Social da companhia aérea: ").ToUpper(),
                    Utils.ReadDateTime("Digite a nova Data de Nascimento do companhia aérea (DD/MM/YYYY): ")
                );
                try
                {
                    DataAcces.UpdateCompanhiaAerea(companhiaAerea);
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    return $"O banco de dados retornou o seguinte erro: {e.Message}";
                }
                catch (Exception e)
                {
                    return $"Error: {e.Message}";
                }
                return "Edição realizada com sucesso!";
            }
            return "Este CNPJ não consta na base de dados!";
        }
        private static string Modulo_Cadastro_CompanhiaAerea_Idle()
        {
            List<CompanhiaAerea> listaDeCompanhiaAereas;
            string cNPJ;

            try
            {
                listaDeCompanhiaAereas = DataAcces.GetCompanhiaAerea();
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                return $"O banco de dados retornou o seguinte erro: {e.Message}";
            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }

            cNPJ = Utils.ReadString("Digite o CNPJ do companhia aérea (sem pontos ou traços): ");
            if (CompanhiaAerea.FindKey(listaDeCompanhiaAereas, cNPJ))
            {
                try
                {
                    DataAcces.UpdateFlipStatusCompanhiaAerea(new CompanhiaAerea(cNPJ, 'I'));
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    return $"O banco de dados retornou o seguinte erro: {e.Message}";
                }
                catch (Exception e)
                {
                    return $"Error: {e.Message}";
                }
                return "Companhia Aérea inativada com sucesso!";
            }
            return "Este CNPJ não consta na base de dados!";
        }
        private static string Modulo_Cadastro_CompanhiaAerea_Print()
        {
            char op = ' ';
            string msg = "";
            int i = 0;
            List<CompanhiaAerea> listaDeCompanhiaAereas;
            int listLenght;
            List<String> optionsList = new() { "Ir para o início", "Anterior", "Próximo", "Ir para o último", "Voltar" };
            char[] options = new char[optionsList.Count];
            options[optionsList.Count - 1] = '0';
            for (int j = 0; j < optionsList.Count - 1; j++) options[j] = char.Parse((j + 1).ToString());

            try
            {
                listaDeCompanhiaAereas = DataAcces.GetCompanhiaAerea();
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                return $"O banco de dados retornou o seguinte erro: {e.Message}";
            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }

            listLenght = listaDeCompanhiaAereas.Count;
            while (op != '0')
                Menus.ShowPrintMenu("REGISTROS DE COMPANHIAS AÉREAS", ref op, listaDeCompanhiaAereas[i].ToString(), listLenght, ref i, optionsList, options, ref msg);

            return "";
        }


        private static string Modulo_Cadastro_Aeronave()
        {
            throw new NotImplementedException();
        }

        private static string Modulo_Cadastro_Restritos()
        {
            throw new NotImplementedException();
        }

        private static string Modulo_Cadastro_Bloqueados()
        {
            throw new NotImplementedException();
        }

        //#endregion

        private static string Modulo_RegistroVoo()
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
                op = Utils.ReadString("Opção: ");
                if (!Utils.BuscarNoArray(op, options))
                {
                    msg = "Opção invalida! Digite novamente...";
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
            return msg;
        }

        private static string Modulo_VendaPassagem()
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
                op = Utils.ReadString("Opção: ");
                if (!Utils.BuscarNoArray(op, options))
                {
                    msg = "Opção invalida! Digite novamente...";
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
            return msg;
        }
    }
}