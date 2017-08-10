using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    [Serializable]
    public class Documento
    {
        private TipoDocumento tipo;
        private string nro;

        public Documento()
        {
            tipo = new TipoDocumento();
        }

        public TipoDocumento Tipo
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
    }
}
