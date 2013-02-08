using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CedServicios.DB
{
    public class Permiso : db
    {
        public Permiso(Entidades.Sesion Sesion) : base(Sesion)
        {
        }

        public List<Entidades.Permiso> LeerListaPermisosPteAutoriz(Entidades.Usuario Usuario)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("/* AUTORIZACIONES PARA ADMINCUITS */ ");
            a.Append("select Permiso.IdUsuario, Permiso.Cuit, Permiso.IdUN, Permiso.IdTipoPermiso, Permiso.FechaFinVigencia, Permiso.IdUsuarioSolicitante, Permiso.AccionTipo, Permiso.AccionNro, Permiso.IdWF, Permiso.Estado, TipoPermiso.DescrTipoPermiso from Permiso, TipoPermiso where Estado='PteAutoriz' and Permiso.IdTipoPermiso in ('UsoCUITxUN', 'AdminCUIT') and Permiso.IdTipoPermiso=TipoPermiso.IdTipoPermiso and Cuit in ");
            a.Append("(select Cuit from Permiso where IdUsuario='" + Usuario.Id + "' and Permiso.IdTipoPermiso='AdminCUIT' and Estado='Vigente') ");
            a.Append("UNION ");
            a.Append("/* AUTORIZACIONES PARA ADMINUNS */ ");
            a.Append("select Permiso.IdUsuario, Permiso.Cuit, Permiso.IdUN, Permiso.IdTipoPermiso, Permiso.FechaFinVigencia, Permiso.IdUsuarioSolicitante, Permiso.AccionTipo, Permiso.AccionNro, Permiso.IdWF, Permiso.Estado, TipoPermiso.DescrTipoPermiso from Permiso, TipoPermiso where Estado='PteAutoriz' and Permiso.IdTipoPermiso not in ('UsoCUITxUN', 'AdminCUIT') and Permiso.IdTipoPermiso=TipoPermiso.IdTipoPermiso and Cuit + '-' + IdUN in ");
            a.Append("(select Cuit + '-' + IdUN from Permiso where IdUsuario='" + Usuario.Id + "' and Permiso.IdTipoPermiso='AdminUN' and Estado='Vigente') and ");
            a.Append("IdUsuario <> '' ");
            a.Append("UNION ");
            a.Append("/* AUTORIZACIONES PARA ADMINSITES */ ");
            a.Append("select Permiso.IdUsuario, Permiso.Cuit, Permiso.IdUN, Permiso.IdTipoPermiso, Permiso.FechaFinVigencia, Permiso.IdUsuarioSolicitante, Permiso.AccionTipo, Permiso.AccionNro, Permiso.IdWF, Permiso.Estado, TipoPermiso.DescrTipoPermiso from Permiso, TipoPermiso where Estado='PteAutoriz' and Permiso.IdTipoPermiso not in ('UsoCUITxUN', 'AdminCUIT', 'AdminUN') and Permiso.IdTipoPermiso=TipoPermiso.IdTipoPermiso and ");
            a.Append("IdUsuario <> '' and (select count(*) from Permiso where IdUsuario='" + Usuario.Id + "' and Permiso.IdTipoPermiso='AdminSITE' and Estado='Vigente')=1 ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<Entidades.Permiso> lista = new List<Entidades.Permiso>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Entidades.Permiso permiso = new Entidades.Permiso();
                    Copiar(dt.Rows[i], permiso);
                    lista.Add(permiso);
                }
            }
            return lista;
        }
        public List<Entidades.Permiso> LeerListaPermisosVigentesPorUsuario(Entidades.Usuario Usuario)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select Permiso.IdUsuario, Permiso.Cuit, Permiso.IdUN, Permiso.IdTipoPermiso, Permiso.FechaFinVigencia, Permiso.IdUsuarioSolicitante, Permiso.AccionTipo, Permiso.AccionNro, Permiso.IdWF, Permiso.Estado, TipoPermiso.DescrTipoPermiso ");
            a.Append("from Permiso, TipoPermiso ");
            a.Append("where IdUsuario='" + Usuario.Id + "' and Estado='Vigente' and Permiso.IdTipoPermiso=TipoPermiso.IdTipoPermiso ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<Entidades.Permiso> lista = new List<Entidades.Permiso>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Entidades.Permiso permiso = new Entidades.Permiso();
                    Copiar(dt.Rows[i], permiso);
                    lista.Add(permiso);
                }
            }
            return lista;
        }
        private void Copiar(DataRow Desde, Entidades.Permiso Hasta)
        {
            Hasta.IdUsuario = Convert.ToString(Desde["IdUsuario"]);
            Hasta.Cuit = Convert.ToString(Desde["Cuit"]);
            Hasta.IdUN = Convert.ToString(Desde["IdUN"]);
            Hasta.TipoPermiso.Id = Convert.ToString(Desde["IdTipoPermiso"]);
            Hasta.TipoPermiso.Descr = Convert.ToString(Desde["DescrTipoPermiso"]);
            Hasta.FechaFinVigencia = Convert.ToDateTime(Desde["FechaFinVigencia"]);
            Hasta.IdUsuarioSolicitante = Convert.ToString(Desde["IdUsuarioSolicitante"]);
            Hasta.Accion.Tipo = Convert.ToString(Desde["AccionTipo"]);
            Hasta.Accion.Nro = Convert.ToInt32(Desde["AccionNro"]);
            Hasta.WF.Id = Convert.ToInt32(Desde["IdWF"]);
            Hasta.WF.Estado = Convert.ToString(Desde["Estado"]);
        }    
    }
}
