using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    [Serializable]
    public class BusquedaPerfil
    {
        private string idBusquedaPerfil;
        private string descrBusquedaPerfil;
        private string estado;

        public string IdBusquedaPerfil
        {
            set
            {
                idBusquedaPerfil = value;
            }
            get
            {
                return idBusquedaPerfil;
            }
        }
        public string DescrBusquedaPerfil
        {
            set
            {
                descrBusquedaPerfil = value;
            }
            get
            {
                return descrBusquedaPerfil;
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
