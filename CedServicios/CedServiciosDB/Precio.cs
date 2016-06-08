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
                select.Append(", isnull(convert(varchar(20), [" + nombreListaPrecio + "].Valor), '') as '" + nombreListaPrecio + "' ");
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
            StringBuilder b = new StringBuilder(String.Empty);
            b.AppendLine("CREATE TABLE #ArticuloPlanillaPrecios ([IdArticulo] [varchar](20) NOT NULL) ");
            for (int i = 0; i < ListasPrecio.Count; i++)
            {
                if (i == 0) a.Append("'" + ListasPrecio[i].Id + "'"); else a.Append(", '" + ListasPrecio[i].Id + "'");
            }
            a.AppendLine(") ");
            for (int i = 0; i < Matriz.Rows.Count; i++)
            {
                b.AppendLine("insert #ArticuloPlanillaPrecios values ('" + Matriz.Rows[i]["IdArticulo"].ToString() + "') ");
                for (int j = 0; j < ListasPrecio.Count; j++)
                {
                    if (Matriz.Rows[i][ListasPrecio[j].Id].ToString() != "")
                    {
                        double precio = Convert.ToDouble(Matriz.Rows[i][ListasPrecio[j].Id]);
                        a.AppendLine("insert Precio values ('" + sesion.Cuit.Nro + "', '" + ListasPrecio[j].Id + "', '" + Matriz.Rows[i]["IdArticulo"].ToString() + "', " + precio + ") ");
                    }
                }
            }
            b.AppendLine("select IdArticulo from #ArticuloPlanillaPrecios where IdArticulo not in (select IdArticulo from Articulo where Cuit='" + sesion.Cuit.Nro + "') ");
            b.AppendLine("DROP TABLE #ArticuloPlanillaPrecios ");
            DataTable dt = (DataTable)Ejecutar(b.ToString(), TipoRetorno.TB, Transaccion.Acepta, sesion.CnnStr);
            if (dt.Rows.Count == 0)
            {
                Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
            }
            else
            {
                StringBuilder articulosInexistentes = new StringBuilder(String.Empty);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (articulosInexistentes.ToString() != String.Empty) articulosInexistentes.Append(", ");
                    articulosInexistentes.Append(dt.Rows[i]["IdArticulo"].ToString());
                }
                throw new EX.Precio.ArticuloInex(articulosInexistentes.ToString());
            }
        }
        public void Leer(Entidades.Precio Precio)
        {
            StringBuilder a = new StringBuilder(String.Empty);
            a.Append("select Valor from Precio where Cuit='" + sesion.Cuit.Nro + "' and IdArticulo='" + Precio.IdArticulo + "' and IdListaPrecio='" + Precio.IdListaPrecio + "' ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.Acepta, sesion.CnnStr);
            if (dt.Rows.Count == 1)
            {
                Precio.Valor = Convert.ToDouble(dt.Rows[0]["Valor"]);
            }
            else
            {
                throw new EX.Validaciones.ElementoInexistente("Precio");
            }
        }
    }
}
