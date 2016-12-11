using System;
using System.Collections.Generic;
using System.Text;

namespace CedServicios.Entidades
{
    
    public class ComprasXArticulo
    {
        string cuit;
        string razSoc;
        string periodoDsd;
        string periodoHst;

        List<CedServicios.Entidades.ComprasXArticuloDetalle> comprasXArticuloDetalle;

        public ComprasXArticulo()
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
        [System.Xml.Serialization.XmlElementAttribute("ComprasXArticuloDetalle")]
        public List<CedServicios.Entidades.ComprasXArticuloDetalle> ComprasXArticuloDetalle
        {
            set
            {
                comprasXArticuloDetalle = value;
            }
            get
            {
                return comprasXArticuloDetalle;
            }
        }
    }
}
