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
                op = Utils.ReadString("Opção: ");
                if (!Utils.BuscarNoArray(op, options))
                {
                    msg = "Opção invalida! Digite novamente...";
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
                "Cadastro de Passageiro",
                "Cadastro de Companhia Aérea",
                "Cadastro de Aeronave",
                "Cadastro de Restritos",
                "Cadastro de Bloqueados",
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
                op = Utils.ReadString("Opção: ");
                if (!Utils.BuscarNoArray(op, options))
                {
                    msg = "Opção invalida! Digite novamente...";
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
        // SUBMODULO CADASTRO PASSAGEIRO **************************************************************
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
                "Inativar Registro",
                "Visualizar Registros Ativos",
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
                op = Utils.ReadString("Opção: ");
                if (!Utils.BuscarNoArray(op, options))
                {
                    msg = "Opção invalida! Digite novamente...";
                    continue;
                }
                switch (op)
                {
                    case "1":
                        msg = Modulo_Cadastro_Passageiro_New();
                        break;
                    case "2":
                        msg = Modulo_Cadastro_Passageiro_Find();
                        break;
                    case "3":
                        msg = Modulo_Cadastro_Passageiro_Edit();
                        break;
                    case "4":
                        msg = Modulo_Cadastro_Passageiro_Idle();
                        break;
                    case "5":
                        msg = Modulo_Cadastro_Passageiro_Print();
                        break;
                    case "0":
                        msg = "";
                        break;
                }
            }
        }

        //FUNCOES CADASTRO PASSAGEIRO
        private static string Modulo_Cadastro_Passageiro_New()
        {
            List<Passageiro> listaDePassageiros;
            string cPF;
            string msg = "";

            try
            {
                listaDePassageiros = DataAcces.GetPassageiro();
            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }
            cPF = Utils.ReadString("Digite o CPF do passageiro (sem pontos ou traços): ");
            if (!Utils.ValidCPF(ref cPF, ref msg)) return msg;
            if (Passageiro.FindKey(listaDePassageiros, cPF)) return "Este CPF já consta na base de dados!";
            try
            {
                DataAcces.InsertPassageiro
                (
                    new Passageiro
                    (
                        cPF,
                        Utils.ReadString("Digite o Nome do passageiro: ").ToUpper(),
                        Utils.ReadDateTime("Digite a Data de Nascimento do passageiro (DD/MM/YYYY): "),
                        char.ToUpper(Utils.ReadChar("Digite o Sexo do passageiro\nM - Masculino\nF - Feminino\nN - Não deseja informar\nOpção: ")),
                        DateTime.Today,
                        DateTime.Today,
                        'A'
                    )
                );
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

            try
            {
                listaDePassageiros = DataAcces.GetPassageiro();
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
                    DataAcces.UpdatePassageiro
                    (
                        new Passageiro
                        (
                            cPF,
                            Utils.ReadString("Digite o novo Nome do passageiro: ").ToUpper(),
                            Utils.ReadDateTime("Digite a nova Data de Nascimento do passageiro (DD/MM/YYYY): "),
                            char.ToUpper(Utils.ReadChar("Digite o novo Sexo do passageiro\nM - Masculino\nF - Feminino\nN - Não deseja informar\nOpção: "))
                        )
                    );
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
            string op = "-1";
            string msg = "";
            string[] options = new string[] { "1", "2", "3", "4", "0" };
            int i = 0;
            List<Passageiro> listaDePassageiros;
            try
            {
                listaDePassageiros = DataAcces.GetPassageiro();
            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }

            while (op != "0")
            {
                Console.Clear();
                Console.WriteLine("*********REGISTROS DE PASSAGEIROS*********");
                Console.WriteLine(listaDePassageiros[i]);
                Console.WriteLine(">>> Qtde total de registros: {0}    /    Registro atual: {1}", listaDePassageiros.Count, i + 1);
                Console.WriteLine("\nInforme a operacao desejada: ");
                Console.WriteLine("1. Ir para o início");
                Console.WriteLine("2. Anterior");
                Console.WriteLine("3. Próximo");
                Console.WriteLine("4. Ir para o último");
                Console.WriteLine("0. Voltar");
                Console.Write("\n{0}{1}{2}", msg == "" ? "" : ">>> ", msg, msg == "" ? "" : "\n");
                op = Utils.ReadString("Opção: ");
                if (!Utils.BuscarNoArray(op, options))
                {
                    msg = "Opção inválida! Digite novamente...";
                    continue;
                }
                msg = "";
                switch (op)
                {
                    case "1":
                        i = 0;
                        break;
                    case "2":
                        if (i > 0) i--;
                        break;
                    case "3":
                        if (i < listaDePassageiros.Count - 1) i++;
                        break;
                    case "4":
                        i = listaDePassageiros.Count - 1;
                        break;
                    case "0":
                        break;
                }
            }
            return "";
        }


        // SUBMODULO CADASTRO COMPANHIA AEREA **************************************************************
        private static void Modulo_Cadastro_CompanhiaAerea()
        {
            //Declaracoes
            string op = "-1";
            string msg = "";
            List<String> optionsList = new()
            {
                "Cadastrar Novo",
                "Localizar Registro",
                "Editar Registro",
                "Inativar Registro",
                "Visualizar Registros Ativos",
                "Voltar"
            };
            string[] options = new string[optionsList.Count];

            //Programa Principal
            options[optionsList.Count - 1] = "0";
            for (int i = 0; i < optionsList.Count - 1; i++) options[i] = (i + 1).ToString();
            while (op != "0")
            {
                Console.Clear();
                Console.WriteLine("*********MODULO DE CADASTRO DE COMPANHIA AEREA*********");
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
                        msg = Modulo_Cadastro_CompanhiaAerea_New();
                        break;
                    case "2":
                        msg = Modulo_Cadastro_CompanhiaAerea_Find();
                        break;
                    case "3":
                        msg = Modulo_Cadastro_CompanhiaAerea_Edit();
                        break;
                    case "4":
                        msg = Modulo_Cadastro_CompanhiaAerea_Idle();
                        break;
                    case "5":
                        msg = Modulo_Cadastro_CompanhiaAerea_Print();
                        break;
                    case "0":
                        msg = "";
                        break;
                }
            }
        }
        private static string Modulo_Cadastro_CompanhiaAerea_New()
        {
            List<CompanhiaAerea> listaDeCompanhiaAereas;
            string cNPJ;
            string msg = "";

            try
            {
                listaDeCompanhiaAereas = DataAcces.GetCompanhiaAerea();
            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }
            cNPJ = Utils.ReadString("Digite o CNPJ da companhia aérea (sem pontos ou traços): ");
            if (!Utils.ValidCNPJ(ref cNPJ, ref msg)) return msg;
            if (CompanhiaAerea.FindKey(listaDeCompanhiaAereas, cNPJ)) return "Este CNPJ já consta na base de dados!";
            CompanhiaAerea companhiaAerea =
            new CompanhiaAerea
            (
                cNPJ,
                Utils.ReadString("Digite a Razão Social da companhia aérea: ").ToUpper(),
                Utils.ReadDateTime("Digite a Data de Abertura da companhia aérea (DD/MM/YYYY): "),
                DateTime.Today,
                DateTime.Today,
                'A'
            );
            if ((DateTime.Today - companhiaAerea.DataAbertura).Days < 180) return "Não é permitido cadastrar empresas com menos de 180 dias de operação!";
            try
            {
                DataAcces.InsertCompanhiaAerea(companhiaAerea);
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

            try
            {
                listaDeCompanhiaAereas = DataAcces.GetCompanhiaAerea();
            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }
            cNPJ = Utils.ReadString("Digite o CNPJ da companhia aérea (sem pontos ou traços): ");
            if (CompanhiaAerea.FindKey(listaDeCompanhiaAereas, cNPJ))
            {
                try
                {
                    DataAcces.UpdateCompanhiaAerea
                    (
                        new CompanhiaAerea
                        (
                            cNPJ,
                            Utils.ReadString("Digite a nova Razão Social da companhia aérea: ").ToUpper(),
                            Utils.ReadDateTime("Digite a nova Data de Nascimento do companhia aérea (DD/MM/YYYY): ")
                        )
                    );
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
            string op = "-1";
            string msg = "";
            string[] options = new string[] { "1", "2", "3", "4", "0" };
            int i = 0;
            List<CompanhiaAerea> listaDeCompanhiaAereas;
            try
            {
                listaDeCompanhiaAereas = DataAcces.GetCompanhiaAerea();
            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }

            while (op != "0")
            {
                Console.Clear();
                Console.WriteLine("*********REGISTROS DE PASSAGEIROS*********");
                Console.WriteLine(listaDeCompanhiaAereas[i]);
                Console.WriteLine(">>> Qtde total de registros: {0}    /    Registro atual: {1}", listaDeCompanhiaAereas.Count, i + 1);
                Console.WriteLine("\nInforme a operacao desejada: ");
                Console.WriteLine("1. Ir para o início");
                Console.WriteLine("2. Anterior");
                Console.WriteLine("3. Próximo");
                Console.WriteLine("4. Ir para o último");
                Console.WriteLine("0. Voltar");
                Console.Write("\n{0}{1}{2}", msg == "" ? "" : ">>> ", msg, msg == "" ? "" : "\n");
                op = Utils.ReadString("Opção: ");
                if (!Utils.BuscarNoArray(op, options))
                {
                    msg = "Opção inválida! Digite novamente...";
                    continue;
                }
                msg = "";
                switch (op)
                {
                    case "1":
                        i = 0;
                        break;
                    case "2":
                        if (i > 0) i--;
                        break;
                    case "3":
                        if (i < listaDeCompanhiaAereas.Count - 1) i++;
                        break;
                    case "4":
                        i = listaDeCompanhiaAereas.Count - 1;
                        break;
                    case "0":
                        break;
                }
            }
            return "";
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
        //#endregion

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
        }
    }
}