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
        public Bloqueados(string cNPJ) { CNPJ = cNPJ; }
        public static bool FindKey(List<Bloqueados> listaDeBloqueados, string cNPJ)
        {
            foreach (Bloqueados bloqueados in listaDeBloqueados)
                if (bloqueados.CNPJ == cNPJ) return true;
            return false;
        }
    }
}
