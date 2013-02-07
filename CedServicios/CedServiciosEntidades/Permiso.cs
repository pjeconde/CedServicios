using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    [Serializable]
    public class Permiso
    {
        private string idUsuario;
        private string cuit;
        private string idUN;
        private TipoPermiso tipoPermiso;
        private DateTime fechaFinVigencia;
        private string idUsuarioSolicitante;
        private Accion accion;
        private WF wF;

        public Permiso()
        {
            tipoPermiso = new TipoPermiso();
            accion = new Accion();
            wF = new WF();
        }

        public string IdUsuario
        {
            set
            {
                idUsuario = value;
            }
            get
            {
                return idUsuario;
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
        public string IdUN
        {
            set
            {
                idUN = value;
            }
            get
            {
                return idUN;
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
        public string IdUsuarioSolicitante
        {
            set
            {
                idUsuarioSolicitante = value;
            }
            get
            {
                return idUsuarioSolicitante;
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
    }
}
