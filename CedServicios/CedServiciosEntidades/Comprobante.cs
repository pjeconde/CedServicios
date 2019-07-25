using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    [Serializable]
    public class Comprobante : ICloneable
    {
        private string cuit;
        //identificación comprobante
        private TipoComprobante tipoComprobante;
        private int nroPuntoVta;
        private long nro;
        private long nroLote;
        //identificación cliente
        private Documento documento;
        private string idPersona;
        private int desambiguacionCuitPais;
        private string razonSocial;
        //datos comprobante
        private string detalle;
        private DateTime fecha;
        private DateTime fechaVto;
        private string moneda;
        private double importeMoneda;
        private double tipoCambio;
        private double importe;
        private string request;
        private string response;
        private string idDestinoComprobante;
        private WF wF;
        private string ultActualiz;
        private NaturalezaComprobante naturalezaComprobante;
        //Campos Adicionales Opcionales
        private string cuitRazonSocial;
        private DateTime fechaAlta;
        private string periodicidadEmision;
        private DateTime fechaProximaEmision;
        private int cantidadComprobantesAEmitir;
        private int cantidadComprobantesEmitidos;
        private int cantidadDiasFechaVto;
        private DatosEmailAvisoComprobanteContrato datosEmailAvisoComprobanteContrato;
        //Stock y contabilidad
        private List<ComprobanteDetalle> minutas;

        public Comprobante()
        {
            tipoComprobante = new TipoComprobante();
            documento = new Documento();
            wF = new WF();
            naturalezaComprobante = new NaturalezaComprobante();
            datosEmailAvisoComprobanteContrato = new DatosEmailAvisoComprobanteContrato();
            minutas = new List<ComprobanteDetalle>();
        }

        public object Clone()
        {
            return this.MemberwiseClone();
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
        public TipoComprobante TipoComprobante
        {
            set
            {
                tipoComprobante = value;
            }
            get
            {
                return tipoComprobante;
            }
        }
        public int NroPuntoVta
        {
            set
            {
                nroPuntoVta = value;
            }
            get
            {
                return nroPuntoVta;
            }
        }
        public long Nro
        {
            set
            {
                nro = value;
            }
            get
            {
                return nro;
            }
        }
        public long NroLote
        {
            set
            {
                nroLote = value;
            }
            get
            {
                return nroLote;
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
        public string Detalle
        {
            set
            {
                detalle = value;
            }
            get
            {
                return detalle;
            }
        }
        public DateTime Fecha
        {
            set
            {
                fecha = value;
            }
            get
            {
                return fecha;
            }
        }
        public DateTime FechaVto
        {
            set
            {
                fechaVto = value;
            }
            get
            {
                return fechaVto;
            }
        }
        public string Moneda
        {
            set
            {
                moneda = value;
            }
            get
            {
                return moneda;
            }
        }
        public double ImporteMoneda
        {
            set
            {
                importeMoneda = value;
            }
            get
            {
                return importeMoneda;
            }
        }
        public double TipoCambio
        {
            set
            {
                tipoCambio = value;
            }
            get
            {
                return tipoCambio;
            }
        }
        public double Importe
        {
            set
            {
                importe = value;
            }
            get
            {
                return importe;
            }
        }
        public string Request
        {
            set
            {
                request = value;
            }
            get
            {
                return request;
            }
        }
        public string Response
        {
            set
            {
                response = value;
            }
            get
            {
                return response;
            }
        }
        public string IdDestinoComprobante
        {
            set
            {
                idDestinoComprobante = value;
            }
            get
            {
                return idDestinoComprobante;
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
        public NaturalezaComprobante NaturalezaComprobante
        {
            set
            {
                naturalezaComprobante = value;
            }
            get
            {
                return naturalezaComprobante;
            }
        }
        public string PeriodicidadEmision
        {
            set
            {
                periodicidadEmision = value;
            }
            get
            {
                return periodicidadEmision;
            }
        }
        public DateTime FechaProximaEmision
        {
            set
            {
                fechaProximaEmision = value;
            }
            get
            {
                return fechaProximaEmision;
            }
        }
        public int CantidadComprobantesAEmitir
        {
            set
            {
                cantidadComprobantesAEmitir = value;
            }
            get
            {
                return cantidadComprobantesAEmitir;
            }
        }
        public int CantidadComprobantesEmitidos
        {
            set
            {
                cantidadComprobantesEmitidos = value;
            }
            get
            {
                return cantidadComprobantesEmitidos;
            }
        }
        public int CantidadDiasFechaVto
        {
            set
            {
                cantidadDiasFechaVto = value;
            }
            get
            {
                return cantidadDiasFechaVto;
            }
        }
        public DatosEmailAvisoComprobanteContrato DatosEmailAvisoComprobanteContrato
        {
            set
            {
                datosEmailAvisoComprobanteContrato = value;
            }
            get
            {
                return datosEmailAvisoComprobanteContrato;
            }
        }
        public List<ComprobanteDetalle> Minutas
        {
            set
            {
                minutas = value;
            }
            get
            {
                return minutas;
            }
        }
        #region propiedades adicionales opcionales
        public string CuitRazonSocial
        {
            set
            {
                cuitRazonSocial = value;
            }
            get
            {
                return cuitRazonSocial;
            }
        }
        public DateTime FechaAlta
        {
            set
            {
                fechaAlta = value;
            }
            get
            {
                return fechaAlta;
            }
        }
        #endregion
        #region propiedades redundantes
        public string DescrTipoComprobante
        {
            get
            {
                return tipoComprobante.Descr;
            }
        }
        public string DescrTipoDoc
        {
            get
            {
                return documento.Tipo.Descr;
            }
        }
        public string NroDoc
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
        public string NroPuntoVtaFORMATEADO
        {
            get
            {
                return nroPuntoVta.ToString("0000");
            }
        }
        public string NroFORMATEADO
        {
            get
            {
                return nro.ToString("00000000");
            }
        }
        public string DescrNaturalezaComprobante
        {
            get
            {
                return naturalezaComprobante.Descr;
            }
        }
        #endregion
    }
}