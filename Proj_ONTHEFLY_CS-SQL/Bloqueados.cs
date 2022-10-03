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
        public override string ToString() => $"{CNPJ.Substring(0, 2)}.{CNPJ.Substring(2, 3)}.{CNPJ.Substring(5, 3)}/{CNPJ.Substring(8, 4)}-{CNPJ.Substring(12, 2)}\n";
        public static bool FindKey(List<Bloqueados> listaDeBloqueados, string cNPJ)
        {
            foreach (Bloqueados bloqueados in listaDeBloqueados)
            {
                if (bloqueados.CNPJ == cNPJ) return true;
            }
            return false;
        }
    }
}
