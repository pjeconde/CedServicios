using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.RN
{
    public class Multiseleccion
    {
        public static List<Entidades.Multiseleccion> ListaComboMultiseleccion()
        {
            List<Entidades.Multiseleccion> lista = new List<Entidades.Multiseleccion>();
            lista.Add(new Entidades.Multiseleccion.TODOS());
            lista.Add(new Entidades.Multiseleccion.VARIOS());
            return lista;
        }
    }
}
