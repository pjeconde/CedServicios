using System;
using System.Collections.Generic;
using System.Text;

namespace CedServicios.Entidades
{
    
    public class StockXArticuloDetalle
    {
        string idArticulo;
        string descr;
        string indicacionExentoGravado;
        string idNaturalezaComprobante;
        string compTipo;
        string compNro;
        string compPtoVta;
        string compFecEmi;

        string empNroDoc;
        string empCodDoc;
        string empDescrDoc;
        string empNombre;

        string moneda;
        double tipoCambio;
        double cantidad;
        double precioUnitario;
        double importeTotal;

        public StockXArticuloDetalle()
        {
        }
        public string IdArticulo
        {
            set
            {
                idArticulo = value;
            }
            get
            {
                return idArticulo;
            }
        }
        public string Descr
        {
            set
            {
                descr = value;
            }
            get
            {
                return descr;
            }
        }
        public string IdNaturalezaComprobante
        {
            set
            {
                idNaturalezaComprobante = value;
            }
            get
            {
                return idNaturalezaComprobante;
            }
        }
        public string IndicacionExentoGravado
        {
            set
            {
                indicacionExentoGravado = value;
            }
            get
            {
                return indicacionExentoGravado;
            }
        }
        public string CompTipo
        {
            set
            {
                compTipo = value;
            }
            get
            {
                return compTipo;
            }
        }
        public string CompNro
        {
            set
            {
                compNro = value;
            }
            get
            {
                return compNro;
            }
        }
        public string CompPtoVta
        {
            set
            {
                compPtoVta = value;
            }
            get
            {
                return compPtoVta;
            }
        }
        public string CompFecEmi
        {
            set
            {
                compFecEmi = value;
            }
            get
            {
                return compFecEmi;
            }
        }
        public string EmpNroDoc
        {
            set
            {
                empNroDoc = value;
            }
            get
            {
                return empNroDoc;
            }
        }
        public string EmpCodDoc
        {
            set
            {
                empCodDoc = value;
            }
            get
            {
                return empCodDoc;
            }
        }
        public string EmpDescrDoc
        {
            set
            {
                empDescrDoc = value;
            }
            get
            {
                return empDescrDoc;
            }
        }
        public string EmpNombre
        {
            set
            {
                empNombre = value;
            }
            get
            {
                return empNombre;
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
        public double Cantidad
        {
            set
            {
                cantidad = value;
            }
            get
            {
                return cantidad;
            }
        }
        public double PrecioUnitario
        {
            set
            {
                precioUnitario = value;
            }
            get
            {
                return precioUnitario;
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
    }
}
