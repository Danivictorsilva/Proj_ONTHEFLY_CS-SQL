using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_ONTHEFLY_CS_SQL
{
    public class Voo
    {
        //Propriedades
        public int IdVoo { get; set; }
        public string Destino { get; set; }
        public string Aeronave { get; set; }
        public int AssentosOcupados { get; set; }
        public DateTime DataVoo { get; set; }
        public DateTime DataCadastro { get; set; }
        public char Situacao { get; set; }

        //Metodos
        public Voo(int idVoo, string destino, string aeronave, int assentosOcupados, DateTime dataVoo, DateTime dataCadastro, char situacao)
        {
            IdVoo= idVoo;
            Destino= destino;
            Aeronave= aeronave;

            DataVoo= dataVoo;
            DataCadastro= dataCadastro;
            Situacao= situacao;
        }
        public Voo(int idVoo, string destino, string aeronave, DateTime dataVoo)
        {
            IdVoo = idVoo;
            Destino = destino;
            Aeronave = aeronave;
            DataVoo = dataVoo;
        }
        public Voo(int idVoo, char situacao)
        {
            IdVoo = idVoo;
            Situacao = situacao;
        }
        public string TopFormat()
        {
            return String.Format("{{'{0}';'{1}';'{2}';'{3}';'{4}';'{5}'}}",
                IdVoo, Destino, Aeronave, DataVoo, DataCadastro.ToShortDateString(), Situacao);
        }
        public static string ReturnHeader() => "IdVoo;Destino;Aeronave;DataVoo;DataCadastro;Situacao\n";
        public override string ToString()
        {
            return $"IdVoo:\t\t\t{CPF.Substring(0, 3)}.{CPF.Substring(3, 3)}.{CPF.Substring(6, 3)}-{CPF.Substring(9, 2)}\n" +
                    $"Destino:\t\t\t{Nome}\n" +
                    $"Aeronave:\t{DataNascimento:dd/MM/yyyy}\n" +
                    $"DataVoo:\t\t\t{Sexo}\n" +
                    $"Ultima Compra:\t\t{UltimaCompra:dd/MM/yyyy}\n" +
                    $"Data Cadastro:\t\t{DataCadastro:dd/MM/yyyy}";
        }
        public static bool FindKey(List<Passageiro> listaDePassageiros, string cPF)
        {
            foreach (Passageiro passageiro in listaDePassageiros)
            {
                if (passageiro.CPF == cPF) return true;
            }
            return false;
        }
    }
}
