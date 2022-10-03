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
            IdVoo = idVoo;
            Destino = destino;
            Aeronave = aeronave;
            AssentosOcupados = assentosOcupados;
            DataVoo = dataVoo;
            DataCadastro = dataCadastro;
            Situacao = situacao;
        }
        public Voo(string destino, string aeronave, int assentosOcupados, DateTime dataVoo, DateTime dataCadastro, char situacao)
        {
            Destino = destino;
            Aeronave = aeronave;
            AssentosOcupados = assentosOcupados;
            DataVoo = dataVoo;
            DataCadastro = dataCadastro;
            Situacao = situacao;
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
        public static string ReturnHeader() => "IdVoo;Destino;Aeronave;AssentosOcupados;DataVoo;DataCadastro\n";
        public override string ToString()
        {
            return String.Format("IdVoo:\t\t\tV{0:0000}\n", IdVoo) +
                    $"Destino:\t\t{Destino}\n" +
                    $"Aeronave:\t\t{Aeronave}\n" +
                    $"Assentos Ocupados:\t{AssentosOcupados}\n" +
                    $"Data Voo:\t\t{DataVoo:dd/MM/yyyy HH:mm}\n" +
                    $"Data Cadastro:\t\t{DataCadastro:dd/MM/yyyy}";
        }
        public static bool FindKey(List<Voo> listaDeVoos, int idVoo)
        {
            foreach (Voo voo in listaDeVoos)
            {
                if (voo.IdVoo == idVoo) return true;
            }
            return false;
        }
    }
}
