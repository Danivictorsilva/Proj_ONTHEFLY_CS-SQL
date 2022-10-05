using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_ONTHEFLY_CS_SQL
{
    public class Destino
    {
        public string IATA { get; set; }

        public static bool FindKey(List<Destino> listaDeDestinos, string iATA)
        {
            foreach (Destino destino in listaDeDestinos)
                if (destino.IATA == iATA) return true;
            return false;
        }
    }
}

