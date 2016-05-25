using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CedServicios.RN
{
    public static class Precio
    {
        public static DataTable Matriz(List<Entidades.ListaPrecio> ListasPrecio, Entidades.Sesion Sesion)
        {
            DB.Precio db = new DB.Precio(Sesion);
            return db.Matriz(ListasPrecio);
        }
        public static void ImpactarMatriz(List<Entidades.ListaPrecio> ListasPrecio, DataTable Matriz, Entidades.Sesion Sesion)
        {
            DB.Precio db = new DB.Precio(Sesion);
            db.ImpactarMatriz(ListasPrecio, Matriz);
        }
    }
}
