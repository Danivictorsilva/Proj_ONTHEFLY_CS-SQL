using System;
using System.Collections.Generic;

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

            cPF = Utils.ReadString("Digite o CPF do voo (sem pontos ou traços): ");
            if (!Utils.ValidCPF(ref cPF, ref msg)) return msg;
            Passageiro voo =
            new
            (
                cPF,
                Utils.ReadString("Digite o Nome do voo: ").ToUpper(),
                Utils.ReadDate("Digite a Data de Nascimento do voo (DD/MM/YYYY): "),
                Utils.ReadSexo("Digite o Sexo do voo\nM - Masculino\nF - Feminino\nN - Não deseja informar\nOpção: "),
                DateTime.Today,
                DateTime.Today,
                'A'
            );
            try
            {
                DataAcces.InsertPassageiro(voo);
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

            cPF = Utils.ReadString("Digite o CPF do voo (sem pontos ou traços): ");
            foreach (Passageiro voo in listaDePassageiros)
                if (voo.CPF == cPF) return $"\n{voo}\n";
            return "Este CPF não consta na base de dados!";
        }
        private static string Modulo_Cadastro_Passageiro_Edit()
        {
            List<Passageiro> listaDePassageiros;
            string cPF;
            Passageiro voo;

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

            cPF = Utils.ReadString("Digite o CPF do voo (sem pontos ou traços): ");
            if (Passageiro.FindKey(listaDePassageiros, cPF))
            {
                voo =
                new
                (
                    cPF,
                    Utils.ReadString("Digite o novo Nome do voo: ").ToUpper(),
                    Utils.ReadDate("Digite a nova Data de Nascimento do voo (DD/MM/YYYY): "),
                    char.ToUpper(Utils.ReadChar("Digite o novo Sexo do voo\nM - Masculino\nF - Feminino\nN - Não deseja informar\nOpção: "))
                );
                try
                {
                    DataAcces.UpdatePassageiro(voo);
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

            cPF = Utils.ReadString("Digite o CPF do voo (sem pontos ou traços): ");
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
            if (listLenght == 0) return "Nenhum registro consta na base de dados!";
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
                "Cadastrar Nova",
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
        //FUNCOES CADASTRO COMPANHIA AEREA
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
                Utils.ReadDate("Digite a Data de Abertura da companhia aérea (DD/MM/YYYY): "),
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
                    Utils.ReadDate("Digite a nova Data de Nascimento do companhia aérea (DD/MM/YYYY): ")
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
            if (listLenght == 0) return "Nenhum registro consta na base de dados!";
            while (op != '0')
                Menus.ShowPrintMenu("REGISTROS DE COMPANHIAS AÉREAS", ref op, listaDeCompanhiaAereas[i].ToString(), listLenght, ref i, optionsList, options, ref msg);

            return "";
        }

        // SUBMODULO CADASTRO AERONAVES **************************************************************
        private static string Modulo_Cadastro_Aeronave()
        {
            Menus.ShowFiveOptionsMenu
            (
                "MODULO DE CADASTRO DE AERONAVE",
                "Cadastrar Nova",
                "Localizar Registro",
                "Editar Registro",
                "Inativar Registro",
                "Visualizar Registros Ativos",
                Modulo_Cadastro_Aeronave_New,
                Modulo_Cadastro_Aeronave_Find,
                Modulo_Cadastro_Aeronave_Edit,
                Modulo_Cadastro_Aeronave_Idle,
                Modulo_Cadastro_Aeronave_Print
            );
            return "";
        }
        //FUNCOES CADASTRO AERONAVES
        private static string Modulo_Cadastro_Aeronave_New()
        {
            string inscricao;
            string msg = "";
            string cNPJCompanhia;
            int capacity;
            bool auxBool;

            cNPJCompanhia = Utils.ReadString("Digite o CNPJ da companhia aérea a qual a aeronave pertence (sem pontos ou traços): ");
            if (!Utils.ValidCNPJ(ref cNPJCompanhia, ref msg)) return msg;
            do
            {
                inscricao = Utils.ReadString("Digite o código de Inscrição da aeronave (6 dígitos): ");
                auxBool = inscricao.Length != 6;
                if (auxBool) Console.WriteLine("Opção inválida...");
            } while (auxBool);
            do
            {
                capacity = Utils.ReadInt("Digite a capacidade da aeronave (máximo 999 assentos): ");
                auxBool = capacity < 0 || capacity > 999;
                if (auxBool) Console.WriteLine("Opção inválida...");
            } while (auxBool);
            Aeronave aeronave =
            new
            (
                inscricao.ToUpper(),
                capacity,
                DateTime.Today,
                DateTime.Today,
                'A',
                cNPJCompanhia
            );

            try
            {
                DataAcces.InsertAeronave(aeronave);
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
        private static string Modulo_Cadastro_Aeronave_Find()
        {
            List<Aeronave> listaDeAeronaves;
            string inscricao;

            try
            {
                listaDeAeronaves = DataAcces.GetAeronave();
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                return $"O banco de dados retornou o seguinte erro: {e.Message}";
            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }

            inscricao = Utils.ReadString("Digite o código de Inscrição da aeronave (6 dígitos): ").ToUpper();
            foreach (Aeronave aeronave in listaDeAeronaves)
                if (aeronave.Inscricao == inscricao) return $"\n{aeronave}\n";
            return "Esta Aeronave não consta na base de dados!";
        }
        private static string Modulo_Cadastro_Aeronave_Edit()
        {
            List<Aeronave> listaDeAeronaves;
            string inscricao;
            Aeronave aeronave;
            int capacity;
            bool auxBool;
            string cNPJCompanhia;
            string msg = "";

            try
            {
                listaDeAeronaves = DataAcces.GetAeronave();
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                return $"O banco de dados retornou o seguinte erro: {e.Message}";
            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }

            inscricao = Utils.ReadString("Digite o código de Inscrição da aeronave (6 dígitos): ").ToUpper();
            if (Aeronave.FindKey(listaDeAeronaves, inscricao))
            {
                do
                {
                    capacity = Utils.ReadInt("Digite a nova capacidade da aeronave (máximo 999 assentos): ");
                    auxBool = capacity < 0 || capacity > 999;
                    if (auxBool) Console.WriteLine("Opção inválida...");
                } while (auxBool);
                cNPJCompanhia = Utils.ReadString("Digite o CNPJ da companhia aérea a qual a aeronave pertence (sem pontos ou traços): ");
                if (!Utils.ValidCNPJ(ref cNPJCompanhia, ref msg)) return msg;
                aeronave =
                new
                (
                    inscricao,
                    capacity,
                    cNPJCompanhia
                );
                try
                {
                    DataAcces.UpdateAeronave(aeronave);
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
            return "Esta Inscrição não consta na base de dados!";
        }
        private static string Modulo_Cadastro_Aeronave_Idle()
        {
            List<Aeronave> listaDeAeronaves;
            string inscricao;

            try
            {
                listaDeAeronaves = DataAcces.GetAeronave();
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                return $"O banco de dados retornou o seguinte erro: {e.Message}";
            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }

            inscricao = Utils.ReadString("Digite o código de Inscrição da aeronave (6 dígitos): ").ToUpper();
            if (Aeronave.FindKey(listaDeAeronaves, inscricao))
            {
                try
                {
                    DataAcces.UpdateFlipStatusAeronave(new Aeronave(inscricao, 'I'));
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    return $"O banco de dados retornou o seguinte erro: {e.Message}";
                }
                catch (Exception e)
                {
                    return $"Error: {e.Message}";
                }
                return "Aeronave inativada com sucesso!";
            }
            return "Esta Inscrição não consta na base de dados!";
        }
        private static string Modulo_Cadastro_Aeronave_Print()
        {
            char op = ' ';
            string msg = "";
            int i = 0;
            List<Aeronave> listaDeAeronaves;
            int listLenght;
            List<String> optionsList = new() { "Ir para o início", "Anterior", "Próximo", "Ir para o último", "Voltar" };
            char[] options = new char[optionsList.Count];
            options[optionsList.Count - 1] = '0';
            for (int j = 0; j < optionsList.Count - 1; j++) options[j] = char.Parse((j + 1).ToString());

            try
            {
                listaDeAeronaves = DataAcces.GetAeronave();
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                return $"O banco de dados retornou o seguinte erro: {e.Message}";
            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }
            listLenght = listaDeAeronaves.Count;
            if (listLenght == 0) return "Nenhum registro consta na base de dados!";
            while (op != '0')
                Menus.ShowPrintMenu("REGISTROS DE AERONAVES", ref op, listaDeAeronaves[i].ToString(), listLenght, ref i, optionsList, options, ref msg);

            return "";
        }

        // SUBMODULO CADASTRO RESTRITOS **************************************************************
        private static string Modulo_Cadastro_Restritos()
        {
            Menus.ShowThreeOptionsMenu
            (
                "MODULO DE CADASTRO DE CPFs RESTRITOS",
                "Cadastrar Novo",
                "Localizar Registro",
                "Deletar Registro",
                Modulo_Cadastro_Restritos_New,
                Modulo_Cadastro_Restritos_Find,
                Modulo_Cadastro_Restritos_Delete
            );
            return "";
        }
        //FUNCOES CADASTRO RESTRITOS
        private static string Modulo_Cadastro_Restritos_New()
        {
            string cPF;
            string msg = "";

            cPF = Utils.ReadString("Digite o CPF restrito (sem pontos ou traços): ");
            if (!Utils.ValidCPF(ref cPF, ref msg)) return msg;
            Restritos restritos = new(cPF);
            try
            {
                DataAcces.InsertRestritos(restritos);
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
        private static string Modulo_Cadastro_Restritos_Find()
        {
            List<Restritos> listaDeRestritos;
            string cPF;

            try
            {
                listaDeRestritos = DataAcces.GetRestritos();
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                return $"O banco de dados retornou o seguinte erro: {e.Message}";
            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }

            cPF = Utils.ReadString("Digite o CPF do restrito (sem pontos ou traços): ");
            if (Restritos.FindKey(listaDeRestritos, cPF)) return "Este CPF consta como restrito.";
            return "Este CPF não consta como restrito.";
        }
        private static string Modulo_Cadastro_Restritos_Delete()
        {
            List<Restritos> listaDeRestritos;
            string cPF;

            try
            {
                listaDeRestritos = DataAcces.GetRestritos();
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                return $"O banco de dados retornou o seguinte erro: {e.Message}";
            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }

            cPF = Utils.ReadString("Digite o CPF do restrito (sem pontos ou traços): ");
            if (Restritos.FindKey(listaDeRestritos, cPF))
            {
                try
                {
                    DataAcces.DeleteRestritos(new Restritos(cPF));
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    return $"O banco de dados retornou o seguinte erro: {e.Message}";
                }
                catch (Exception e)
                {
                    return $"Error: {e.Message}";
                }
                return "O CPF não consta mais como restrito!";
            }
            return "Este CPF não consta como restrito!";
        }
        // SUBMODULO CADASTRO BLOQUEADOS **************************************************************
        private static string Modulo_Cadastro_Bloqueados()
        {
            Menus.ShowThreeOptionsMenu
            (
                "MODULO DE CADASTRO DE CNPJs BLOQUEADOS",
                "Cadastrar Novo",
                "Localizar Registro",
                "Deletar Registro",
                Modulo_Cadastro_Bloqueados_New,
                Modulo_Cadastro_Bloqueados_Find,
                Modulo_Cadastro_Bloqueados_Delete
            );
            return "";
        }
        //FUNCOES CADASTRO BLOQUEADOS
        private static string Modulo_Cadastro_Bloqueados_New()
        {
            string cNPJ;
            string msg = "";

            cNPJ = Utils.ReadString("Digite o CNPJ bloqueado (sem pontos ou traços): ");
            if (!Utils.ValidCNPJ(ref cNPJ, ref msg)) return msg;
            Bloqueados bloqueados = new(cNPJ);
            try
            {
                DataAcces.InsertBloqueados(bloqueados);
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
        private static string Modulo_Cadastro_Bloqueados_Find()
        {
            List<Bloqueados> listaDeBloqueados;
            string cNPJ;

            try
            {
                listaDeBloqueados = DataAcces.GetBloqueados();
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                return $"O banco de dados retornou o seguinte erro: {e.Message}";
            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }

            cNPJ = Utils.ReadString("Digite o CNPJ do bloqueado (sem pontos ou traços): ");
            if (Bloqueados.FindKey(listaDeBloqueados, cNPJ)) return "Este CNPJ consta como bloqueado.";
            return "Este CNPJ não consta como bloqueado.";
        }
        private static string Modulo_Cadastro_Bloqueados_Delete()
        {
            List<Bloqueados> listaDeBloqueados;
            string cNPJ;

            try
            {
                listaDeBloqueados = DataAcces.GetBloqueados();
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                return $"O banco de dados retornou o seguinte erro: {e.Message}";
            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }

            cNPJ = Utils.ReadString("Digite o CNPJ do bloqueado (sem pontos ou traços): ");
            if (Bloqueados.FindKey(listaDeBloqueados, cNPJ))
            {
                try
                {
                    DataAcces.DeleteBloqueados(new Bloqueados(cNPJ));
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    return $"O banco de dados retornou o seguinte erro: {e.Message}";
                }
                catch (Exception e)
                {
                    return $"Error: {e.Message}";
                }
                return "O CNPJ não consta mais como bloqueado!";
            }
            return "Este CNPJ não consta como bloqueado!";
        }
        // MODULO REGISTRO DE VOO **************************************************************
        private static string Modulo_RegistroVoo()
        {
            Menus.ShowFiveOptionsMenu
            (
                "MODULO DE REGISTRO DE VOO",
                "Cadastrar Novo",
                "Localizar Registro",
                "Editar Registro",
                "Inativar Registro",
                "Visualizar Registros Ativos",
                Modulo_RegistroVoo_New,
                Modulo_RegistroVoo_Find,
                Modulo_RegistroVoo_Edit,
                Modulo_RegistroVoo_Idle,
                Modulo_RegistroVoo_Print
            );
            return "";
        }
        //FUNCOES 
        private static string Modulo_RegistroVoo_New()
        {
            List<Aeronave> listaDeAeronaves;
            List<Bloqueados> listaDeBloqueados;
            List<CompanhiaAerea> listaDeCompanhiaAereas;
            List<Voo> listaDeVoos;
            int capacity = 0;
            decimal precoPassagem;
            bool auxBool;
            int idVoo;

            try
            {
                listaDeAeronaves = DataAcces.GetAeronave();
                listaDeBloqueados = DataAcces.GetBloqueados();
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

            Voo voo =
            new
            (
                Utils.ReadString("Digite o código IATA do Destino do voo: ").ToUpper(),
                Utils.ReadString("Digite o código da Aeronave do voo: ").ToUpper(),
                0,
                Utils.ReadDateAndTime("Digite a Data e Hora do voo (DD/MM/YYYY hh:mm): "),
                DateTime.Today,
                'A'
            );
            foreach (Aeronave aeronave in listaDeAeronaves)
                if (voo.Aeronave == aeronave.Inscricao)
                {
                    if (!CompanhiaAerea.FindKey(listaDeCompanhiaAereas, aeronave.CNPJCompanhia)) return "A companhia aérea proprietária da aeronave não consta na base de dados!";
                    foreach (Bloqueados bloqueado in listaDeBloqueados)
                        if (bloqueado.CNPJ == aeronave.CNPJCompanhia)
                            return "A companhia aérea proprietária da aeronave consta como bloqueada. Não é possível continuar com o cadastro do voo!";

                }

            if (voo.DataVoo < voo.DataCadastro) return "Data do voo é inválida!";
            try
            {
                DataAcces.InsertVoo(voo);
                listaDeVoos = DataAcces.GetVoo();
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                return $"O banco de dados retornou o seguinte erro: {e.Message}";
            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }

            idVoo = listaDeVoos[listaDeVoos.Count - 1].IdVoo;

            foreach (Aeronave aeronave in listaDeAeronaves)
                if (aeronave.Inscricao == voo.Aeronave)
                    capacity = aeronave.Capacidade;

            do
            {
                precoPassagem = Utils.ReadDecimal("Digite o valor das passagens desse voo (máximo 9.999,99): ");
                auxBool = precoPassagem < 0M || precoPassagem > 9999.99M;
                if (auxBool) Console.WriteLine("Opção inválida...");
            } while (auxBool);

            for (int i = 0; i < capacity; i++)
            {
                try
                {
                    DataAcces.InsertPassagemVoo(new PassagemVoo(i + 1, idVoo, DateTime.Today, precoPassagem, 'L'));
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    return $"O banco de dados retornou o seguinte erro: {e.Message}";
                }
                catch (Exception e)
                {
                    return $"Error: {e.Message}";
                }
            }

            return "Voo cadastrado com sucesso!";
        }
        private static string Modulo_RegistroVoo_Find()
        {
            List<Voo> listaDeVoos;
            int idVoo;

            try
            {
                listaDeVoos = DataAcces.GetVoo();
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                return $"O banco de dados retornou o seguinte erro: {e.Message}";
            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }

            idVoo = Utils.ReadInt("Digite o código de Identificação do voo (apenas números): V");
            foreach (Voo voo in listaDeVoos)
                if (voo.IdVoo == idVoo) return $"\n{voo}\n";
            return "Este voo não consta na base de dados!";
        }
        private static string Modulo_RegistroVoo_Edit()
        {
            List<Voo> listaDeVoos;
            int idVoo;
            Voo voo;

            try
            {
                listaDeVoos = DataAcces.GetVoo();
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                return $"O banco de dados retornou o seguinte erro: {e.Message}";
            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }

            idVoo = Utils.ReadInt("Digite o código de Identificação do voo (apenas números): V");
            if (Voo.FindKey(listaDeVoos, idVoo))
            {
                voo =
                new
                (
                    idVoo,
                    Utils.ReadString("Digite o novo Destino do voo: ").ToUpper(),
                    Utils.ReadString("Digite o novo código da Aeronave do voo: ").ToUpper(),
                    Utils.ReadDateAndTime("Digite a nova Data e Hora do voo (DD/MM/YYYY hh:mm): ")
                );
                try
                {
                    DataAcces.UpdateVoo(voo);
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
            return "Este Voo não consta na base de dados!";
        }
        private static string Modulo_RegistroVoo_Idle()
        {
            List<Voo> listaDeVoos;
            int idVoo;

            try
            {
                listaDeVoos = DataAcces.GetVoo();
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                return $"O banco de dados retornou o seguinte erro: {e.Message}";
            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }

            idVoo = Utils.ReadInt("Digite o código de Identificação do voo (apenas números): V");
            if (Voo.FindKey(listaDeVoos, idVoo))
            {
                try
                {
                    DataAcces.UpdateFlipStatusVoo(new Voo(idVoo, 'I'));
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    return $"O banco de dados retornou o seguinte erro: {e.Message}";
                }
                catch (Exception e)
                {
                    return $"Error: {e.Message}";
                }
                return "Voo inativado com sucesso!";
            }
            return "Este Voo não consta na base de dados!";
        }
        private static string Modulo_RegistroVoo_Print()
        {
            char op = ' ';
            string msg = "";
            int i = 0;
            List<Voo> listaDeVoos;
            int listLenght;
            List<String> optionsList = new() { "Ir para o início", "Anterior", "Próximo", "Ir para o último", "Voltar" };
            char[] options = new char[optionsList.Count];
            options[optionsList.Count - 1] = '0';
            for (int j = 0; j < optionsList.Count - 1; j++) options[j] = char.Parse((j + 1).ToString());

            try
            {
                listaDeVoos = DataAcces.GetVoo();
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                return $"O banco de dados retornou o seguinte erro: {e.Message}";
            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }

            listLenght = listaDeVoos.Count;
            if (listLenght == 0) return "Nenhum registro consta na base de dados!";
            while (op != '0')
                Menus.ShowPrintMenu("REGISTROS DE VOOS", ref op, listaDeVoos[i].ToString(), listLenght, ref i, optionsList, options, ref msg);

            return "";
        }

        private static string Modulo_VendaPassagem()
        {
            Menus.ShowFourOptionsMenu
            (
                "MODULO DE VENDAS DE PASSAGEM",
                "Visualizar Próximos Voos Para Um Destino",
                "Cadastrar Nova Venda",
                "Localizar Registro de Venda",
                "Visualizar Registros de Venda",
                Modulo_VendaPassagem_Voos,
                Modulo_VendaPassagem_New,
                Modulo_VendaPassagem_Find,
                Modulo_VendaPassagem_Print
            );

            return "";
        }
        private static string Modulo_VendaPassagem_Voos()
        {
            List<Voo> listaDeVoos;
            List<Destino> listaDeDestinos;
            string destino;
            string msg = "";

            try
            {
                listaDeVoos = DataAcces.GetVoo();
                listaDeDestinos = DataAcces.GetDestino();
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                return $"O banco de dados retornou o seguinte erro: {e.Message}";
            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }

            destino = Utils.ReadString("Digite o código IATA do aeroporto de Destino do voo: ").ToUpper();
            if (Destino.FindKey(listaDeDestinos, destino))
            {
                msg += "\n" + Voo.ReturnHeader();
                foreach (Voo voo in listaDeVoos)
                    if (voo.Destino == destino)
                        msg += voo.TopFormat() + "\n";
                return msg;
            }
            return "Este aeroporto não consta na base de dados!";
        }
        private static string Modulo_VendaPassagem_New()
        {
            List<Passageiro> listaDePassageiros;
            List<Voo> listaDeVoos;
            List<Venda> listaDeVendas;
            List<Aeronave> listaDeAeronaves;
            List<PassagemVoo> listaDePassagens;
            List<Restritos> listaDeRestritos;
            ItemVenda itemVenda;
            Voo v = new();
            string cPF, inscricao = "";
            int i = 0, idVoo, idVenda, idPassagem = 0, passagensLivres = 0;
            decimal valorPassagem = 0;
            decimal totalValue = 0;
            int auxInt;
            bool auxBool;

            try
            {
                listaDePassageiros = DataAcces.GetPassageiro();
                listaDeVoos = DataAcces.GetVoo();
                listaDeAeronaves = DataAcces.GetAeronave();
                listaDePassagens = DataAcces.GetPassagem();
                listaDeRestritos = DataAcces.GetRestritos();
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                return $"O banco de dados retornou o seguinte erro: {e.Message}";
            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }

            cPF = Utils.ReadString("Digite o CPF do passageiro para qual será realizada a venda (sem pontos ou traços): ");
            if (!Passageiro.FindKey(listaDePassageiros, cPF)) return "Este CPF não consta na base de dados!";
            foreach (Passageiro passageiro in listaDePassageiros)
                if (passageiro.CPF == cPF)
                {
                    if ((DateTime.Today - passageiro.DataNascimento.AddYears(18)).Days < 0)
                        return "Não é permitido vender para menores de 18 anos!";
                    Console.WriteLine($"{passageiro}\nConfirme as informações do passageiro acima descritas.");
                    break;
                }
            foreach (Restritos restritos in listaDeRestritos)
                if (restritos.CPF == cPF)
                    return "Este CPF consta como restrito. Não é possível continuar com a venda!";

            Venda venda = new(DateTime.Today, cPF, 0);

            try
            {
                DataAcces.InsertVenda(venda);
                listaDeVendas = DataAcces.GetVenda();
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                return $"O banco de dados retornou o seguinte erro: {e.Message}";
            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }

            idVenda = listaDeVendas[^1].IdVenda;

            while (i < 4)
            {
                Console.Clear();
                idVoo = Utils.ReadInt("Digite o código de Identificação do voo (apenas números): V");
                if (!Voo.FindKey(listaDeVoos, idVoo))
                {
                    Console.WriteLine("Este voo não consta na base de dados! Digite novamente...");
                    continue;
                }
                foreach (Voo voo in listaDeVoos)
                    if (voo.IdVoo == idVoo)
                    {
                        foreach (Aeronave aeronave in listaDeAeronaves)
                            if (voo.Aeronave == aeronave.Inscricao)
                            {
                                inscricao = aeronave.Inscricao;
                                passagensLivres = aeronave.Capacidade - voo.AssentosOcupados;
                                break;
                            }
                        v = voo;
                        break;
                    }
                if (passagensLivres < 0)
                {
                    Console.WriteLine("Não há mais passagens livres para esse voo!");
                    continue;
                }
                foreach (PassagemVoo passagem in listaDePassagens)
                    if (passagem.IdVoo == idVoo)
                    {
                        valorPassagem = passagem.Valor;
                        break;
                    }
                do
                {
                    auxInt = Utils.ReadInt(String.Format("Digite a quantidade de passagens do voo V{0:0000} (máximo {1}): ", idVoo, 4 - i));
                    auxBool = auxInt < 0 || auxInt > (4 - i);
                    if (auxBool) Console.WriteLine("Opção inválida...");
                } while (auxBool);

                for (int j = 0; j < auxInt; j++)
                {
                    foreach (PassagemVoo passagem in listaDePassagens)
                        if (passagem.IdVoo == idVoo && passagem.Situacao == 'L')
                        {
                            idPassagem = passagem.IdPassagem;
                            break;
                        }
                    itemVenda = new(idVenda, idPassagem, idVoo);
                    try
                    {
                        DataAcces.InsertItemVenda(itemVenda);
                        DataAcces.UpdateStatusPassagem(new PassagemVoo(idPassagem, DateTime.Today, idVoo, 'P'));
                        listaDePassagens = DataAcces.GetPassagem();
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        return $"O banco de dados retornou o seguinte erro: {e.Message}";
                    }
                    catch (Exception e)
                    {
                        return $"Error: {e.Message}";
                    }
                    totalValue += valorPassagem;
                    DataAcces.UpdateUltimaVendaAeronave(new Aeronave(inscricao, DateTime.Today));
                }
                DataAcces.UpdateAssentosOcupadosVoo(new Voo(idVoo, v.AssentosOcupados + auxInt));
                i += auxInt;
                if (char.ToUpper(Utils.ReadChar("Pressione 'S' para finalizar a venda e sair ou qualquer outra tecla para continuar: ")) == 'S') break;

            }
            DataAcces.UpdateUltimaCompraPassageiro(new Passageiro(cPF, DateTime.Today));
            DataAcces.UpdateValueVenda(new Venda(idVenda, totalValue));
            return "Venda realizada com sucesso!";
        }
        private static string Modulo_VendaPassagem_Find()
        {
            List<Venda> listaDeVendas;
            List<ItemVenda> listaDeItemVenda;
            int idVenda;
            string msg = "";

            try
            {
                listaDeVendas = DataAcces.GetVenda();
                listaDeItemVenda = DataAcces.GetItemVenda();
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                return $"O banco de dados retornou o seguinte erro: {e.Message}";
            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }

            idVenda = Utils.ReadInt("Digite o código de Identificação da venda (apenas números): ");
            foreach (Venda venda in listaDeVendas)
                if (venda.IdVenda == idVenda)
                {
                    msg += $"\n{venda}\n\nITENS DA VENDA:\n{ItemVenda.ReturnHeader()}";
                    foreach (ItemVenda itemVenda in listaDeItemVenda)
                    {
                        if (venda.IdVenda == itemVenda.IdVenda)
                            msg += itemVenda.TopFormat() +"\n";
                    }
                    return msg;
                }
            return "Este venda não consta na base de dados!";
        }
        private static string Modulo_VendaPassagem_Print()
        {
            char op = ' ';
            string msg = "";
            int i = 0;
            List<Venda> listaDeVendas;
            int listLenght;
            List<String> optionsList = new() { "Ir para o início", "Anterior", "Próximo", "Ir para o último", "Voltar" };
            char[] options = new char[optionsList.Count];
            options[optionsList.Count - 1] = '0';
            for (int j = 0; j < optionsList.Count - 1; j++) options[j] = char.Parse((j + 1).ToString());

            try
            {
                listaDeVendas = DataAcces.GetVenda();
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                return $"O banco de dados retornou o seguinte erro: {e.Message}";
            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }

            listLenght = listaDeVendas.Count;
            if (listLenght == 0) return "Nenhum registro consta na base de dados!";
            while (op != '0')
                Menus.ShowPrintMenu("REGISTROS DE VOOS", ref op, listaDeVendas[i].ToString(), listLenght, ref i, optionsList, options, ref msg);

            return "";
        }
    }
}