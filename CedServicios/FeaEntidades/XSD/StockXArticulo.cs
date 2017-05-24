using System;
using System.Collections.Generic;
using System.Text;

namespace CedServicios.Entidades
{

    public class StockXArticulo
    {
        string cuit;
        string razSoc;
        string periodoDsd;
        string periodoHst;

        List<CedServicios.Entidades.StockXArticuloDetalle> stockXArticuloXArticuloDetalle;

        public StockXArticulo()
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
        [System.Xml.Serialization.XmlElementAttribute("StockXArticuloDetalle")]
        public List<CedServicios.Entidades.StockXArticuloDetalle> StockXArticuloDetalle
        {
            set
            {
                stockXArticuloXArticuloDetalle = value;
            }
            get
            {
                return stockXArticuloXArticuloDetalle;
            }
        }
    }
}
