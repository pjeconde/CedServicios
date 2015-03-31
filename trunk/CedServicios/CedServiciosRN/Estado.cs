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
            lista.Add(new Entidades.EstadoVigente());
            lista.Add(new Entidades.EstadoPteAutoriz());
            lista.Add(new Entidades.EstadoPteConf());
            lista.Add(new Entidades.EstadoDeBaja());
            lista.Add(new Entidades.EstadoRech());
            if (IncluirOpcionTodos) lista.Add(new Entidades.Estado(String.Empty, "Todos"));
            return lista;
        }
    }
}