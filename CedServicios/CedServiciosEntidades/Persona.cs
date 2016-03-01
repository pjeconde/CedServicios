using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    [Serializable]
    public class Persona
    {
        private string cuit;
        private Documento documento;
        private string idPersona;
        private int desambiguacionCuitPais;
        private string razonSocial;
        private Domicilio domicilio;
        private Contacto contacto;
        private DatosImpositivos datosImpositivos;
        private DatosIdentificatorios datosIdentificatorios;
        private string emailAvisoVisualizacion;
        private string passwordAvisoVisualizacion;
        private WF wF;
        private string ultActualiz;
        private int orden;
        private bool esCliente;
        private bool esProveedor;
        private DatosEmailAvisoComprobantePersona datosEmailAvisoComprobantePersona;

        public Persona()
        {
            documento = new Documento();
            domicilio = new Domicilio();
            contacto = new Contacto();
            datosImpositivos = new DatosImpositivos();
            datosIdentificatorios = new DatosIdentificatorios();
            datosEmailAvisoComprobantePersona = new DatosEmailAvisoComprobantePersona();
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
        public string IdPersona
        {
            set
            {
                idPersona = value;
            }
            get
            {
                return idPersona;
            }
        }
        public int DesambiguacionCuitPais
        {
            set
            {
                desambiguacionCuitPais = value;
            }
            get
            {
                return desambiguacionCuitPais;
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
        public DatosEmailAvisoComprobantePersona DatosEmailAvisoComprobantePersona
        {
            set
            {
                datosEmailAvisoComprobantePersona = value;
            }
            get
            {
                return datosEmailAvisoComprobantePersona;
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
        public int Orden
        {
            set
            {
                orden = value;
            }
            get
            {
                return orden;
            }
        }
        public bool EsCliente
        {
            set
            {
                esCliente = value;
            }
            get
            {
                return esCliente;
            }
        }
        public bool EsProveedor
        {
            set
            {
                esProveedor = value;
            }
            get
            {
                return esProveedor;
            }
        }
        #region Propiedades redundantes
        public string DocumentoIdTipoDoc
        {
            get
            {
                return documento.Tipo.Id;
            }
        }
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
        public string DomicilioCalle
        {
            get
            {
                return Domicilio.Calle;
            }
        }
        public string DomicilioNro
        {
            get
            {
                return Domicilio.Nro;
            }
        }
        public string DomicilioPiso
        {
            get
            {
                return Domicilio.Piso;
            }
        }
        public string DomicilioDepto
        {
            get
            {
                return Domicilio.Depto;
            }
        }
        public string DomicilioLocalidad
        {
            get
            {
                return Domicilio.Localidad;
            }
        }
        public string DomicilioCodPost
        {
            get
            {
                return Domicilio.CodPost;
            }
        }
        public string ContactoNombre
        {
            get
            {
                return Contacto.Nombre;
            }
        }
        public string ContactoEmail
        {
            get
            {
                return Contacto.Email;
            }
        }
        public string ContactoTelefono
        {
            get
            {
                return Contacto.Telefono;
            }
        }
        public string DescrTipoPersona
        {
            get
            {
                if (esCliente && esProveedor) return "Cliente y proveedor";
                else if (esCliente) return "Cliente"; else return "Proveedor";
            }
        }
        public string ClavePrimaria
        {
            get
            {
                if (cuit != null)
                {
                    return cuit + '\t' + documento.Tipo.Id + '\t' + documento.Nro.ToString() + '\t' + idPersona.ToString() + '\t' + desambiguacionCuitPais.ToString();
                }
                else
                {
                    return String.Empty + '\t' + "0" + '\t' + "0" + '\t' + String.Empty + '\t' + "0";
                }
            }
        }
        #endregion
    }
}
