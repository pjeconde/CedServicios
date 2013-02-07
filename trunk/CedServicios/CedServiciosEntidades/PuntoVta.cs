using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    [Serializable]
    public class PuntoVta
    {
        private string cuit;
        private int nro;
        private string idUN;
        private string idTipoPuntoVta;
        private bool usaSetPropioDeDatosCuit;
            private Domicilio domicilio;
            private Contacto contacto;
            private DatosImpositivos datosImpositivos;
            private DatosIdentificatorios datosIdentificatorios;
        private MetodoGeneracionNumeracionLote metodoGeneracionNumeracionLote;
        private int ultNroLote;
        private WF wF;
        private DateTime ultActualiz;

        public PuntoVta()
        {
            domicilio = new Domicilio();
            contacto = new Contacto();
            datosImpositivos = new DatosImpositivos();
            datosIdentificatorios = new DatosIdentificatorios();
            metodoGeneracionNumeracionLote = new MetodoGeneracionNumeracionLote();
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
        public int Nro
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
        public string IdUN
        {
            set
            {
                idUN = value;
            }
            get
            {
                return idUN;
            }
        }
        public string IdTipoPuntoVta
        {
            set
            {
                idTipoPuntoVta = value;
            }
            get
            {
                return idTipoPuntoVta;
            }
        }
        public bool UsaSetPropioDeDatosCuit
        {
            set
            {
                usaSetPropioDeDatosCuit = value;
            }
            get
            {
                return usaSetPropioDeDatosCuit;
            }
        }
        public Domicilio Domicilio
        {
            set
            {
                domicilio = value;
            }
            get
            {
                return domicilio;
            }
        }
        public Contacto Contacto
        {
            set
            {
                contacto = value;
            }
            get
            {
                return contacto;
            }
        }
        public DatosImpositivos DatosImpositivos
        {
            set
            {
                datosImpositivos = value;
            }
            get
            {
                return datosImpositivos;
            }
        }
        public DatosIdentificatorios DatosIdentificatorios
        {
            set
            {
                datosIdentificatorios = value;
            }
            get
            {
                return datosIdentificatorios;
            }
        }
        public MetodoGeneracionNumeracionLote MetodoGeneracionNumeracionLote
        {
            set
            {
                metodoGeneracionNumeracionLote = value;
            }
            get
            {
                return metodoGeneracionNumeracionLote;
            }
        }
        public int UltNroLote
        {
            set
            {
                ultNroLote = value;
            }
            get
            {
                return ultNroLote;
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
        public DateTime UltActualiz
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
    }
}
