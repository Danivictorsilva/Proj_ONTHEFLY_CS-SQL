using System;

namespace Proj_ONTHEFLY_CS_SQL
{
    public class Passageiro
    {
        //Propriedades
        public string CPF { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public char Sexo { get; set; }
        public DateTime UltimaCompra { get; set; }
        public DateTime DataCadastro { get; set; }
        public char Situacao { get; set; }

        //Metodos
        public Passageiro(string cPF, string nome, DateTime dataNascimento, char sexo, DateTime ultimaCompra, DateTime dataCadastro, char situacao)
        {
            CPF = cPF;
            Nome = nome;
            DataNascimento = dataNascimento;
            Sexo = sexo;
            UltimaCompra = ultimaCompra;
            DataCadastro = dataCadastro;
            Situacao = situacao;
        }
        public override string ToString()
        {
            return String.Format("{{'{0}';'{1}';'{2}';'{3}';'{4}';'{5}';'{6}'}}",
                CPF, Nome, DataNascimento.ToShortDateString(), Sexo, UltimaCompra.ToShortDateString(), DataCadastro.ToShortDateString(), Situacao);
        }
        public static string ReturnHeader() => "CPF;Nome;DataNascimento;Sexo;UltimaCompra;DataCadastro;Situacao\n";
    }
}
