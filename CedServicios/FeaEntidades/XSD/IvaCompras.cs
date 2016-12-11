using System;
using System.Collections.Generic;
using System.Text;

namespace CedServicios.Entidades
{
    public class IvaCompras
    {
        string cuit;
        string periodoDsd;
        string periodoHst;

        List<CedServicios.Entidades.IvaComprasComprobantes> ivaComprasComprobantes;
        List<CedServicios.Entidades.IvaComprasTotXImpuestos> ivaComprasTotXImpuestos;
        List<CedServicios.Entidades.IvaComprasTotXIVA> ivaComprasTotXIVA;

        public IvaCompras()
        {
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
        public string PeriodoDsd
        {
            set
            {
                periodoDsd = value;
            }
            get
            {
                return periodoDsd;
            }
        }
        public string PeriodoHst
        {
            set
            {
                periodoHst = value;
            }
            get
            {
                return periodoHst;
            }
        }
        [System.Xml.Serialization.XmlElementAttribute("IvaComprasComprobantes")]
        public List<CedServicios.Entidades.IvaComprasComprobantes> IvaComprasComprobantes
        {
            set
            {
                ivaComprasComprobantes = value;
            }
            get
            {
                return ivaComprasComprobantes;
            }
        }
        [System.Xml.Serialization.XmlElementAttribute("IvaComprasTotXImpuestos")]
        public List<CedServicios.Entidades.IvaComprasTotXImpuestos> IvaComprasTotXImpuestos
        {
            set
            {
                ivaComprasTotXImpuestos = value;
            }
            get
            {
                return ivaComprasTotXImpuestos;
            }
        }
        [System.Xml.Serialization.XmlElementAttribute("IvaComprasTotXIVA")]
        public List<CedServicios.Entidades.IvaComprasTotXIVA> IvaComprasTotXIVA
        {
            set
            {
                ivaComprasTotXIVA = value;
            }
            get
            {
                return ivaComprasTotXIVA;
            }
        }
    }
}
