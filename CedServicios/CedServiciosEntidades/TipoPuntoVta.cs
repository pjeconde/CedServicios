using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    [Serializable]
    public class TipoPuntoVta
    {
        private string id;

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
                id = value;
            }
            get
            {
                return id;
            }
        }
    }
}
