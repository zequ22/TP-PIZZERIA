using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASOS_DE_USO
{
    public class OPERACIONES_CLIENTES
    {
        public static void AGREGAR_CLIENTE(CONTEXTO.PIZZERIA PIZZERIA, MODELO.CLIENTE CLIENTE)
        {
            PIZZERIA.CLIENTES.Add(CLIENTE);
        }
        public static void ELIMINAR_CLIENTE(CONTEXTO.PIZZERIA PIZZERIA, MODELO.CLIENTE CLIENTE)
        {
            PIZZERIA.CLIENTES.Remove(CLIENTE);
        }
        public static void MODIFICAR_CLIENTE(CONTEXTO.PIZZERIA PIZZERIA, MODELO.CLIENTE CLIENTE)
        {
            PIZZERIA.Entry(CLIENTE).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
