using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Proj_ONTHEFLY_CS_SQL
{
    public class DataAcces
    {
        //FUNCOES DE ACESSO A PASSAGEIRO
        public static List<Passageiro> GetPassageiro()
        {
            try
            {
                using IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONTHEFLYDB"));
                return connection.Query<Passageiro>("SELECT CPF, Nome, DataNascimento, Sexo, UltimaCompra, DataCadastro, Situacao FROM Passageiro p WHERE p.Situacao = 'A' ORDER BY Nome").ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void InsertPassageiro(Passageiro passageiro)
        {
            try
            {
                using IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONTHEFLYDB"));
                connection.Execute("INSERT INTO Passageiro VALUES (@CPF, @Nome, @DataNascimento, @Sexo, @UltimaCompra, @DataCadastro, @Situacao)", passageiro);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void UpdatePassageiro(Passageiro passageiro)
        {
            try
            {
                using IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONTHEFLYDB"));
                connection.Execute("UPDATE Passageiro SET Nome = @Nome, DataNascimento = @DataNascimento, Sexo = @Sexo WHERE CPF = @CPF", passageiro);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void UpdateFlipStatusPassageiro(Passageiro passageiro)
        {
            try
            {
                using IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONTHEFLYDB"));
                connection.Execute("UPDATE Passageiro SET Situacao = @Situacao WHERE CPF = @CPF", passageiro);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void UpdateUltimaCompraPassageiro(Passageiro passageiro)
        {
            try
            {
                using IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONTHEFLYDB"));
                connection.Execute("UPDATE Passageiro SET UltimaCompra = @UltimaCompra WHERE CPF = @CPF", passageiro);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //FUNCOES DE ACESSO A COMPANHIA AEREA
        public static List<CompanhiaAerea> GetCompanhiaAerea()
        {
            try
            {
                using IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONTHEFLYDB"));
                return connection.Query<CompanhiaAerea>("SELECT CNPJ, RazaoSocial, DataAbertura, UltimoVoo, DataCadastro, Situacao FROM CompanhiaAerea c WHERE c.Situacao = 'A' ORDER BY RazaoSocial").ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void InsertCompanhiaAerea(CompanhiaAerea companhiaAerea)
        {
            try
            {
                using IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONTHEFLYDB"));
                connection.Execute("INSERT INTO CompanhiaAerea VALUES (@CNPJ, @RazaoSocial, @DataAbertura, @UltimoVoo, @DataCadastro, @Situacao)", companhiaAerea);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void UpdateCompanhiaAerea(CompanhiaAerea companhiaAerea)
        {
            try
            {
                using IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONTHEFLYDB"));
                connection.Execute("UPDATE CompanhiaAerea SET RazaoSocial = @RazaoSocial, DataAbertura = @DataAbertura WHERE CNPJ = @CNPJ", companhiaAerea);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void UpdateFlipStatusCompanhiaAerea(CompanhiaAerea companhiaAerea)
        {
            try
            {
                using IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONTHEFLYDB"));
                connection.Execute("UPDATE CompanhiaAerea SET Situacao = @Situacao WHERE CNPJ = @CNPJ", companhiaAerea);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //FUNCOES DE ACESSO A AERONAVE
        public static List<Aeronave> GetAeronave()
        {
            try
            {
                using IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONTHEFLYDB"));
                return connection.Query<Aeronave>("SELECT Inscricao, Capacidade, UltimaVenda, DataCadastro, Situacao, CNPJCompanhia FROM Aeronave a WHERE a.Situacao = 'A'").ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void InsertAeronave(Aeronave aeronave)
        {
            try
            {
                using IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONTHEFLYDB"));
                connection.Execute("INSERT INTO Aeronave VALUES (@Inscricao, @Capacidade, @UltimaVenda, @DataCadastro, @Situacao, @CNPJCompanhia)", aeronave);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void UpdateAeronave(Aeronave aeronave)
        {
            try
            {
                using IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONTHEFLYDB"));
                connection.Execute("UPDATE Aeronave SET Capacidade = @Capacidade, CNPJCompanhia = @CNPJCompanhia WHERE Inscricao = @Inscricao", aeronave);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void UpdateFlipStatusAeronave(Aeronave aeronave)
        {
            try
            {
                using IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONTHEFLYDB"));
                connection.Execute("UPDATE Aeronave SET Situacao = @Situacao WHERE Inscricao= @Inscricao", aeronave);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void UpdateUltimaVendaAeronave(Aeronave aeronave)
        {
            try
            {
                using IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONTHEFLYDB"));
                connection.Execute("UPDATE Aeronave SET UltimaVenda = @UltimaVenda WHERE Inscricao = @Inscricao", aeronave);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //FUNCOES DE ACESSO A RESTRITOS
        public static List<Restritos> GetRestritos()
        {
            try
            {
                using IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONTHEFLYDB"));
                return connection.Query<Restritos>("SELECT CPF FROM Restritos").ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void InsertRestritos(Restritos restritos)
        {
            try
            {
                using IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONTHEFLYDB"));
                connection.Execute("INSERT INTO Restritos VALUES (@CPF)", restritos);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void DeleteRestritos(Restritos restritos)
        {
            try
            {
                using IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONTHEFLYDB"));
                connection.Execute("DELETE Restritos WHERE CPF = @CPF", restritos);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //FUNCOES DE ACESSO A BLOQUEADOS
        public static List<Bloqueados> GetBloqueados()
        {
            try
            {
                using IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONTHEFLYDB"));
                return connection.Query<Bloqueados>("SELECT CNPJ FROM Bloqueados").ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void InsertBloqueados(Bloqueados bloqueados)
        {
            try
            {
                using IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONTHEFLYDB"));
                connection.Execute("INSERT INTO Bloqueados VALUES (@CNPJ)", bloqueados);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void DeleteBloqueados(Bloqueados bloqueados)
        {
            try
            {
                using IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONTHEFLYDB"));
                connection.Execute("DELETE Bloqueados WHERE CNPJ = @CNPJ", bloqueados);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //FUNCOES DE ACESSO A VOO
        public static List<Voo> GetVoo()
        {
            try
            {
                using IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONTHEFLYDB"));
                return connection.Query<Voo>("SELECT IdVoo, Destino, Aeronave, AssentosOcupados, DataVoo, DataCadastro, Situacao FROM Voo v WHERE v.Situacao != 'I' ORDER BY IdVoo").ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void InsertVoo(Voo voo)
        {
            try
            {
                using IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONTHEFLYDB"));
                connection.Execute("INSERT INTO Voo VALUES (@Destino, @Aeronave, @AssentosOcupados, @DataVoo, @DataCadastro, @Situacao)", voo);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void UpdateVoo(Voo voo)
        {
            try
            {
                using IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONTHEFLYDB"));
                connection.Execute("UPDATE Voo SET Destino = @Destino, Aeronave = @Aeronave, DataVoo = @DataVoo WHERE IdVoo = @IdVoo", voo);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void UpdateFlipStatusVoo(Voo voo)
        {
            try
            {
                using IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONTHEFLYDB"));
                connection.Execute("UPDATE Voo SET Situacao = @Situacao WHERE IdVoo = @IdVoo", voo);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void UpdateAssentosOcupadosVoo(Voo voo)
        {
            try
            {
                using IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONTHEFLYDB"));
                connection.Execute("UPDATE Voo SET AssentosOcupados = @AssentosOcupados WHERE IdVoo = @IdVoo", voo);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //FUNCOES DE ACESSO A PASSAGEM
        public static List<PassagemVoo> GetPassagem()
        {
            try
            {
                using IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONTHEFLYDB"));
                return connection.Query<PassagemVoo>("SELECT IdPassagem, IdVoo, DataUltimaOperacao, Valor, Situacao FROM PassagemVoo ORDER BY IdPassagem").ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void InsertPassagemVoo(PassagemVoo passagem)
        {
            try
            {
                using IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONTHEFLYDB"));
                connection.Execute("INSERT INTO PassagemVoo VALUES (@IdPassagem, @IdVoo, @DataUltimaOperacao, @Valor, @Situacao)", passagem);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void UpdateStatusPassagem(PassagemVoo passagem)
        {
            try
            {
                using IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONTHEFLYDB"));
                connection.Execute("UPDATE PassagemVoo SET DataUltimaOperacao = @DataUltimaOperacao, Situacao = @Situacao WHERE IdPassagem = @IdPassagem AND IdVoo = @IdVoo", passagem);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //FUNCOES DE ACESSO A VENDA
        public static List<Venda> GetVenda()
        {
            try
            {
                using IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONTHEFLYDB"));
                return connection.Query<Venda>("SELECT IdVenda, DataVenda, Passageiro, ValorTotal FROM Venda ORDER BY IdVenda").ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void InsertVenda(Venda venda)
        {
            try
            {
                using IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONTHEFLYDB"));
                connection.Execute("INSERT INTO Venda VALUES (@DataVenda, @Passageiro, @ValorTotal)", venda);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void UpdateValueVenda(Venda venda)
        {
            try
            {
                using IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONTHEFLYDB"));
                connection.Execute("UPDATE Venda SET ValorTotal = @ValorTotal WHERE IdVenda= @IdVenda", venda);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //FUNCOES DE ACESSO A ITEMVENDA
        public static List<ItemVenda> GetItemVenda()
        {
            try
            {
                using IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONTHEFLYDB"));
                return connection.Query<ItemVenda>("SELECT IdVenda, IdPassagem, IdVoo FROM ItemVenda ORDER BY IdVenda").ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void InsertItemVenda(ItemVenda itemVenda)
        {
            try
            {
                using IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONTHEFLYDB"));
                connection.Execute("INSERT INTO ItemVenda VALUES (@IdVenda, @IdPassagem, @IdVoo)", itemVenda);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //FUNCOES DE ACESSO A DESTINO
        public static List<Destino> GetDestino()
        {
            try
            {
                using IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONTHEFLYDB"));
                return connection.Query<Destino>("SELECT IATA FROM Destino").ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}