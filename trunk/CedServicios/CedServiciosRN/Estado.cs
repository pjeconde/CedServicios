using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.RN
{
    public class Estado
    {
        public static List<Entidades.Estado> Lista(bool IncluirOpcionTodos, Entidades.Sesion Sesion)
        {
            List<Entidades.Estado> lista = new List<Entidades.Estado>();
            lista.Add(new Entidades.Estado("Vigente", "Vigente"));
            lista.Add(new Entidades.Estado("PteAutoriz","Pendiente de autorización"));
            lista.Add(new Entidades.Estado("PteConf", "Pendiente de confirmación"));
            lista.Add(new Entidades.Estado("DeBaja", "De baja"));
            if (IncluirOpcionTodos) lista.Add(new Entidades.Estado(String.Empty, "Todos"));
            return lista;
        }
    }
}