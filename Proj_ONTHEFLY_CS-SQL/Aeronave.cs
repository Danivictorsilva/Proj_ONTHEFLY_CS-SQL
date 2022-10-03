using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_ONTHEFLY_CS_SQL
{
    public class Aeronave
    {
        //Propriedades
        public string Inscricao { get; set; }
        public int Capacidade { get; set; }
        public DateTime UltimaVenda { get; set; }
        public DateTime DataCadastro { get; set; }
        public char Situacao { get; set; }
        public string CNPJCompanhia { get; set; }

        //Metodos
        public Aeronave(string inscricao, int capacidade, DateTime ultimaVenda, DateTime dataCadastro, char situacao, string cNPJCompanhia)
        {
            Inscricao = inscricao;
            Capacidade = capacidade;
            UltimaVenda = ultimaVenda;
            DataCadastro = dataCadastro;
            Situacao = situacao;
            CNPJCompanhia = cNPJCompanhia;
        }
        public Aeronave(string inscricao, int capacidade, string cNPJCompanhia)
        {
            Inscricao = inscricao;
            Capacidade = capacidade;
            CNPJCompanhia = cNPJCompanhia;
        }
        public Aeronave(string incricao, char situacao)
        {
            Inscricao = incricao;
            Situacao = situacao;
        }
        public override string ToString()
        {
            return $"Inscrição:\t\t{Inscricao}\n" +
                    $"Capacidade:\t\t{Capacidade}\n" +
                    $"Última Venda:\t\t{UltimaVenda:dd/MM/yyyy}\n" +
                    $"Data Cadastro:\t\t{DataCadastro:dd/MM/yyyy}\n" +
                    $"CNPJ Companhia Aérea:\t{CNPJCompanhia.Substring(0, 2)}.{CNPJCompanhia.Substring(2, 3)}.{CNPJCompanhia.Substring(5, 3)}/{CNPJCompanhia.Substring(8, 4)}-{CNPJCompanhia.Substring(12, 2)}";
        }
        public static bool FindKey(List<Aeronave> listaDeAeronaves, string incricao)
        {
            foreach (Aeronave aeronave in listaDeAeronaves)
            {
                if (aeronave.Inscricao == incricao) return true;
            }
            return false;
        }
    }
}
