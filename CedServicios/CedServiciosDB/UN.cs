using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CedServicios.DB
{
    public class UN : db
    {
        public UN(Entidades.Sesion Sesion) : base(Sesion)
        {
        }

        public List<Entidades.UN> LeerListaUNsPorCuitParaElUsuarioLogueado()
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("/* UNs de AdminUNs */ ");
            a.Append("select IdUN from Permiso where IdTipoPermiso='AdminUN' and idUsuario='" + sesion.Usuario.Id + "' and Cuit='" + sesion.Cuit.Nro + "' and Estado='Vigente' ");
            a.Append("UNION ");
            a.Append("/* UNs de operadores de servicios de UNs*/ ");
            a.Append("select distinct IdUN from Permiso where IdTipoPermiso not in ('AdminUN', 'AdminCUIT', 'AdminSITE', 'UsoCUITxUN') and idUsuario='" + sesion.Usuario.Id + "' and Cuit='" + sesion.Cuit.Nro + "' and Estado='Vigente' ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<Entidades.UN> lista = new List<Entidades.UN>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Entidades.UN uN = new Entidades.UN();
                    uN.Cuit = sesion.Cuit.Nro;
                    uN.Id = Convert.ToInt32(dt.Rows[i]["IdUN"]);
                    Leer(uN);
                    lista.Add(uN);
                }
            }
            return lista;
        }
        public List<Entidades.UN> LeerListaUNsVigentesPorCuit(Entidades.Cuit Cuit)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select UN.Cuit, UN.IdUN, UN.DescrUN, UN.IdWF, UN.Estado, UN.UltActualiz from UN where Cuit='" + Cuit.Nro + "' and Estado='Vigente' ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<Entidades.UN> lista = new List<Entidades.UN>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Entidades.UN elem = new Entidades.UN();
                    Copiar(dt.Rows[i], elem); 
                    lista.Add(elem);
                }
            }
            return lista;
        }
        public void Leer(Entidades.UN UN)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select UN.Cuit, UN.IdUN, UN.DescrUN, UN.IdWF, UN.Estado, UN.UltActualiz ");
            a.Append("from UN ");
            a.Append("where UN.Cuit='" + UN.Cuit + "' and UN.IdUN='" + UN.Id + "' ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count == 0)
            {
                throw new CedServicios.EX.Validaciones.ElementoInexistente("Unidad de negocio '" + UN.Id + "' del Cuit " + UN.Cuit);
            }
            else
            {
                Copiar(dt.Rows[0], UN);
            }
        }
        private void Copiar(DataRow Desde, Entidades.UN Hasta)
        {
            Hasta.Cuit = Convert.ToString(Desde["Cuit"]);
            Hasta.Id = Convert.ToInt32(Desde["IdUN"]);
            Hasta.Descr = Convert.ToString(Desde["DescrUN"]);
            Hasta.WF.Id = Convert.ToInt32(Desde["IdWF"]);
            Hasta.WF.Estado = Convert.ToString(Desde["Estado"]);
            Hasta.UltActualiz = ByteArray2TimeStamp((byte[])Desde["UltActualiz"]);
        }
        private void Copiar_ListaPaging(DataRow Desde, Entidades.UN Hasta)
        {
            Hasta.Cuit = Convert.ToString(Desde["Cuit"]);
            Hasta.Id = Convert.ToInt32(Desde["IdUN"]);
            Hasta.Descr = Convert.ToString(Desde["DescrUN"]);
            Hasta.WF.Id = Convert.ToInt32(Desde["IdWF"]);
            Hasta.WF.Estado = Convert.ToString(Desde["Estado"]);
            Hasta.UltActualiz = Convert.ToString(Desde["UltActualiz"]);
        }
        public void Crear(Entidades.UN UN, string PermisoUsoCUITxUNHandler, string PermisoAdminUNParaUsuarioHandler)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("declare @idWF varchar(256) ");
            a.AppendLine("declare @accionTipo varchar(15) ");
            a.AppendLine("set @accionTipo='AltaUN' ");
            a.AppendLine("declare @accionNro varchar(256) ");
            a.AppendLine("update Configuracion set @accionNro=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoAccionNro' ");
            a.Append(CrearHandler(UN, false));
            a.AppendLine();
            a.Append(PermisoUsoCUITxUNHandler);
            a.Append(PermisoAdminUNParaUsuarioHandler);
            a.Append("select top 1 IdUN from UN  where Cuit='" + UN.Cuit + "' order by IdUN desc ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.Usa, sesion.CnnStr);
            UN.Id = Convert.ToInt32(dt.Rows[0]["IdUN"]);
        }
        public string CrearHandler(Entidades.UN UN, bool EnAltaDeCUIT)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("declare @idUN int ");
            if (EnAltaDeCUIT)
            {
                a.Append("set @idUN=1 ");
            }
            else
            {
                a.Append("select @idUN=max(IdUN)+1 from UN where Cuit='" + UN.Cuit + "' ");
            }
            a.AppendLine("update Configuracion set @idWF=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdWF' ");
            a.Append("Insert UN (Cuit, IdUN, DescrUN, IdWF, Estado) values (");
            a.Append("'" + UN.Cuit + "', ");
            a.Append("@idUN, ");
            if (EnAltaDeCUIT)
            {
                a.Append("'Predefinida', ");
            }
            else
            {
                a.Append("'" + UN.Descr + "', ");
            }
            a.Append("@idWF, ");
            a.Append("'" + UN.WF.Estado + "' ");
            a.AppendLine(") ");
            a.AppendLine("insert Log values (@idWF, getdate(), '" + sesion.Usuario.Id + "', 'UN', 'Alta', '" + UN.WF.Estado + "', '') ");
            a.AppendLine();
            return a.ToString();
        }
        public void Modificar(Entidades.UN Desde, Entidades.UN Hasta)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("update UN set ");
            a.Append("DescrUN='" + Hasta.Descr + "' ");
            a.AppendLine("where Cuit='" + Hasta.Cuit + "' and IdUN=" + Hasta.Id.ToString() + " ");
            a.AppendLine("insert Log values (" + Hasta.WF.Id.ToString() + ", getdate(), '" + sesion.Usuario.Id + "', 'UN', 'Modif', '" + Hasta.WF.Estado + "', '') ");
            a.AppendLine("declare @idLog int ");
            a.AppendLine("select @idLog=@@Identity ");
            a.AppendLine("insert LogDetalle (IdLog, TipoDetalle, Detalle) values (@idLog, 'Desde', '" + Funciones.ObjetoSerializado(Desde) + "')");
            a.AppendLine("insert LogDetalle (IdLog, TipoDetalle, Detalle) values (@idLog, 'Hasta', '" + Funciones.ObjetoSerializado(Hasta) + "')");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public void CambiarEstado(Entidades.UN UN, string Estado)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("update UN set ");
            a.Append("Estado='" + Estado + "' ");
            a.AppendLine("where Cuit='" + UN.Cuit + "' and IdUN='" + UN.Id + "' ");
            string evento = (Estado == "DeBaja") ? "Baja" : "AnulBaja";
            a.AppendLine("insert Log values (" + UN.WF.Id.ToString() + ", getdate(), '" + sesion.Usuario.Id + "', 'UN', '" + evento + "', '" + Estado + "', '') ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public List<Entidades.UN> ListaSegunFiltros(string Cuit, string IdUN, string DescrUN, string Estado)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("select UN.Cuit, UN.IdUN, UN.DescrUN, UN.IdWF, UN.Estado, UN.UltActualiz ");
            a.AppendLine("from UN where 1=1 ");
            if (Cuit != String.Empty) a.AppendLine("and Cuit like '%" + Cuit + "%' ");
            if (IdUN != String.Empty) a.AppendLine("and IdUN like '%" + IdUN + "%' ");
            if (DescrUN != String.Empty) a.AppendLine("and DescrUN like '%" + DescrUN + "%' ");
            if (Estado != String.Empty) a.AppendLine("and Estado = '" + Estado + "' ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<Entidades.UN> lista = new List<Entidades.UN>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Entidades.UN UN = new Entidades.UN();
                    Copiar(dt.Rows[i], UN);
                    lista.Add(UN);
                }
            }
            return lista;
        }
        public List<Entidades.UN> ListaPaging(int IndicePagina, string OrderBy, string SessionID, List<Entidades.UN> UNLista)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("CREATE TABLE #UN" + SessionID + "( ");
            a.Append("[Cuit] [varchar](11) NOT NULL, ");
            a.Append("[IdUN] [int] NOT NULL, ");
            a.Append("[DescrUN] [varchar](50) NOT NULL, ");
            a.Append("[IdWF] [int] NOT NULL, ");
            a.Append("[Estado] [varchar](15) NOT NULL, ");
            a.Append("[UltActualiz] [varchar](18) NOT NULL, ");
            a.Append("CONSTRAINT [PK_UN" + SessionID + "] PRIMARY KEY CLUSTERED ");
            a.Append("( ");
            a.Append("[Cuit] ASC, ");
            a.Append("[IdUN] ASC ");
            a.Append(")WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY] ");
            a.Append(") ON [PRIMARY] ");
            foreach (Entidades.UN UN in UNLista)
            {
                a.Append("Insert #UN" + SessionID + " values ('" + UN.Cuit + "', ");
                a.Append(UN.Id + ", '");
                a.Append(UN.Descr + "', ");
                a.Append(UN.WF.Id + ", '");
                a.Append(UN.Estado + "', ");
                a.Append(UN.UltActualiz + ")");
            }
            a.Append("select * ");
            a.Append("from (select top {0} ROW_NUMBER() OVER (ORDER BY {1}) as ROW_NUM, ");
            a.Append("Cuit, IdUN, DescrUN, IdWF, Estado, UltActualiz ");
            a.Append("from #UN" + SessionID + " ");
            a.Append("ORDER BY ROW_NUM) innerSelect WHERE ROW_NUM > {2} ");
            a.Append("DROP TABLE #UN" + SessionID);
            if (OrderBy.Trim().ToUpper() == "ID" || OrderBy.Trim().ToUpper() == "ID DESC" || OrderBy.Trim().ToUpper() == "ID ASC")
            {
                OrderBy = "#UN" + SessionID + "." + OrderBy.Replace("Id", "IdUN");
            }
            if (OrderBy.Trim().ToUpper() == "CUIT" || OrderBy.Trim().ToUpper() == "CUIT DESC" || OrderBy.Trim().ToUpper() == "CUIT ASC")
            {
                OrderBy = "#UN" + SessionID + "." + OrderBy;
            }
            if (OrderBy.Trim().ToUpper() == "DESCR" || OrderBy.Trim().ToUpper() == "DESCR DESC" || OrderBy.Trim().ToUpper() == "DESCR ASC")
            {
                OrderBy = "#UN" + SessionID + "." + OrderBy.Replace("Descr", "DescrUN"); ;
            }
            if (OrderBy.Trim().ToUpper() == "ESTADO" || OrderBy.Trim().ToUpper() == "ESTADO DESC" || OrderBy.Trim().ToUpper() == "ESTADO ASC")
            {
                OrderBy = "#UN" + SessionID + "." + OrderBy;
            }
            string commandText = string.Format(a.ToString(), ((IndicePagina + 1) * sesion.Usuario.CantidadFilasXPagina), OrderBy, (IndicePagina * sesion.Usuario.CantidadFilasXPagina));
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<Entidades.UN> lista = new List<Entidades.UN>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Entidades.UN UN = new Entidades.UN();
                    Copiar_ListaPaging(dt.Rows[i], UN);
                    lista.Add(UN);
                }
            }
            return lista;
        }
    }
}
