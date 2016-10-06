using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    [Serializable]
    public class EsquemaContable
    {
        private TipoComprobante tipoComprobante;
        private NaturalezaComprobante naturalezaComprobante;
        private string concepto;
        private Rubro rubro;
        private int signo;

        public EsquemaContable()
        {
            tipoComprobante = new TipoComprobante();
            naturalezaComprobante = new NaturalezaComprobante();
            rubro = new Rubro();
        }
        public EsquemaContable(TipoComprobante TipoComprobante, NaturalezaComprobante NaturalezaComprobante, string Concepto)
        {
            tipoComprobante = TipoComprobante;
            naturalezaComprobante = NaturalezaComprobante;
            rubro = new Rubro();
            concepto = Concepto;
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
        public Rubro Rubro
        {
            set
            {
                rubro = value;
            }
            get
            {
                return rubro;
            }
        }
        public int Signo
        {
            set
            {
                signo = value;
            }
            get
            {
                return signo;
            }
        }
    }
}
