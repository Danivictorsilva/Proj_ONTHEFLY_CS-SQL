using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_ONTHEFLY_CS_SQL
{
    public class Venda
    {
        //Propriedades
        public int IdVenda { get; set; }
        public DateTime DataVenda { get; set; }
        public string Passageiro { get; set; }
        public double ValorTotal { get; set; }

        //Metodos
        public Venda(int idVenda, DateTime dataVenda, string passageiro, double valorTotal)
        {
            IdVenda = idVenda;
            DataVenda = dataVenda;
            Passageiro = passageiro;
            ValorTotal = valorTotal;
        }
        public override string ToString()
        {
            return String.Format("{{'{0}';'{1}';'{2}';'{3}'}}",
                IdVenda, DataVenda.ToShortDateString(), Passageiro, ValorTotal);
        }
        public static string ReturnHeader() => "IdVenda;DataVenda;Passageiro;ValorTotal\n";
    }
}
