using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CedServicios.DB
{
    public class Precio : db
    {
        public Precio(Entidades.Sesion Sesion) : base(Sesion)
        {
        }

        public DataTable Matriz(List<Entidades.ListaPrecio> ListasPrecio)
        {
            System.Text.StringBuilder select = new StringBuilder();
            System.Text.StringBuilder from = new StringBuilder();
            System.Text.StringBuilder where = new StringBuilder();
            select.Append("select Articulo.IdArticulo, Articulo.DescrArticulo ");
            from.Append("from Articulo ");
            for (int i = 0; i < ListasPrecio.Count; i++)
            {
                string nombreListaPrecio = ListasPrecio[i].Id;
                select.Append(", isnull([" + nombreListaPrecio + "].Valor, 0) as '" + nombreListaPrecio + "' ");
                from.Append("left outer join Precio [" + nombreListaPrecio + "] on [" + nombreListaPrecio + "].Cuit+[" + nombreListaPrecio + "].IdListaPrecio+[" + nombreListaPrecio + "].IdArticulo=Articulo.Cuit+'" + nombreListaPrecio + "'+Articulo.IdArticulo ");
            }
            where.Append("where Articulo.Cuit='" + sesion.Cuit.Nro + "' and Articulo.Estado='Vigente' ");
            DataTable dt = (DataTable)Ejecutar(select.ToString() + from.ToString() + where.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            return dt;
        }
        public void ImpactarMatriz(List<Entidades.ListaPrecio> ListasPrecio, DataTable Matriz)
        {
            StringBuilder a = new StringBuilder(String.Empty);
            a.Append("delete Precio where Cuit='" + sesion.Cuit.Nro + "' and IdListaPrecio in (");
            for (int i = 0; i < ListasPrecio.Count; i++)
            {
                if (i == 0) a.Append("'" + ListasPrecio[i].Id + "'"); else a.Append(", '" + ListasPrecio[i].Id + "'");
            }
            a.AppendLine(") ");
            for (int i = 0; i < Matriz.Rows.Count; i++)
            {
                for (int j = 0; j < ListasPrecio.Count; j++)
                {
                    double precio = Convert.ToDouble(Matriz.Rows[i][ListasPrecio[j].Id]);
                    if (precio != 0) a.AppendLine("insert Precio values ('" + sesion.Cuit.Nro + "', '" + ListasPrecio[j].Id + "', '" + Matriz.Rows[i]["IdArticulo"].ToString() + "', " + precio + ") ");
                }
            }
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
    }
}
