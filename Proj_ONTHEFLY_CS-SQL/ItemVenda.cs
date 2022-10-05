using System;
using System.Collections.Generic;
using System.Data;
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
        public int IdVoo { get; set; }

        //Metodos
        public ItemVenda(int idVenda, int idPassagem, int idVoo)
        {
            IdVenda = idVenda;
            IdPassagem = idPassagem;
            IdVoo = idVoo;
        }
        public string TopFormat()
        {
            return String.Format("{{'{0:00000}';'PA{1:0000}';'V{2:0000}'}}",
                IdVenda, IdPassagem, IdVoo);
        }
        public static string ReturnHeader() => "IdVenda;IdPassagem;IdVoo\n";
    }
}
