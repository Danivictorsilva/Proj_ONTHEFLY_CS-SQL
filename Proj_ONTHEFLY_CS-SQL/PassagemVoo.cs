using System;

namespace Proj_ONTHEFLY_CS_SQL
{
    public class PassagemVoo
    {
        //Propriedades
        public int IdPassagem { get; set; }
        public int IdVoo { get; set; }
        public DateTime DataUltimaOperacao { get; set; }
        public decimal Valor { get; set; }
        public char Situacao { get; set; }

        //Metodos
        public PassagemVoo(int idPassagem, int idVoo, DateTime dataUltimaOperacao, decimal valor, char situacao)
        {
            IdPassagem = idPassagem;
            IdVoo = idVoo;
            Valor = valor;
            DataUltimaOperacao = dataUltimaOperacao;
            Situacao = situacao;
        }
        public PassagemVoo(int idPassagem, DateTime dataUltimaOperacao, int idVoo, char situacao)
        {
            IdPassagem = idPassagem;
            IdVoo = idVoo;
            DataUltimaOperacao = dataUltimaOperacao;
            Situacao = situacao;
        }
    }
}
