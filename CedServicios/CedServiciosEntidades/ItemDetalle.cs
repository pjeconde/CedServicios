using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    [Serializable]
    public class ItemDetalle
    {
        private string idTipo;
        private int nro;

        public string IdTipo
        {
            set
            {
                idTipo = value;
            }
            get
            {
                return idTipo;
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