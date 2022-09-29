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
        public override string ToString()
        {
            return String.Format("{{'{0}';'{1}';'{2}';'{3}';'{4}';'{5}'}}",
                Inscricao, Capacidade, UltimaVenda.ToShortDateString(), DataCadastro.ToShortDateString(), Situacao, CNPJCompanhia);
        }
        public static string ReturnHeader() => "Inscricao;Capacidade;UltimaVenda;DataCadastro;Situacao;CNPJCompanhia\n";
    }
}
