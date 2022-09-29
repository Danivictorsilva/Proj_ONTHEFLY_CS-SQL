using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Proj_ONTHEFLY_CS_SQL
{
    public class DataAcces
    {
        public static List<Passageiro> GetPassageiro()
        {
            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONTHEFLYDB")))
                {
                    return connection.Query<Passageiro>("SELECT CPF, Nome, DataNascimento, Sexo, UltimaCompra, DataCadastro, Situacao FROM Passageiro").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
