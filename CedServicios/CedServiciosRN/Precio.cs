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
        public static void ImpactarMatriz(List<Entidades.ListaPrecio> ListasPrecioAImportar, DataTable Matriz, Entidades.Sesion Sesion)
        {
            string listasPrecio = RN.ListaPrecio.ListaPorCuitString(true, false, false, Sesion);
            StringBuilder ListasPrecioInex = new StringBuilder(String.Empty);
            for (int i = 0; i < ListasPrecioAImportar.Count; i++)
            {
                if (listasPrecio.IndexOf("[" + ListasPrecioAImportar[i].Id + "]") == -1)
                {
                    if (ListasPrecioInex.ToString() != String.Empty) ListasPrecioInex.Append(", ");
                    ListasPrecioInex.Append(ListasPrecioAImportar[i].Id);
                }
            }
            if (ListasPrecioInex.ToString() == String.Empty)
            {
                DB.Precio db = new DB.Precio(Sesion);
                db.ImpactarMatriz(ListasPrecioAImportar, Matriz);
            }
            else
            {
                throw new EX.Precio.ListaPrecioInex(ListasPrecioInex.ToString());
            }
        }
    }
}
