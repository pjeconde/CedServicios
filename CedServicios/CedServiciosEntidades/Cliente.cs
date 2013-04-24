using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    [Serializable]
    public class Cliente
    {
        private string cuit;
        private Documento documento;
        private string idCliente;
        private string razonSocial;
        private Domicilio domicilio;
        private Contacto contacto;
        private DatosImpositivos datosImpositivos;
        private DatosIdentificatorios datosIdentificatorios;
        private string emailAvisoVisualizacion;
        private string passwordAvisoVisualizacion;
        private WF wF;
        private string ultActualiz;

        public Cliente()
        {
            documento = new Documento();
            domicilio = new Domicilio();
            contacto = new Contacto();
            datosImpositivos = new DatosImpositivos();
            datosIdentificatorios = new DatosIdentificatorios();
            wF = new WF();
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
        public Documento Documento
        {
            set
            {
                documento = value;
            }
            get
            {
                return documento;
            }
        }
        public string IdCliente
        {
            set
            {
                idCliente = value;
            }
            get
            {
                return idCliente;
            }
        }
        public string RazonSocial
        {
            set
            {
                razonSocial = value;
            }
            get
            {
                return razonSocial;
            }
        }
        public Domicilio Domicilio
        {
            set
            {
                domicilio = value;
            }
            get
            {
                return domicilio;
            }
        }
        public Contacto Contacto
        {
            set
            {
                contacto = value;
            }
            get
            {
                return contacto;
            }
        }
        public DatosImpositivos DatosImpositivos
        {
            set
            {
                datosImpositivos = value;
            }
            get
            {
                return datosImpositivos;
            }
        }
        public DatosIdentificatorios DatosIdentificatorios
        {
            set
            {
                datosIdentificatorios = value;
            }
            get
            {
                return datosIdentificatorios;
            }
        }
        public string EmailAvisoVisualizacion
        {
            set
            {
                emailAvisoVisualizacion = value;
            }
            get
            {
                return emailAvisoVisualizacion;
            }
        }
        public string PasswordAvisoVisualizacion
        {
            set
            {
                passwordAvisoVisualizacion = value;
            }
            get
            {
                return passwordAvisoVisualizacion;
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
        public string UltActualiz
        {
            set
            {
                ultActualiz = value;
            }
            get
            {
                return ultActualiz;
            }
        }
        #region Propiedades redundantes
        public string DocumentoTipoDescr
        {
            get
            {
                return documento.Tipo.Descr;
            }
        }
        public long DocumentoNro
        {
            get
            {
                return documento.Nro;
            }
        }
        public string Estado
        {
            get
            {
                return wF.Estado;
            }
        }
        #endregion
    }
}
