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
                    uN.Id = Convert.ToString(dt.Rows[i]["IdUN"]);
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
            Hasta.Id = Convert.ToString(Desde["IdUN"]);
            Hasta.Descr = Convert.ToString(Desde["DescrUN"]);
            Hasta.WF.Id = Convert.ToInt32(Desde["IdWF"]);
            Hasta.WF.Estado = Convert.ToString(Desde["Estado"]);
            Hasta.UltActualiz = ByteArray2TimeStamp((byte[])Desde["UltActualiz"]);
        }
        public void Crear(Entidades.UN UN, string PermisoUsoCUITxUNHandler, string PermisoAdminUNParaUsuarioHandler)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("declare @idWF varchar(256) ");
            a.AppendLine("declare @accionTipo varchar(15) ");
            a.AppendLine("set @accionTipo='AltaUN' ");
            a.AppendLine("declare @accionNro varchar(256) ");
            a.AppendLine("update Configuracion set @accionNro=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoAccionNro' ");
            a.Append(CrearHandler(UN));
            a.AppendLine();
            a.Append(PermisoUsoCUITxUNHandler);
            a.Append(PermisoAdminUNParaUsuarioHandler);
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public string CrearHandler(Entidades.UN UN)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("update Configuracion set @idWF=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdWF' ");
            a.Append("Insert UN (Cuit, IdUN, DescrUN, IdWF, Estado) values (");
            a.Append("'" + UN.Cuit + "', ");
            a.Append("'" + UN.Id + "', ");
            a.Append("'" + UN.Descr + "', ");
            a.Append("@idWF, ");
            a.Append("'" + UN.WF.Estado + "' ");
            a.AppendLine(") ");
            a.AppendLine("insert Log values (@idWF, getdate(), '" + sesion.Usuario.Id + "', 'UN', 'Alta', '" + UN.WF.Estado + "', '') ");
            a.AppendLine();
            return a.ToString();
        }
    }
}
