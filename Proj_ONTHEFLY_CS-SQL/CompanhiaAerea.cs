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
        public CompanhiaAerea(string cNPJ, string razaoSocial, DateTime dataAbertura)
        {
            CNPJ = cNPJ;
            RazaoSocial = razaoSocial;
            DataAbertura = dataAbertura;
        }
        public CompanhiaAerea(string cNPJ, char situacao)
        {
            CNPJ = cNPJ;
            Situacao = situacao;
        }
        public override string ToString()
        {
            return $"CPF:\t\t\t{CNPJ.Substring(0, 2)}.{CNPJ.Substring(2, 3)}.{CNPJ.Substring(5, 3)}/{CNPJ.Substring(8, 4)}-{CNPJ.Substring(12, 2)}\n" +
                    $"Razão Social:\t\t{RazaoSocial}\n" +
                    $"Data de Abertura:\t{DataAbertura:dd/MM/yyyy}\n" +
                    $"Ultimo Voo:\t\t{UltimoVoo:dd/MM/yyyy}\n" +
                    $"Data Cadastro:\t\t{DataCadastro:dd/MM/yyyy}";
        }
        public static bool FindKey(List<CompanhiaAerea> listaDeCompanhiaAereas, string cNPJ)
        {
            foreach (CompanhiaAerea companhiaAerea in listaDeCompanhiaAereas)
                if (companhiaAerea.CNPJ == cNPJ) return true;
            return false;
        }
    }
}
