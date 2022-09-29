using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_ONTHEFLY_CS_SQL
{
    public class Bloqueados
    {
        //Propriedades
        public string CNPJ { get; set; }

        //Metodos
        public Bloqueados(string cNPJ)
        {
            CNPJ = cNPJ;
        }
        public override string ToString()
        {
            return String.Format("{{'{0}'}}",
                CNPJ);
        }
        public static string ReturnHeader() => "CNPJ\n";
    }
}
