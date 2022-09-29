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
        public Voo(int idVoo, string destino, string aeronave, DateTime dataVoo, DateTime dataCadastro, char situacao)
        {
            IdVoo= idVoo;
            Destino= destino;
            Aeronave= aeronave;
            DataVoo= dataVoo;
            DataCadastro= dataCadastro;
            Situacao= situacao;
        }
        public override string ToString()
        {
            return String.Format("{{'{0}';'{1}';'{2}';'{3}';'{4}';'{5}'}}",
                IdVoo, Destino, Aeronave, DataVoo, DataCadastro.ToShortDateString(), Situacao);
        }
        public static string ReturnHeader() => "IdVoo;Destino;Aeronave;DataVoo;DataCadastro;Situacao\n";
    }
}
