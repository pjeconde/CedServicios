using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    [Serializable]
    public class WF
    {
        protected int idWF;
        protected string estado;

        public int IdWF
        {
            set
            {
                idWF = value;
            }
            get
            {
                return idWF;
            }
        }
        public string Estado
        {
            set
            {
                estado = value;
            }
            get
            {
                return estado;
            }
        }
    }
}
