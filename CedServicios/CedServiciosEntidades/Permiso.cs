using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    [Serializable]
    public class Permiso
    {
        private Usuario usuario;
        private string cuit;
        private UN uN;
        private TipoPermiso tipoPermiso;
        private DateTime fechaFinVigencia;
        private Usuario usuarioSolicitante;
        private Accion accion;
        private WF wF;

        public Permiso()
        {
            usuario = new Usuario();
            uN = new UN();
            tipoPermiso = new TipoPermiso();
            usuarioSolicitante = new Entidades.Usuario();
            accion = new Accion();
            wF = new WF();
        }

        public Usuario Usuario
        {
            set
            {
                usuario = value;
            }
            get
            {
                return usuario;
            }
        }
        public string Cuit
        {
            set
            {
                cuit = value;
            }
            get
            {
                return cuit;
            }
        }
        public UN UN
        {
            set
            {
                uN = value;
            }
            get
            {
                return uN;
            }
        }
        public TipoPermiso TipoPermiso
        {
            set
            {
                tipoPermiso = value;
            }
            get
            {
                return tipoPermiso;
            }
        }
        public DateTime FechaFinVigencia
        {
            set
            {
                fechaFinVigencia = value;
            }
            get
            {
                return fechaFinVigencia;
            }
        }
        public Usuario UsuarioSolicitante
        {
            set
            {
                usuarioSolicitante = value;
            }
            get
            {
                return usuarioSolicitante;
            }
        }
        public Accion Accion
        {
            set
            {
                accion = value;
            }
            get
            {
                return accion;
            }
        }
        public WF WF
        {
            set
            {
                wF = value;
            }
            get
            {
                return wF;
            }
        }
        #region Propiedades redundantes
        public string Estado
        {
            get
            {
                return wF.Estado;
            }
        }
        public string IdTipoPermiso
        {
            get
            {
                return tipoPermiso.Id;
            }
        }
        public string DescrTipoPermiso
        {
            get
            {
                return tipoPermiso.Descr;
            }
        }
        public string IdUsuario
        {
            get
            {
                return usuario.Id;
            }
        }
        public string NombreUsuario
        {
            get
            {
                return usuario.Nombre;
            }
        }
        public string IdUsuarioSolicitante
        {
            get
            {
                return usuarioSolicitante.Id;
            }
        }
        public string NombreUsuarioSolicitante
        {
            get
            {
                return usuarioSolicitante.Nombre;
            }
        }
        public string TipoAccion
        {
            get
            {
                return accion.Tipo;
            }
        }
        public int IdUN
        {
            get
            {
                return uN.Id;
            }
        }
        public string DescrUN
        {
            get
            {
                return uN.Descr;
            }
        }
        #endregion
    }
}