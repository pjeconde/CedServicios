using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.RN
{
    public class NaturalezaComprobante
    {
        public static List<Entidades.NaturalezaComprobante> Lista(bool IncluirOpcionTodos, Entidades.Sesion Sesion)
        {
            CedServicios.DB.NaturalezaComprobante db = new DB.NaturalezaComprobante(Sesion);
            List<Entidades.NaturalezaComprobante> lista = db.LeerLista(IncluirOpcionTodos);
            return lista;
        }
    }
}