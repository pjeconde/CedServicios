using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    [Serializable]
    public class DestinoComprobante
    {
        private string id;
        private string descr;

        public DestinoComprobante()
        {
        }

        public DestinoComprobante(string Id, string Descr)
        {
            id = Id;
            descr = Descr;
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
    }
}
