using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONTROLADORA
{
    public class CLIENTES
    {
        private static CLIENTES instancia;
        public static CLIENTES obtener_instancia()
        {
            if (instancia == null)
            {
                instancia = new CLIENTES();
            }
            return instancia;
        }

        CONTEXTO.PIZZERIA oCONTEXTO;
        private CLIENTES()
        {
            oCONTEXTO = CONTEXTO.PIZZERIA.obtener_instancia();
        }
        public void AGREGAR_CLIENTE(MODELO.CLIENTE CLIENTE)
        {
            CASOS_DE_USO.OPERACIONES_CLIENTES.AGREGAR_CLIENTE(oCONTEXTO, CLIENTE);
            oCONTEXTO.SaveChanges();
        }
        public void MODIFICAR_CLIENTE(MODELO.CLIENTE CLIENTE)
        {
            CASOS_DE_USO.OPERACIONES_CLIENTES.MODIFICAR_CLIENTE(oCONTEXTO, CLIENTE);
            oCONTEXTO.SaveChanges();
        }
        public void ELIMINAR_CLIENTE(MODELO.CLIENTE CLIENTE)
        {
            CASOS_DE_USO.OPERACIONES_CLIENTES.ELIMINAR_CLIENTE(oCONTEXTO, CLIENTE);
            oCONTEXTO.SaveChanges();
        }

        public List<MODELO.CLIENTE> OBTENER_CLIENTES()
        {
            return CASOS_DE_USO.GESTION_CLIENTES.OBTENER_CLIENTES(oCONTEXTO);
        }

    }
}
