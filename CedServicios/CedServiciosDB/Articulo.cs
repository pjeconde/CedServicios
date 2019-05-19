using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CedServicios.DB
{
    public class Articulo : db
    {
        public Articulo(Entidades.Sesion Sesion) : base(Sesion)
        {
        }

        public List<Entidades.Articulo> ListaPorCuit(bool SoloVigentes, bool ConStock)
        {
            List<Entidades.Articulo> lista = new List<Entidades.Articulo>();
            if (sesion.Cuit.Nro != null)
            {
                System.Text.StringBuilder a = new StringBuilder();
                a.AppendLine("select Cuit, IdArticulo, DescrArticulo, GTIN, IdUnidad, DescrUnidad, IndicacionExentoGravado, AlicuotaIVA, IdWF, Estado, UltActualiz ");
                if (ConStock) a.AppendLine(", (select isnull(sum(ComprobanteDetalle.Cantidad), convert(decimal(15,2), 0)) from Comprobante, ComprobanteDetalle where Comprobante.IdWF=ComprobanteDetalle.IdWF and Comprobante.Cuit='" + sesion.Cuit.Nro + "' and Comprobante.Estado='Vigente' and ComprobanteDetalle.IdArticulo=Articulo.IdArticulo) as Stock ");
                a.AppendLine("from Articulo where Articulo.Cuit='" + sesion.Cuit.Nro + "' ");
                if (SoloVigentes) a.AppendLine("and Articulo.Estado='Vigente' ");
                a.AppendLine("order by Articulo.DescrArticulo ");
                DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Entidades.Articulo elem = new Entidades.Articulo();
                        Copiar(dt.Rows[i], elem);
                        lista.Add(elem);
                    }
                }
            }
            return lista;
        }
        private void Copiar(DataRow Desde, Entidades.Articulo Hasta)
        {
            Hasta.Cuit = Convert.ToString(Desde["Cuit"]);
            Hasta.Id = Convert.ToString(Desde["IdArticulo"]);
            Hasta.Descr = Convert.ToString(Desde["DescrArticulo"]);
            Hasta.GTIN = Convert.ToString(Desde["GTIN"]);
            Hasta.Unidad.Id = Convert.ToString(Desde["IdUnidad"]);
            Hasta.Unidad.Descr = Convert.ToString(Desde["DescrUnidad"]);
            Hasta.IndicacionExentoGravado = Convert.ToString(Desde["IndicacionExentoGravado"]);
            Hasta.AlicuotaIVA = Convert.ToDouble(Desde["AlicuotaIVA"]);
            Hasta.WF.Id = Convert.ToInt32(Desde["IdWF"]);
            Hasta.WF.Estado = Convert.ToString(Desde["Estado"]);
            Hasta.UltActualiz = ByteArray2TimeStamp((byte[])Desde["UltActualiz"]);
            try
            {
                Hasta.Stock = Convert.ToDouble(Desde["Stock"]);
            }
            catch { }
        }
        private void CopiarListaPaging(DataRow Desde, Entidades.Articulo Hasta)
        {
            Hasta.Cuit = Convert.ToString(Desde["Cuit"]);
            Hasta.Id = Convert.ToString(Desde["IdArticulo"]);
            Hasta.Descr = Convert.ToString(Desde["DescrArticulo"]);
            Hasta.GTIN = Convert.ToString(Desde["GTIN"]);
            Hasta.Unidad.Id = Convert.ToString(Desde["IdUnidad"]);
            Hasta.Unidad.Descr = Convert.ToString(Desde["DescrUnidad"]);
            Hasta.IndicacionExentoGravado = Convert.ToString(Desde["IndicacionExentoGravado"]);
            Hasta.AlicuotaIVA = Convert.ToDouble(Desde["AlicuotaIVA"]);
            Hasta.WF.Id = Convert.ToInt32(Desde["IdWF"]);
            Hasta.WF.Estado = Convert.ToString(Desde["Estado"]);
            Hasta.UltActualiz = Convert.ToString(Desde["UltActualiz"]);
        }
        public void Crear(Entidades.Articulo Articulo)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("declare @idWF varchar(256) ");
            a.AppendLine("update Configuracion set @idWF=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdWF' ");
            a.Append("Insert Articulo (Cuit, IdArticulo, DescrArticulo, GTIN, IdUnidad, DescrUnidad, IndicacionExentoGravado, AlicuotaIVA, IdWF, Estado) values (");
            a.Append("'" + Articulo.Cuit + "', ");
            a.Append("'" + Articulo.Id + "', ");
            a.Append("'" + Articulo.Descr + "', ");
            a.Append("'" + Articulo.GTIN + "', ");
            a.Append("'" + Articulo.Unidad.Id + "', ");
            a.Append("'" + Articulo.Unidad.Descr + "', ");
            a.Append("'" + Articulo.IndicacionExentoGravado + "', ");
            a.Append(Articulo.AlicuotaIVA.ToString() + ", ");
            a.Append("@idWF, ");
            a.Append("'" + Articulo.WF.Estado + "' ");
            a.AppendLine(") ");
            a.AppendLine("insert Log values (@idWF, getdate(), '" + sesion.Usuario.Id + "', 'Articulo', 'Alta', '" + Articulo.WF.Estado + "', '') ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public void Modificar(Entidades.Articulo Desde, Entidades.Articulo Hasta)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("update Articulo set ");
            a.Append("DescrArticulo='" + Hasta.Descr + "', ");
            a.Append("GTIN='" + Hasta.GTIN + "', ");
            a.Append("IdUnidad='" + Hasta.Unidad.Id + "', ");
            a.Append("DescrUnidad='" + Hasta.Unidad.Descr + "', ");
            a.Append("IndicacionExentoGravado='" + Hasta.IndicacionExentoGravado + "', ");
            a.Append("AlicuotaIVA=" + Hasta.AlicuotaIVA.ToString().Replace(",", ".") + " ");
            a.AppendLine("where Cuit='" + Hasta.Cuit + "' and IdArticulo='" + Hasta.Id + "' ");
            a.AppendLine("insert Log values (" + Hasta.WF.Id.ToString() + ", getdate(), '" + sesion.Usuario.Id + "', 'Articulo', 'Modif', '" + Hasta.WF.Estado + "', '') ");
            a.AppendLine("declare @idLog int ");
            a.AppendLine("select @idLog=@@Identity ");
            a.AppendLine("insert LogDetalle (IdLog, TipoDetalle, Detalle) values (@idLog, 'Desde', '" + Funciones.ObjetoSerializado(Desde) + "')");
            a.AppendLine("insert LogDetalle (IdLog, TipoDetalle, Detalle) values (@idLog, 'Hasta', '" + Funciones.ObjetoSerializado(Hasta) + "')");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public void CambiarEstado(Entidades.Articulo Articulo, string Estado)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("update Articulo set ");
            a.Append("Estado='" + Estado + "' ");
            a.AppendLine("where Cuit='" + Articulo.Cuit + "' and IdArticulo='" + Articulo.Id + "' ");
            string evento = (Estado == "DeBaja") ? "Baja" : "AnulBaja";
            a.AppendLine("insert Log values (" + Articulo.WF.Id.ToString() + ", getdate(), '" + sesion.Usuario.Id + "', 'Articulo', '" + evento + "', '" + Estado + "', '') ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public List<Entidades.Articulo> ListaPorCuityId(string Cuit, string IdArticulo, bool ConStock)
        {
            List<Entidades.Articulo> lista = new List<Entidades.Articulo>();
            if (sesion.Cuit.Nro != null)
            {
                System.Text.StringBuilder a = new StringBuilder();
                a.Append("select ");
                a.Append("Cuit, IdArticulo, DescrArticulo, GTIN, IdUnidad, DescrUnidad, IndicacionExentoGravado, AlicuotaIVA, IdWF, Estado, UltActualiz ");
                if (ConStock) a.AppendLine(", (select isnull(sum(ComprobanteDetalle.Cantidad), convert(decimal(15,2), 0)) from Comprobante, ComprobanteDetalle where Comprobante.IdWF=ComprobanteDetalle.IdWF and Comprobante.Cuit='" + sesion.Cuit.Nro + "' and Comprobante.Estado='Vigente' and ComprobanteDetalle.IdArticulo=Articulo.IdArticulo) as Stock ");
                a.Append("from Articulo ");
                a.Append("where Articulo.Cuit='" + Cuit + "' and Articulo.IdArticulo='" + IdArticulo + "'");
                a.Append("order by Articulo.DescrArticulo ");
                DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Entidades.Articulo elem = new Entidades.Articulo();
                        Copiar(dt.Rows[i], elem);
                        lista.Add(elem);
                    }
                }
            }
            return lista;
        }
        public List<Entidades.Articulo> ListaPorCuityDescr(string Cuit, string DescrArticulo, bool ConStock)
        {
            List<Entidades.Articulo> lista = new List<Entidades.Articulo>();
            if (sesion.Cuit.Nro != null)
            {
                System.Text.StringBuilder a = new StringBuilder();
                a.Append("select ");
                a.Append("Cuit, IdArticulo, DescrArticulo, GTIN, IdUnidad, DescrUnidad, IndicacionExentoGravado, AlicuotaIVA, IdWF, Estado, UltActualiz ");
                if (ConStock) a.AppendLine(", (select isnull(sum(ComprobanteDetalle.Cantidad), convert(decimal(15,2), 0)) from Comprobante, ComprobanteDetalle where Comprobante.IdWF=ComprobanteDetalle.IdWF and Comprobante.Cuit='" + sesion.Cuit.Nro + "' and Comprobante.Estado='Vigente' and ComprobanteDetalle.IdArticulo=Articulo.IdArticulo) as Stock ");
                a.Append("from Articulo ");
                a.Append("where Articulo.Cuit='" + Cuit + "' and Articulo.DescrArticulo like '%" + DescrArticulo + "%' ");
                a.Append("order by Articulo.DescrArticulo ");
                DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Entidades.Articulo elem = new Entidades.Articulo();
                        Copiar(dt.Rows[i], elem);
                        lista.Add(elem);
                    }
                }
            }
            return lista;
        }
        public List<Entidades.Articulo> ListaSegunFiltros(string Cuit, string IdArticulo, string DescrArticulo, string Estado)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("select Cuit, IdArticulo, DescrArticulo, GTIN, IdUnidad, DescrUnidad, IndicacionExentoGravado, AlicuotaIVA, IdWF, Estado, UltActualiz ");
            a.AppendLine("from Articulo where 1=1 ");
            if (Cuit != String.Empty) a.AppendLine("and Cuit like '%" + Cuit + "%' ");
            if (IdArticulo != String.Empty) a.AppendLine("and IdArticulo like '%" + IdArticulo + "%' ");
            if (DescrArticulo != String.Empty) a.AppendLine("and DescrArticulo like '%" + DescrArticulo + "%' ");
            if (Estado != String.Empty) a.AppendLine("and Estado = '" + Estado + "' ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<Entidades.Articulo> lista = new List<Entidades.Articulo>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Entidades.Articulo Articulo = new Entidades.Articulo();
                    Copiar(dt.Rows[i], Articulo);
                    lista.Add(Articulo);
                }
            }
            return lista;
        }
        public List<Entidades.Articulo> ListaPaging(int IndicePagina, string OrderBy, string SessionID, List<Entidades.Articulo> ArticuloLista)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("CREATE TABLE #Articulo" + SessionID + "( ");
            a.Append("[Cuit] [varchar](11) NOT NULL, ");
            a.Append("[IdArticulo] [varchar](20) NOT NULL, ");
            a.Append("[DescrArticulo] [varchar](512) NOT NULL, ");
            a.Append("[GTIN] [varchar](20) NOT NULL, ");
            a.Append("[IdUnidad] [varchar](3) NOT NULL, ");
	        a.Append("[DescrUnidad] [varchar](50) NOT NULL, ");
	        a.Append("[IndicacionExentoGravado] [varchar](1) NOT NULL, ");
            a.Append("[AlicuotaIVA] [numeric](4, 2) NOT NULL, ");
            a.Append("[IdWF] [int] NOT NULL, ");
            a.Append("[Estado] [varchar](15) NOT NULL, ");
            a.Append("[UltActualiz] [varchar](18) NOT NULL, ");
            a.Append("CONSTRAINT [PK_Articulo" + SessionID + "] PRIMARY KEY CLUSTERED ");
            a.Append("( ");
            a.Append("[Cuit] ASC, ");
            a.Append("[IdArticulo] ASC ");
            a.Append(")WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY] ");
            a.Append(") ON [PRIMARY] ");
            foreach (Entidades.Articulo Articulo in ArticuloLista)
            {
                a.Append("Insert #Articulo" + SessionID + " values ('" + Articulo.Cuit + "', '");
                a.Append(Articulo.Id + "', '");
                a.Append(Articulo.Descr + "', '");
                a.Append(Articulo.GTIN + "', '");
                a.Append(Articulo.Unidad.Id + "', '");
                a.Append(Articulo.Unidad.Descr + "', '");
                a.Append(Articulo.IndicacionExentoGravado + "', ");
                a.Append(Articulo.AlicuotaIVA.ToString("####0.00", System.Globalization.CultureInfo.CreateSpecificCulture("en-GB")) + ", ");
                a.Append(Articulo.WF.Id + ", '");
                a.Append(Articulo.Estado + "', ");
                a.Append(Articulo.UltActualiz + ")");
            }
            a.Append("select * ");
            a.Append("from (select top {0} ROW_NUMBER() OVER (ORDER BY {1}) as ROW_NUM, ");
            a.Append("Cuit, IdArticulo, DescrArticulo, GTIN, IdUnidad, DescrUnidad, IndicacionExentoGravado, AlicuotaIVA, IdWF, Estado, UltActualiz ");
            a.Append("from #Articulo" + SessionID + " ");
            a.Append("ORDER BY ROW_NUM) innerSelect WHERE ROW_NUM > {2} ");
            a.Append("DROP TABLE #Articulo" + SessionID);
            if (OrderBy.Trim().ToUpper() == "CUIT" || OrderBy.Trim().ToUpper() == "CUIT DESC" || OrderBy.Trim().ToUpper() == "CUIT ASC")
            {
                OrderBy = "#Articulo" + SessionID + "." + OrderBy;
            }
            if (OrderBy.Trim().ToUpper() == "ID" || OrderBy.Trim().ToUpper() == "ID DESC" || OrderBy.Trim().ToUpper() == "ID ASC")
            {
                OrderBy = "#Articulo" + SessionID + "." + OrderBy.Replace("Id", "IdArticulo");
            }
            if (OrderBy.Trim().ToUpper() == "DESCR" || OrderBy.Trim().ToUpper() == "DESCR DESC" || OrderBy.Trim().ToUpper() == "DESCR ASC")
            {
                OrderBy = "#Articulo" + SessionID + "." + OrderBy.Replace("Descr", "DescrArticulo"); ;
            }
            if (OrderBy.Trim().ToUpper() == "ESTADO" || OrderBy.Trim().ToUpper() == "ESTADO DESC" || OrderBy.Trim().ToUpper() == "ESTADO ASC")
            {
                OrderBy = "#Articulo" + SessionID + "." + OrderBy;
            }
            string commandText = string.Format(a.ToString(), ((IndicePagina + 1) * sesion.Usuario.CantidadFilasXPagina), OrderBy, (IndicePagina * sesion.Usuario.CantidadFilasXPagina));
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<Entidades.Articulo> lista = new List<Entidades.Articulo>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Entidades.Articulo Articulo = new Entidades.Articulo();
                    CopiarListaPaging(dt.Rows[i], Articulo);
                    lista.Add(Articulo);
                }
            }
            return lista;
        }
    }
}
