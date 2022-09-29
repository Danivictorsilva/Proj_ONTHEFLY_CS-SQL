using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_ONTHEFLY_CS_SQL
{
    public class ItemVenda
    {
        //Propriedades
        public int IdVenda { get; set; }
        public int IdPassagem { get; set; }


        //Metodos
        public ItemVenda(int idVenda, int idPassagem)
        {
            IdVenda = idVenda;
            IdPassagem = idPassagem;
        }
        public override string ToString()
        {
            return String.Format("{{'{0}';'{1}'}}",
                IdVenda, IdPassagem);
        }
        public static string ReturnHeader() => "IdVenda;IdPassagem\n";
    }
}
