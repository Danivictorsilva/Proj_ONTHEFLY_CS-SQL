using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_ONTHEFLY_CS_SQL
{
    public class CompanhiaAerea
    {
        //Propriedades
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime UltimoVoo { get; set; }
        public DateTime DataCadastro { get; set; }
        public char Situacao { get; set; }

        //Metodos
        public CompanhiaAerea(string cNPJ, string razaoSocial, DateTime dataAbertura, DateTime ultimoVoo, DateTime dataCadastro, char situacao)
        {
            CNPJ = cNPJ;
            RazaoSocial = razaoSocial;
            DataAbertura = dataAbertura;
            UltimoVoo = ultimoVoo;
            DataCadastro = dataCadastro;
            Situacao = situacao;
        }
        public override string ToString()
        {
            return String.Format("{{'{0}';'{1}';'{2}';'{3}';'{4}';'{5}'}}",
                CNPJ, RazaoSocial, DataAbertura.ToShortDateString(), UltimoVoo.ToShortDateString(), DataCadastro.ToShortDateString(), Situacao);
        }
        public static string ReturnHeader() => "CNPJ;RazaoSocial;DataAbertura;UltimoVoo;DataCadastro;Situacao\n";

    }
}
