using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    [Serializable]
    public class UN
    {
        private string cuit;
        private int id;
        private string descr;
        private WF wF;
        private string ultActualiz;
        private List<PuntoVta> puntosVta;

        public UN()
        {
            wF = new WF();
            puntosVta = new List<PuntoVta>();
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
        public int Id
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
        public List<PuntoVta> PuntosVta
        {
            set
            {
                puntosVta = value;
            }
            get
            {
                return puntosVta;
            }
        }
        public List<PuntoVta> PuntosVtaVigentes
        {
            get
            {
                List<Entidades.PuntoVta> lista = new List<PuntoVta>();
                for (int i = 0; i < puntosVta.Count; i++)
                {
                    if (puntosVta[i].WF.Estado == "Vigente") lista.Add(puntosVta[i]);
                }
                return lista;
            }
        }
    }
}