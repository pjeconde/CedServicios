using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CedServicios.DB
{
    public class ListaPrecio : db
    {
        public ListaPrecio(Entidades.Sesion Sesion) : base(Sesion)
        {
        }

        public List<Entidades.ListaPrecio> ListaPorCuit(bool SoloVigentes, bool IncluirVacio)
        {
            List<Entidades.ListaPrecio> lista = new List<Entidades.ListaPrecio>();
            if (IncluirVacio) lista.Add(new Entidades.ListaPrecio(String.Empty, "Ninguna"));
            if (sesion.Cuit.Nro != null)
            {
                System.Text.StringBuilder a = new StringBuilder();
                a.Append("select ");
                a.Append("Cuit, IdListaPrecio, DescrListaPrecio, IdWF, Estado, UltActualiz ");
                a.Append("from ListaPrecio ");
                a.Append("where ListaPrecio.Cuit='" + sesion.Cuit.Nro + "' ");
                if (SoloVigentes)
                {
                    a.Append("and ListaPrecio.Estado='Vigente' ");
                }
                a.Append("order by ListaPrecio.DescrListaPrecio ");
                DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Entidades.ListaPrecio elem = new Entidades.ListaPrecio();
                        Copiar(dt.Rows[i], elem);
                        lista.Add(elem);
                    }
                }
            }
            return lista;
        }
        private void Copiar(DataRow Desde, Entidades.ListaPrecio Hasta)
        {
            Hasta.Cuit = Convert.ToString(Desde["Cuit"]);
            Hasta.Id = Convert.ToString(Desde["IdListaPrecio"]);
            Hasta.Descr = Convert.ToString(Desde["DescrListaPrecio"]);
            Hasta.WF.Id = Convert.ToInt32(Desde["IdWF"]);
            Hasta.WF.Estado = Convert.ToString(Desde["Estado"]);
            Hasta.UltActualiz = ByteArray2TimeStamp((byte[])Desde["UltActualiz"]);
        }
        private void CopiarListaPaging(DataRow Desde, Entidades.ListaPrecio Hasta)
        {
            Hasta.Cuit = Convert.ToString(Desde["Cuit"]);
            Hasta.Id = Convert.ToString(Desde["IdListaPrecio"]);
            Hasta.Descr = Convert.ToString(Desde["DescrListaPrecio"]);
            Hasta.WF.Id = Convert.ToInt32(Desde["IdWF"]);
            Hasta.WF.Estado = Convert.ToString(Desde["Estado"]);
            Hasta.UltActualiz = Convert.ToString(Desde["UltActualiz"]);
        }
        public void Crear(Entidades.ListaPrecio ListaPrecio)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("declare @idWF varchar(256) ");
            a.AppendLine("update Configuracion set @idWF=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdWF' ");
            a.Append("Insert ListaPrecio (Cuit, IdListaPrecio, DescrListaPrecio, IdWF, Estado) values (");
            a.Append("'" + ListaPrecio.Cuit + "', ");
            a.Append("'" + ListaPrecio.Id + "', ");
            a.Append("'" + ListaPrecio.Descr + "', ");
            a.Append("@idWF, ");
            a.Append("'" + ListaPrecio.WF.Estado + "' ");
            a.AppendLine(") ");
            a.AppendLine("insert Log values (@idWF, getdate(), '" + sesion.Usuario.Id + "', 'ListaPrecio', 'Alta', '" + ListaPrecio.WF.Estado + "', '') ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public void Modificar(Entidades.ListaPrecio Desde, Entidades.ListaPrecio Hasta)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("update ListaPrecio set ");
            a.Append("DescrListaPrecio='" + Hasta.Descr + "' ");
            a.AppendLine("where Cuit='" + Hasta.Cuit + "' and IdListaPrecio='" + Hasta.Id + "' ");
            a.AppendLine("insert Log values (" + Hasta.WF.Id.ToString() + ", getdate(), '" + sesion.Usuario.Id + "', 'ListaPrecio', 'Modif', '" + Hasta.WF.Estado + "', '') ");
            a.AppendLine("declare @idLog int ");
            a.AppendLine("select @idLog=@@Identity ");
            a.AppendLine("insert LogDetalle (IdLog, TipoDetalle, Detalle) values (@idLog, 'Desde', '" + Funciones.ObjetoSerializado(Desde) + "')");
            a.AppendLine("insert LogDetalle (IdLog, TipoDetalle, Detalle) values (@idLog, 'Hasta', '" + Funciones.ObjetoSerializado(Hasta) + "')");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public void CambiarEstado(Entidades.ListaPrecio ListaPrecio, string Estado)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("update ListaPrecio set ");
            a.Append("Estado='" + Estado + "' ");
            a.AppendLine("where Cuit='" + ListaPrecio.Cuit + "' and IdListaPrecio='" + ListaPrecio.Id + "' ");
            string evento = (Estado == "DeBaja") ? "Baja" : "AnulBaja";
            a.AppendLine("insert Log values (" + ListaPrecio.WF.Id.ToString() + ", getdate(), '" + sesion.Usuario.Id + "', 'ListaPrecio', '" + evento + "', '" + Estado + "', '') ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public List<Entidades.ListaPrecio> ListaPorCuityId(string Cuit, string IdListaPrecio)
        {
            List<Entidades.ListaPrecio> lista = new List<Entidades.ListaPrecio>();
            if (sesion.Cuit.Nro != null)
            {
                System.Text.StringBuilder a = new StringBuilder();
                a.Append("select ");
                a.Append("Cuit, IdListaPrecio, DescrListaPrecio, IdWF, Estado, UltActualiz ");
                a.Append("from ListaPrecio ");
                a.Append("where ListaPrecio.Cuit='" + Cuit + "' and ListaPrecio.IdListaPrecio='" + IdListaPrecio + "'");
                a.Append("order by ListaPrecio.DescrListaPrecio ");
                DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Entidades.ListaPrecio elem = new Entidades.ListaPrecio();
                        Copiar(dt.Rows[i], elem);
                        lista.Add(elem);
                    }
                }
            }
            return lista;
        }
        public List<Entidades.ListaPrecio> ListaPorCuityDescr(string Cuit, string DescrListaPrecio)
        {
            List<Entidades.ListaPrecio> lista = new List<Entidades.ListaPrecio>();
            if (sesion.Cuit.Nro != null)
            {
                System.Text.StringBuilder a = new StringBuilder();
                a.Append("select ");
                a.Append("Cuit, IdListaPrecio, DescrListaPrecio, IdWF, Estado, UltActualiz ");
                a.Append("from ListaPrecio ");
                a.Append("where ListaPrecio.Cuit='" + Cuit + "' and ListaPrecio.DescrListaPrecio like '%" + DescrListaPrecio + "%' ");
                a.Append("order by ListaPrecio.DescrListaPrecio ");
                DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Entidades.ListaPrecio elem = new Entidades.ListaPrecio();
                        Copiar(dt.Rows[i], elem);
                        lista.Add(elem);
                    }
                }
            }
            return lista;
        }
        public List<Entidades.ListaPrecio> ListaSegunFiltros(string Cuit, string IdListaPrecio, string DescrListaPrecio, string Estado)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("select Cuit, IdListaPrecio, DescrListaPrecio, IdWF, Estado, UltActualiz ");
            a.AppendLine("from ListaPrecio where 1=1 ");
            if (Cuit != String.Empty) a.AppendLine("and Cuit like '%" + Cuit + "%' ");
            if (IdListaPrecio != String.Empty) a.AppendLine("and IdListaPrecio like '%" + IdListaPrecio + "%' ");
            if (DescrListaPrecio != String.Empty) a.AppendLine("and DescrListaPrecio like '%" + DescrListaPrecio + "%' ");
            if (Estado != String.Empty) a.AppendLine("and Estado = '" + Estado + "' ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<Entidades.ListaPrecio> lista = new List<Entidades.ListaPrecio>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Entidades.ListaPrecio ListaPrecio = new Entidades.ListaPrecio();
                    Copiar(dt.Rows[i], ListaPrecio);
                    lista.Add(ListaPrecio);
                }
            }
            return lista;
        }
        public List<Entidades.ListaPrecio> ListaPaging(int IndicePagina, string OrderBy, string SessionID, List<Entidades.ListaPrecio> ListaPrecioLista)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("CREATE TABLE #ListaPrecio" + SessionID + "( ");
            a.Append("[Cuit] [varchar](11) NOT NULL, ");
            a.Append("[IdListaPrecio] [varchar](20) NOT NULL, ");
            a.Append("[DescrListaPrecio] [varchar](100) NOT NULL, ");
            a.Append("[IdWF] [int] NOT NULL, ");
            a.Append("[Estado] [varchar](15) NOT NULL, ");
            a.Append("[UltActualiz] [varchar](18) NOT NULL, ");
            a.Append("CONSTRAINT [PK_ListaPrecio" + SessionID + "] PRIMARY KEY CLUSTERED ");
            a.Append("( ");
            a.Append("[Cuit] ASC, ");
            a.Append("[IdListaPrecio] ASC ");
            a.Append(")WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY] ");
            a.Append(") ON [PRIMARY] ");
            foreach (Entidades.ListaPrecio ListaPrecio in ListaPrecioLista)
            {
                a.Append("Insert #ListaPrecio" + SessionID + " values ('" + ListaPrecio.Cuit + "', '");
                a.Append(ListaPrecio.Id + "', '");
                a.Append(ListaPrecio.Descr + "', '");
                a.Append(ListaPrecio.WF.Id + ", '");
                a.Append(ListaPrecio.Estado + "', ");
                a.Append(ListaPrecio.UltActualiz + ")");
            }
            a.Append("select * ");
            a.Append("from (select top {0} ROW_NUMBER() OVER (ORDER BY {1}) as ROW_NUM, ");
            a.Append("Cuit, IdListaPrecio, DescrListaPrecio, IdWF, Estado, UltActualiz ");
            a.Append("from #ListaPrecio" + SessionID + " ");
            a.Append("ORDER BY ROW_NUM) innerSelect WHERE ROW_NUM > {2} ");
            a.Append("DROP TABLE #ListaPrecio" + SessionID);
            if (OrderBy.Trim().ToUpper() == "CUIT" || OrderBy.Trim().ToUpper() == "CUIT DESC" || OrderBy.Trim().ToUpper() == "CUIT ASC")
            {
                OrderBy = "#ListaPrecio" + SessionID + "." + OrderBy;
            }
            if (OrderBy.Trim().ToUpper() == "ID" || OrderBy.Trim().ToUpper() == "ID DESC" || OrderBy.Trim().ToUpper() == "ID ASC")
            {
                OrderBy = "#ListaPrecio" + SessionID + "." + OrderBy.Replace("Id", "IdListaPrecio");
            }
            if (OrderBy.Trim().ToUpper() == "DESCR" || OrderBy.Trim().ToUpper() == "DESCR DESC" || OrderBy.Trim().ToUpper() == "DESCR ASC")
            {
                OrderBy = "#ListaPrecio" + SessionID + "." + OrderBy.Replace("Descr", "DescrListaPrecio"); ;
            }
            if (OrderBy.Trim().ToUpper() == "ESTADO" || OrderBy.Trim().ToUpper() == "ESTADO DESC" || OrderBy.Trim().ToUpper() == "ESTADO ASC")
            {
                OrderBy = "#ListaPrecio" + SessionID + "." + OrderBy;
            }
            string commandText = string.Format(a.ToString(), ((IndicePagina + 1) * sesion.Usuario.CantidadFilasXPagina), OrderBy, (IndicePagina * sesion.Usuario.CantidadFilasXPagina));
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<Entidades.ListaPrecio> lista = new List<Entidades.ListaPrecio>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Entidades.ListaPrecio ListaPrecio = new Entidades.ListaPrecio();
                    CopiarListaPaging(dt.Rows[i], ListaPrecio);
                    lista.Add(ListaPrecio);
                }
            }
            return lista;
        }
    }
}
