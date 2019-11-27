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
            lista.Add(new Entidades.EstadoPteEnvio());
            lista.Add(new Entidades.EstadoPteAutoriz());
            lista.Add(new Entidades.EstadoPteConf());
            lista.Add(new Entidades.EstadoDeBaja());
            lista.Add(new Entidades.EstadoRech());
            if (IncluirOpcionTodos) lista.Add(new Entidades.Estado(String.Empty, "Todos", false));
            return lista;
        }

        public static List<Entidades.Estado> ListaPersonas(bool IncluirOpcionTodos)
        {
            List<Entidades.Estado> lista = new List<Entidades.Estado>();
            lista.Add(new Entidades.EstadoVigente());
            lista.Add(new Entidades.EstadoDeBaja());
            if (IncluirOpcionTodos) lista.Add(new Entidades.Estado(String.Empty, "Todos", false));
            return lista;
        }

        public static List<Entidades.Estado> ListaArticulos(bool IncluirOpcionTodos)
        {
            List<Entidades.Estado> lista = new List<Entidades.Estado>();
            lista.Add(new Entidades.EstadoVigente());
            lista.Add(new Entidades.EstadoDeBaja());
            if (IncluirOpcionTodos) lista.Add(new Entidades.Estado(String.Empty, "Todos", false));
            return lista;
        }

        public static List<Entidades.Estado> ListaComprobantesCompras()
        {
            List<Entidades.Estado> lista = new List<Entidades.Estado>();
            lista.Add(new Entidades.EstadoVigente());
            return lista;
        }

        public static List<Entidades.Estado> ListaComprobantesVenta()
        {
            List<Entidades.Estado> lista = new List<Entidades.Estado>();
            lista.Add(new Entidades.EstadoVigente());
            lista.Add(new Entidades.EstadoPteEnvio());
            lista.Add(new Entidades.EstadoPteAutoriz());
            lista.Add(new Entidades.EstadoPteConf());
            lista.Add(new Entidades.EstadoDeBaja());
            lista[lista.Count - 1].Incluir = false;
            lista.Add(new Entidades.EstadoRech());
            lista[lista.Count - 1].Incluir = true;
            return lista;
        }
        public static List<Entidades.Estado> ListaComprobantesTodos()
        {
            List<Entidades.Estado> lista = new List<Entidades.Estado>();
            lista.Add(new Entidades.EstadoVigente());
            lista.Add(new Entidades.EstadoPteEnvio());
            lista.Add(new Entidades.EstadoPteAutoriz());
            lista.Add(new Entidades.EstadoPteConf());
            lista.Add(new Entidades.EstadoDeBaja());
            lista.Add(new Entidades.EstadoRech());
            return lista;
        }
        public static List<Entidades.Estado> ListaComprobantesTodosMenosVig()
        {
            List<Entidades.Estado> lista = new List<Entidades.Estado>();
            lista.Add(new Entidades.EstadoVigente());
            lista[lista.Count - 1].Incluir = false;
            lista.Add(new Entidades.EstadoPteEnvio());
            lista.Add(new Entidades.EstadoPteAutoriz());
            lista.Add(new Entidades.EstadoPteConf());
            lista.Add(new Entidades.EstadoDeBaja());
            lista.Add(new Entidades.EstadoRech());
            return lista;
        }
        public static List<Entidades.Estado> ListaComprobantesSoloPteEnvio()
        {
            List<Entidades.Estado> lista = new List<Entidades.Estado>();
            lista.Add(new Entidades.EstadoPteEnvio());
            return lista;
        }
        public static List<Entidades.Estado> ListaComprobantesVentaSoloPtes()
        {
            List<Entidades.Estado> lista = new List<Entidades.Estado>();
            lista.Add(new Entidades.EstadoPteEnvio());
            lista.Add(new Entidades.EstadoPteAutoriz());
            lista.Add(new Entidades.EstadoPteConf());
            lista.Add(new Entidades.EstadoRech());
            return lista;
        }
        public static List<Entidades.Estado> ListaContratos(bool IncluirOpcionTodos)
        {
            List<Entidades.Estado> lista = new List<Entidades.Estado>();
            lista.Add(new Entidades.EstadoVigente());
            lista.Add(new Entidades.EstadoDeBaja());
            if (IncluirOpcionTodos) lista.Add(new Entidades.Estado(String.Empty, "Todos", false));
            return lista;
        }
    }

}