using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    [Serializable]
    public class Domicilio
    {
        private string calle = string.Empty;
        private string nro = string.Empty;
        private string piso = string.Empty;
        private string depto = string.Empty;
        private string sector = string.Empty;
        private string torre = string.Empty;
        private string manzana = string.Empty;
        private string localidad = string.Empty;
        private Provincia provincia;
        private string codPost = string.Empty;

        public Domicilio()
        {
            provincia = new Provincia();
        }

        public string Calle
        {
            set
            {
                calle = value;
            }
            get
            {
                return calle;
            }
        }
        public string Nro
        {
            set
            {
                nro = value;
            }
            get
            {
                return nro;
            }
        }
        public string Piso
        {
            set
            {
                piso = value;
            }
            get
            {
                return piso;
            }
        }
        public string Depto
        {
            set
            {
                depto = value;
            }
            get
            {
                return depto;
            }
        }
        public string Sector
        {
            set
            {
                sector = value;
            }
            get
            {
                return sector;
            }
        }
        public string Torre
        {
            set
            {
                torre = value;
            }
            get
            {
                return torre;
            }
        }
        public string Manzana
        {
            set
            {
                manzana = value;
            }
            get
            {
                return manzana;
            }
        }
        public string Localidad
        {
            set
            {
                localidad = value;
            }
            get
            {
                return localidad;
            }
        }
        public Provincia Provincia
        {
            set
            {
                provincia = value;
            }
            get
            {
                return provincia;
            }
        }
        public string CodPost
        {
            set
            {
                codPost = value;
            }
            get
            {
                return codPost;
            }
        }
    }
}
