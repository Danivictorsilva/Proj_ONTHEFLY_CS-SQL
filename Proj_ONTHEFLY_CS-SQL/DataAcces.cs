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
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONTHEFLYDB")))
                {
                    return connection.Query<Passageiro>("SELECT CPF, Nome, DataNascimento, Sexo, UltimaCompra, DataCadastro, Situacao FROM Passageiro p WHERE p.Situacao = 'A' ORDER BY Nome").ToList();
                }
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
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONTHEFLYDB")))
                {
                    connection.Execute("INSERT INTO Passageiro VALUES (@CPF, @Nome, @DataNascimento, @Sexo, @UltimaCompra, @DataCadastro, @Situacao)", passageiro);
                }
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
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONTHEFLYDB")))
                {
                    connection.Execute("UPDATE Passageiro SET Nome = @Nome, DataNascimento = @DataNascimento, Sexo = @Sexo WHERE CPF = @CPF", passageiro);
                }
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
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONTHEFLYDB")))
                {
                    connection.Execute("UPDATE Passageiro SET Situacao = @Situacao WHERE CPF = @CPF", passageiro);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<CompanhiaAerea> GetCompanhiaAerea()
        {
            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONTHEFLYDB")))
                {
                    return connection.Query<CompanhiaAerea>("SELECT CNPJ, RazaoSocial, DataAbertura, UltimoVoo, DataCadastro, Situacao FROM CompanhiaAerea c WHERE c.Situacao = 'A' ORDER BY RazaoSocial").ToList();
                }
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
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONTHEFLYDB")))
                {
                    connection.Execute("INSERT INTO CompanhiaAerea VALUES (@CNPJ, @RazaoSocial, @DataAbertura, @UltimoVoo, @DataCadastro, @Situacao)", companhiaAerea);
                }
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
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONTHEFLYDB")))
                {
                    connection.Execute("UPDATE CompanhiaAerea SET RazaoSocial = @RazaoSocial, DataAbertura = @DataAbertura", companhiaAerea);
                }
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
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONTHEFLYDB")))
                {
                    connection.Execute("UPDATE CompanhiaAerea SET Situacao = @Situacao WHERE CNPJ = @CNPJ", companhiaAerea);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
