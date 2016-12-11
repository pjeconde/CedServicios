using System;
using System.Collections.Generic;
using System.Text;

namespace CedServicios.Entidades
{
    
    public class IvaComprasTotXIVA
    {
        string concepto;
        double importeNG;
        double importeTotal;
        double alicuota;

        public IvaComprasTotXIVA()
        {
        }
        public string Concepto
        {
            set
            {
                concepto = value;
            }
            get
            {
                return concepto;
            }
        }
        public double ImporteNG
        {
            set
            {
                importeNG = value;
            }
            get
            {
                return importeNG;
            }
        }
        public double ImporteTotal
        {
            set
            {
                importeTotal = value;
            }
            get
            {
                return importeTotal;
            }
        }
        public double Alicuota
        {
            set
            {
                alicuota = value;
            }
            get
            {
                return alicuota;
            }
        }

    }
}
