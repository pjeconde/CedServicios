using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    [Serializable]
    public class Accion
    {
        private string tipo;
        private int nro;

        public string Tipo
        {
            set
            {
                tipo = value;
            }
            get
            {
                return tipo;
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
    }
}
