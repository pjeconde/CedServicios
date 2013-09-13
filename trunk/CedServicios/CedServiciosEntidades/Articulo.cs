using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    [Serializable]
    public class Articulo
    {
        private string cuit;
        private string id;
        private string descr;
        private string gTIN;
        private Unidad unidad;
        private string indicacionExentoGravado;
        private double alicuotaIVA;
        private WF wF;
        private string ultActualiz;

        public Articulo()
        {
            unidad = new Unidad();
            wF = new WF();
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
        public string Id
        {
            set
            {
                id = value;
            }
            get
            {
                return id;
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
        public Unidad Unidad
        {
            set
            {
                unidad = value;
            }
            get
            {
                return unidad;
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
        #region Propiedades redundantes
        public string UnidadId
        {
            get
            {
                return unidad.Id;
            }
        }
        public string UnidadDescr
        {
            get
            {
                return unidad.Descr;
            }
        }
        public string Estado
        {
            get
            {
                return wF.Estado;
            }
        }
        #endregion
    }
}