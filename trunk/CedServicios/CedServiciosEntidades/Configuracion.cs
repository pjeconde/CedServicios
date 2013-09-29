using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    [Serializable]
    public class Configuracion
    {
        private string idUsuario;
        private string cuit;
        private int idUN;
        private TipoPermiso tipoPermiso;
        private string idItemConfig;
        private string valor;

        public Configuracion()
        {
            tipoPermiso = new TipoPermiso();
        }
        public Configuracion(string IdItemConfig)
        {
            tipoPermiso = new TipoPermiso();
            idItemConfig = IdItemConfig;
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
        public int IdUN
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
        public string IdItemConfig
        {
            set
            {
                idItemConfig = value;
            }
            get
            {
                return idItemConfig;
            }
        }
        public string Valor
        {
            set
            {
                valor = value;
            }
            get
            {
                return valor;
            }
        }
        #region Propiedades redundantes
        public string TipoPermisoId
        {
            get
            {
                return tipoPermiso.Id;
            }
        }
        public string TipoPermisoDescr
        {
            get
            {
                return tipoPermiso.Descr;
            }
        }
        #endregion
    }
}
