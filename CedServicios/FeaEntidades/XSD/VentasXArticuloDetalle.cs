using System;
using System.Collections.Generic;
using System.Text;

namespace CedServicios.Entidades
{
    
    public class VentasXArticuloDetalle
    {
        string idArticulo;
        string descr;
        string gTIN;
        string idArticuloEmp;
        string indicacionExentoGravado;
        int numeroLinea;
        string unidadCod;
        string unidadDescr;
        string compTipo;
        string compNro;
        string compPtoVta;
        string compFecEmi;

        string empNroDoc;
        string empCodDoc;
        string empDescrDoc;
        string empNombre;

        double cantidad;
        double precioUnitario;
        double importeTotal;
        double alicuotaIVA;
        double importeIVA;

        public VentasXArticuloDetalle()
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
        public string GTIN
        {
            set
            {
                gTIN = value;
            }
            get
            {
                return gTIN;
            }
        }
        public string IdArticuloEmp
        {
            set
            {
                idArticuloEmp = value;
            }
            get
            {
                return idArticuloEmp;
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
        public int NumeroLinea
        {
            set
            {
                numeroLinea = value;
            }
            get
            {
                return numeroLinea;
            }
        }
        public string UnidadCod
        {
            set
            {
                unidadCod = value;
            }
            get
            {
                return unidadCod;
            }
        }
        public string UnidadDescr
        {
            set
            {
                unidadDescr = value;
            }
            get
            {
                return unidadDescr;
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
        public double AlicuotaIVA
        {
            set
            {
                alicuotaIVA = value;
            }
            get
            {
                return alicuotaIVA;
            }
        }
        public double ImporteIVA
        {
            set
            {
                importeIVA = value;
            }
            get
            {
                return importeIVA;
            }
        }
    }
}
