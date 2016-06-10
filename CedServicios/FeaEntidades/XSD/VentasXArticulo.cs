using System;
using System.Collections.Generic;
using System.Text;

namespace CedServicios.Entidades
{
    
    public class VentasXArticulo
    {
        string cuit;
        string razSoc;
        string periodoDsd;
        string periodoHst;

        List<CedServicios.Entidades.VentasXArticuloDetalle> ventasXArticuloDetalle;

        public VentasXArticulo()
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
        public string RazSoc
        {
            set
            {
                razSoc = value;
            }
            get
            {
                return razSoc;
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
        [System.Xml.Serialization.XmlElementAttribute("VentasXArticuloDetalle")]
        public List<CedServicios.Entidades.VentasXArticuloDetalle> VentasXArticuloDetalle
        {
            set
            {
                ventasXArticuloDetalle = value;
            }
            get
            {
                return ventasXArticuloDetalle;
            }
        }
    }
}
