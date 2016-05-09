using System;
using System.Collections.Generic;
using System.Text;

namespace CedServicios.Entidades
{

    public class IvaVentasComprobantes
    {
        string fechaEmi;
        string razSoc;
        string tipoDoc;
        string nroDoc;
        string ptoVta;
        string tipoComp;
        string tipoCompCodigo;
        string nroComp;
        string moneda;
        double exento;
        double noGravado;
        double gravado;
        double iva;
        double otrosImp;
        double importeTotal;
        double cambio;
        double importeTotalME;
        string concepto;
        
        public IvaVentasComprobantes()
        { 
        }
        public string FechaEmi
        {
            set
            {
                fechaEmi = value;
            }
            get
            {
                return fechaEmi;
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
        public string TipoDoc
        {
            set
            {
                tipoDoc = value;
            }
            get
            {
                return tipoDoc;
            }
        }
        public string NroDoc
        {
            set
            {
                nroDoc = value;
            }
            get
            {
                return nroDoc;
            }
        }
        public string PtoVta
        {
            set
            {
                ptoVta = value;
            }
            get
            {
                return ptoVta;
            }
        }
        public string TipoCompCodigo
        {
            set
            {
                tipoCompCodigo = value;
            }
            get
            {
                return tipoCompCodigo;
            }
        }
        public string TipoComp
        {
            set
            {
                tipoComp = value;
            }
            get
            {
                return tipoComp;
            }
        }
        public string NroComp
        {
            set
            {
                nroComp = value;
            }
            get
            {
                return nroComp;
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
        public double Exento
        {
            set
            {
                exento = value;
            }
            get
            {
                return exento;
            }
        }
        public double NoGravado
        {
            set
            {
                noGravado = value;
            }
            get
            {
                return noGravado;
            }
        }
        public double Gravado
        {
            set
            {
                gravado = value;
            }
            get
            {
                return gravado;
            }
        }
        public double Iva
        {
            set
            {
                iva = value;
            }
            get
            {
                return iva;
            }
        }
        public double OtrosImp
        {
            set
            {
                otrosImp = value;
            }
            get
            {
                return otrosImp;
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
        public double Cambio
        {
            set
            {
                cambio = value;
            }
            get
            {
                return cambio;
            }
        }
        public double ImporteTotalME
        {
            set
            {
                importeTotalME = value;
            }
            get
            {
                return importeTotalME;
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
    }
}
