using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_ONTHEFLY_CS_SQL
{
    public class PassagemVoo
    {
        //Propriedades
        public int IdPassagem { get; set; }
        public int IdVoo { get; set; }
        public DateTime DataUltimaOperacao { get; set; }
        public double Valor { get; set; }
        public char Situacao { get; set; }

        //Metodos
        public PassagemVoo(int idPassagem, int idVoo, DateTime dataUltimaOperacao, double valor, char situacao)
        {
            IdPassagem = idPassagem;
            IdVoo = idVoo;
            Valor = valor;
            DataUltimaOperacao = dataUltimaOperacao;
            Situacao = situacao;
        }
        public override string ToString()
        {
            return String.Format("{{'{0}';'{1}';'{2}';'{3}';'{4}'}}",
                IdPassagem, IdVoo, DataUltimaOperacao.ToShortDateString(), Valor, Situacao);
        }
        public static string ReturnHeader() => "IdPassagem;IdVoo;DataUltimaOperacao;Valor;Situacao\n";
    }
}
