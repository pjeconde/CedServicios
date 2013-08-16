using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CedServicios.DB
{
    public class PermisoLog : db
    {
        public PermisoLog(Entidades.Sesion Sesion) : base(Sesion)
        {
        }
        public List<Entidades.PermisoLog> LeerListaIntervencionesDelAutorizador(Entidades.Usuario Autorizador)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("select Log.Fecha, Log.Evento, Permiso.IdUsuario, Permiso.Cuit, Permiso.IdUN, Permiso.IdTipoPermiso, Permiso.FechaFinVigencia, Permiso.IdUsuarioSolicitante, Permiso.AccionTipo, Permiso.AccionNro, ");
            a.AppendLine("Permiso.IdWF, Log.Estado, TipoPermiso.DescrTipoPermiso, isnull(u.Nombre, '') as NombreUsuario, isnull(u.Email, '') as EmailUsuario, ");
            a.AppendLine("isnull(us.Nombre, '') as NombreUsuarioSolicitante , isnull(us.Email, '') as EmailUsuarioSolicitante, isnull(UN.DescrUN, '') as DescrUN ");
            a.AppendLine("from Log ");
            a.AppendLine("join Permiso on Log.IdWF=Permiso.IdWF ");
            a.AppendLine("join TipoPermiso on Permiso.IdTipoPermiso=TipoPermiso.IdTipoPermiso ");
            a.AppendLine("left outer join Usuario u on Permiso.IdUsuario=u.IdUsuario ");
            a.AppendLine("left outer join Usuario us on Permiso.IdUsuarioSolicitante=us.IdUsuario ");
            a.AppendLine("left outer join UN on Permiso.IdUN=UN.IdUN and Permiso.Cuit=UN.Cuit ");
            a.AppendLine("where Log.Evento in ('Autoriz', 'Rech') and Log.IdUsuario='" + Autorizador.Id + "' ");
            a.AppendLine("order by Log.Fecha desc ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<Entidades.PermisoLog> lista = new List<Entidades.PermisoLog>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Entidades.PermisoLog permiso = new Entidades.PermisoLog();
                    Copiar(dt.Rows[i], permiso);
                    lista.Add(permiso);
                }
            }
            return lista;
        }
        private void Copiar(DataRow Desde, Entidades.PermisoLog Hasta)
        {
            Hasta.Usuario.Id = Convert.ToString(Desde["IdUsuario"]);
            Hasta.Cuit = Convert.ToString(Desde["Cuit"]);
            Hasta.UN.Id = Convert.ToInt32(Desde["IdUN"]);
            try
            {
                Hasta.UN.Descr = Convert.ToString(Desde["DescrUN"]);
            }
            catch { }
            Hasta.TipoPermiso.Id = Convert.ToString(Desde["IdTipoPermiso"]);
            try
            {
                Hasta.TipoPermiso.Descr = Convert.ToString(Desde["DescrTipoPermiso"]);
            }
            catch { }
            Hasta.FechaFinVigencia = Convert.ToDateTime(Desde["FechaFinVigencia"]);
            Hasta.UsuarioSolicitante.Id = Convert.ToString(Desde["IdUsuarioSolicitante"]);
            Hasta.Accion.Tipo = Convert.ToString(Desde["AccionTipo"]);
            Hasta.Accion.Nro = Convert.ToInt32(Desde["AccionNro"]);
            Hasta.WF.Id = Convert.ToInt32(Desde["IdWF"]);
            Hasta.WF.Estado = Convert.ToString(Desde["Estado"]);
            try
            {
                Hasta.Usuario.Nombre = Convert.ToString(Desde["NombreUsuario"]);
                Hasta.Usuario.Email = Convert.ToString(Desde["EmailUsuario"]);
                Hasta.UsuarioSolicitante.Nombre = Convert.ToString(Desde["NombreUsuarioSolicitante"]);
                Hasta.UsuarioSolicitante.Email = Convert.ToString(Desde["EmailUsuarioSolicitante"]);
            }
            catch { }
            Hasta.Fecha = Convert.ToDateTime(Desde["Fecha"]);
            Hasta.Evento = Convert.ToString(Desde["Evento"]);
        }
    }
}
