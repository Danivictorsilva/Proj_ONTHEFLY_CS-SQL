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
        public Restritos(string cPF) { CPF = cPF; }
        public static bool FindKey(List<Restritos> listaDeRestritos, string cPF)
        {
            foreach (Restritos restritos in listaDeRestritos)
                if (restritos.CPF == cPF) return true;
            return false;
        }
    }
}
