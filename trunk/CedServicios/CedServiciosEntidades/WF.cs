using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    [Serializable]
    public class WF
    {
        protected int id;
        protected string estado;

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
