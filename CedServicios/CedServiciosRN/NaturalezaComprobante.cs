using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.RN
{
    public class NaturalezaComprobante
    {
        public static List<Entidades.NaturalezaComprobante> Lista(Entidades.Enum.Elemento Elemento, Entidades.Sesion Sesion)
        {
            CedServicios.DB.NaturalezaComprobante db = new DB.NaturalezaComprobante(Sesion);
            List<Entidades.NaturalezaComprobante> lista = db.LeerLista(Elemento);
            return lista;
        }
        public static List<Entidades.NaturalezaComprobante> Lista(string IdNaturalezaComprobante, Entidades.Sesion Sesion)
        {
            CedServicios.DB.NaturalezaComprobante db = new DB.NaturalezaComprobante(Sesion);
            List<Entidades.NaturalezaComprobante> lista = db.LeerLista(IdNaturalezaComprobante);
            return lista;
        }
    }
}