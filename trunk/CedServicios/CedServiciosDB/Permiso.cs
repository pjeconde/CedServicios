using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CedServicios.DB
{
    public class Permiso : db
    {
        public Permiso(Entidades.Sesion Sesion)
            : base(Sesion)
        {
        }

        public List<Entidades.Permiso> LeerListaPermisosPteAutoriz(Entidades.Usuario Usuario)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("/* AUTORIZACIONES PARA ADMINCUITS */ ");
            a.AppendLine("select Permiso.IdUsuario, Permiso.Cuit, Permiso.IdUN, Permiso.IdTipoPermiso, Permiso.FechaFinVigencia, Permiso.IdUsuarioSolicitante, Permiso.AccionTipo, Permiso.AccionNro, Permiso.IdWF, Permiso.Estado, TipoPermiso.DescrTipoPermiso into #p from Permiso, TipoPermiso where Estado='PteAutoriz' and Permiso.IdTipoPermiso in ('UsoCUITxUN', 'AdminCUIT') and Permiso.IdTipoPermiso=TipoPermiso.IdTipoPermiso and Cuit in ");
            a.AppendLine("(select Cuit from Permiso where IdUsuario='" + Usuario.Id + "' and Permiso.IdTipoPermiso='AdminCUIT' and Estado='Vigente') ");
            a.AppendLine("/* AUTORIZACIONES PARA ADMINUNS */ ");
            a.AppendLine("insert #p select Permiso.IdUsuario, Permiso.Cuit, Permiso.IdUN, Permiso.IdTipoPermiso, Permiso.FechaFinVigencia, Permiso.IdUsuarioSolicitante, Permiso.AccionTipo, Permiso.AccionNro, Permiso.IdWF, Permiso.Estado, TipoPermiso.DescrTipoPermiso from Permiso, TipoPermiso where Estado='PteAutoriz' and Permiso.IdTipoPermiso not in ('UsoCUITxUN', 'AdminCUIT', 'AdminSITE') and Permiso.IdTipoPermiso=TipoPermiso.IdTipoPermiso and Cuit + '-' + convert(varchar(10), IdUN) in ");
            a.AppendLine("(select Cuit + '-' + convert(varchar(10), IdUN) from Permiso where IdUsuario='" + Usuario.Id + "' and Permiso.IdTipoPermiso='AdminUN' and Estado='Vigente') and ");
            a.AppendLine("IdUsuario <> '' ");
            a.AppendLine("/* AUTORIZACIONES PARA ADMINSITES */ ");
            a.AppendLine("insert #p select Permiso.IdUsuario, Permiso.Cuit, Permiso.IdUN, Permiso.IdTipoPermiso, Permiso.FechaFinVigencia, Permiso.IdUsuarioSolicitante, Permiso.AccionTipo, Permiso.AccionNro, Permiso.IdWF, Permiso.Estado, TipoPermiso.DescrTipoPermiso from Permiso, TipoPermiso where Estado='PteAutoriz' and Permiso.IdTipoPermiso in ('AdminSITE') and Permiso.IdTipoPermiso=TipoPermiso.IdTipoPermiso and ");
            a.AppendLine("IdUsuario <> '' and (select count(*) from Permiso where IdUsuario='" + Usuario.Id + "' and Permiso.IdTipoPermiso='AdminSITE' and Estado='Vigente')=1 ");
            a.AppendLine("/* RESULTADOS */ ");
            a.AppendLine("select distinct #p.IdUsuario, #p.Cuit, #p.IdUN, #p.IdTipoPermiso, #p.FechaFinVigencia, #p.IdUsuarioSolicitante, #p.AccionTipo, #p.AccionNro, #p.IdWF, #p.Estado, #p.DescrTipoPermiso, isnull(u.Nombre, '') as NombreUsuario, isnull(u.Email, '') as EmailUsuario, isnull(us.Nombre, '') as NombreUsuarioSolicitante , isnull(us.Email, '') as EmailUsuarioSolicitante, isnull(UN.DescrUN, '') as DescrUN ");
            a.AppendLine("from #p ");
            a.AppendLine("left outer join Usuario u on #p.IdUsuario=u.IdUsuario ");
            a.AppendLine("left outer join Usuario us on #p.IdUsuarioSolicitante=us.IdUsuario ");
            a.AppendLine("left outer join UN on #p.IdUN=UN.IdUN and #p.Cuit=UN.Cuit ");
            a.AppendLine("order by #p.DescrTipoPermiso, #p.Cuit, #p.IdUN, NombreUsuario ");
            a.AppendLine("drop table #p ");
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
        public List<Entidades.Permiso> LeerListaPermisosPorUsuario(Entidades.Usuario Usuario)
        {
            List<Entidades.Permiso> lista = new List<Entidades.Permiso>();
            if (Usuario.Id != null)
            {
                StringBuilder a = new StringBuilder(string.Empty);
                a.AppendLine("select Permiso.IdUsuario, Permiso.Cuit, Permiso.IdUN, Permiso.IdTipoPermiso, Permiso.FechaFinVigencia, Permiso.IdUsuarioSolicitante, Permiso.AccionTipo, Permiso.AccionNro, Permiso.IdWF, Permiso.Estado, TipoPermiso.DescrTipoPermiso, isnull(UN.DescrUN, '') as DescrUN ");
                a.AppendLine("from Permiso ");
                a.AppendLine("join TipoPermiso on Permiso.IdTipoPermiso=TipoPermiso.IdTipoPermiso ");
                a.AppendLine("left outer join UN on Permiso.IdUN=UN.IdUN  and Permiso.Cuit=UN.Cuit ");
                a.AppendLine("where IdUsuario='" + Usuario.Id + "' ");
                DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Entidades.Permiso permiso = new Entidades.Permiso();
                        Copiar(dt.Rows[i], permiso);
                        lista.Add(permiso);
                    }
                }
            }
            return lista;
        }
        public List<Entidades.Permiso> LeerListaPermisosVigentesPorUsuario(Entidades.Usuario Usuario)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("select Permiso.IdUsuario, Permiso.Cuit, Permiso.IdUN, Permiso.IdTipoPermiso, Permiso.FechaFinVigencia, Permiso.IdUsuarioSolicitante, Permiso.AccionTipo, Permiso.AccionNro, Permiso.IdWF, Permiso.Estado, TipoPermiso.DescrTipoPermiso ");
            a.AppendLine("from Permiso, TipoPermiso ");
            a.AppendLine("where IdUsuario='" + Usuario.Id + "' and Estado='Vigente' and Permiso.IdTipoPermiso=TipoPermiso.IdTipoPermiso ");
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
        public List<Entidades.Permiso> LeerListaPermisosFiltrados(string IdUsuario, string CUIT, string IdTipoPermiso, string Estado)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("select Permiso.IdUsuario, Permiso.Cuit, Permiso.IdUN, Permiso.IdTipoPermiso, Permiso.FechaFinVigencia, Permiso.IdUsuarioSolicitante, Permiso.AccionTipo, Permiso.AccionNro, Permiso.IdWF, Permiso.Estado ");
            a.AppendLine("from Permiso where 1=1 ");
            if (IdUsuario != String.Empty) a.AppendLine("and IdUsuario='" + IdUsuario + "' ");
            if (CUIT != String.Empty) a.AppendLine("and CUIT='" + CUIT + "' ");
            if (IdTipoPermiso != String.Empty) a.AppendLine("and IdTipoPermiso='" + IdTipoPermiso + "' ");
            if (Estado != String.Empty) a.AppendLine("and Estado='" + Estado + "' ");
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
        }
        public void Alta(Entidades.Permiso Permiso)
        {
            Ejecutar(AltaHandler(Permiso, true, true, false), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public string AltaHandler(Entidades.Permiso Permiso, bool GeneroAccion, bool DeclaroIdWF, bool EnAltaDeUN)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            if (DeclaroIdWF)
            {
                a.AppendLine("declare @idWF varchar(256) ");
            }
            a.AppendLine("update Configuracion set @idWF=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdWF' ");
            if (GeneroAccion)
            {
                a.AppendLine("declare @accionTipo varchar(15) ");
                a.AppendLine("set @accionTipo='" + Permiso.Accion.Tipo + "' ");
                a.AppendLine("declare @accionNro varchar(256) ");
                a.AppendLine("update Configuracion set @accionNro=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoAccionNro' ");
            }
            string idUN = String.Empty;
            if (EnAltaDeUN)
            {
                idUN = "@IdUN";
            }
            else
            {
                idUN = "'" + Permiso.UN.Id + "'";
            }
            if (Permiso.Usuario.Id != null)
            {
                a.AppendLine("insert Permiso values ('" + Permiso.Usuario.Id + "', '" + Permiso.Cuit + "', " + idUN + ", '" + Permiso.TipoPermiso.Id + "', '" + Permiso.FechaFinVigencia.ToString("yyyyMMdd") + "', '" + Permiso.UsuarioSolicitante.Id + "', @accionTipo, @accionNro, @idWF, '" + Permiso.WF.Estado + "') ");
            }
            else
            {
                a.AppendLine("insert Permiso values ('', '" + Permiso.Cuit + "', " + idUN + ", '" + Permiso.TipoPermiso.Id + "', '" + Permiso.FechaFinVigencia.ToString("yyyyMMdd") + "', '" + Permiso.UsuarioSolicitante.Id + "', @accionTipo, @accionNro, @idWF, '" + Permiso.WF.Estado + "') ");
            }
            a.AppendLine("insert Log values (@IdWF, getdate(), '" + Permiso.UsuarioSolicitante.Id + "', 'Permiso', 'Alta', '" + Permiso.WF.Estado + "', '') ");
            return a.ToString();
        }
        public List<Entidades.Usuario> LeerListaUsuariosAutorizadores(string Cuit)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("select IdUsuario from Permiso where Cuit='" + Cuit + "' and IdTipoPermiso='AdminCUIT' and Estado='Vigente' ");
            return LeerListaUsuarios(a.ToString());
        }
        public List<Entidades.Usuario> LeerListaUsuariosAutorizadores(string Cuit, int IdUN)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("select IdUsuario from Permiso where Cuit='" + Cuit + "' and IdUN='" + IdUN.ToString() + "' and IdTipoPermiso='AdminUN' and Estado='Vigente' ");
            return LeerListaUsuarios(a.ToString());
        }
        public List<Entidades.Usuario> LeerListaUsuarios(string SqlScript)
        {
            DataTable dt = (DataTable)Ejecutar(SqlScript, TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<Entidades.Usuario> lista = new List<Entidades.Usuario>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Entidades.Usuario elem = new Entidades.Usuario();
                    elem.Id = Convert.ToString(dt.Rows[i]["IdUsuario"]);
                    Usuario db = new Usuario(sesion);
                    db.Leer(elem);
                    lista.Add(elem);
                }
            }
            return lista;
        }
        public void CambioEstado(Entidades.Permiso Permiso, string Evento, string EstadoHst)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("declare @IdWF int ");
            a.AppendLine("select @IdWF=IdWF from Permiso where Estado='" + Permiso.WF.Estado + "' and IdUsuario='" + Permiso.Usuario.Id + "' and Cuit='" + Permiso.Cuit + "' and IdUN='" + Permiso.UN.Id + "' and IdTipoPermiso='" + Permiso.TipoPermiso.Id + "' and Estado='" + Permiso.WF.Estado + "' ");
            a.AppendLine("if not @IdWF is null ");
            a.AppendLine("begin ");
            a.AppendLine("   update Permiso set Estado='" + EstadoHst + "' where IdWF=@IdWF ");
            a.AppendLine("   insert Log values (@IdWF, getdate(), '" + sesion.Usuario.Id + "', 'Permiso', '" + Evento + "', '" + EstadoHst + "', '') ");
            a.AppendLine("end ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
            Permiso.WF.Estado = EstadoHst;
        }
    }
}