using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    [Serializable]
    public class DatosIdentificatorios
    {
        private long gLN;
        private string codigoInterno;

        public long GLN
        {
            set
            {
                gLN = value;
            }
            get
            {
                return gLN;
            }
        }
        public string CodigoInterno
        {
            set
            {
                codigoInterno = value;
            }
            get
            {
                return codigoInterno;
            }
        }
    }
}