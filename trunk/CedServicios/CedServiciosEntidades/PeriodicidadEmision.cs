using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    [Serializable]
    public class PeriodicidadEmision
    {
        private string id;
        private string descr;

        public PeriodicidadEmision()
        {
        }

        public PeriodicidadEmision(string Id, string Descr)
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
