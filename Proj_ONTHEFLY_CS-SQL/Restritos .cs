using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_ONTHEFLY_CS_SQL
{
    public class Restritos
    {
        //Propriedades
        public string CPF { get; set; }

        //Metodos
        public Restritos(string cPF)
        {
            CPF = cPF;
        }
        public override string ToString()
        {
            return String.Format("{{'{0}'}}",
                CPF);
        }
        public static string ReturnHeader() => "CPF\n";
    }
}
