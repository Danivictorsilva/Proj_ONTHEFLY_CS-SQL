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
        public decimal ValorTotal { get; set; }

        //Metodos
        public Venda(int idVenda, DateTime dataVenda, string passageiro, decimal valorTotal)
        {
            IdVenda = idVenda;
            DataVenda = dataVenda;
            Passageiro = passageiro;
            ValorTotal = valorTotal;
        }
        public Venda(DateTime dataVenda, string passageiro, decimal valorTotal)
        {
            DataVenda = dataVenda;
            Passageiro = passageiro;
            ValorTotal = valorTotal;
        }
        public Venda(int idVenda, decimal valorTotal)
        {
            IdVenda = idVenda;
            ValorTotal = valorTotal;
        }
        public override string ToString()
        {
            return $"IdVenda:\t\t{IdVenda:00000}\n" +
                    $"Data da Venda:\t\t{DataVenda:dd/MM/yyyy}\n" +
                    $"CPF do Passageiro:\t{Passageiro.Substring(0, 3)}.{Passageiro.Substring(3, 3)}.{Passageiro.Substring(6, 3)}-{Passageiro.Substring(9, 2)}\n" +
                    $"Valor Total:\t\t{ValorTotal:0.00}";
        }
    }
}