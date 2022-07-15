using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASOS_DE_USO
{
    public class GESTION_CLIENTES
    {
        public static List<MODELO.CLIENTE> OBTENER_CLIENTES(CONTEXTO.PIZZERIA PIZZERIA)
        {
            return PIZZERIA.CLIENTES.ToList();
        }
    }
}
